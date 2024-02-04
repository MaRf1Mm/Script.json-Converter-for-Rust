using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    [STAThread]
    static void Main()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "JSON Files|*.json",
            Title = "Select a JSON File"
        };

        string scriptFilePath = "";
        string textFilePath = "";

        // Selecting the script.json file
        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        scriptFilePath = openFileDialog.FileName;

        // Selecting the text file
        openFileDialog.Filter = "Text Files|*.txt";
        openFileDialog.Title = "Select a Text File";

        if (openFileDialog.ShowDialog() != DialogResult.OK) return;
        textFilePath = openFileDialog.FileName;

        // Reading Signature.txt and creating a set for searching
        var signaturesToFind = new HashSet<string>(
            File.ReadAllLines(textFilePath)
                .Select(line => line.Trim())
                .Where(line => line.StartsWith("\"Signature\": \"") && line.EndsWith("\","))
                .Select(line => line.Split('"')[3])
        );

        // Reading and processing script.json
        string jsonData = File.ReadAllText(scriptFilePath);
        JObject jsonObject = JObject.Parse(jsonData);

        JArray filteredJsonArray = new JArray();
        // Processing each array in JSON
        foreach (var property in jsonObject.Properties())
        {
            if (property.Value is JArray jsonArray)
            {
                for (int i = 0; i < jsonArray.Count; i++)
                {
                    if (jsonArray[i] is JObject item && signaturesToFind.Contains(item["Signature"]?.ToString()))
                    {
                        int address = int.Parse(item["Address"].ToString());
                        item["Address"] = address.ToString("X").ToUpper();
                        filteredJsonArray.Add(item);
                    }
                }
            }
        }

        // Writing to updated_script.json
        string updatedJson = JsonConvert.SerializeObject(filteredJsonArray, Formatting.Indented);
        File.WriteAllText("updated_script.json", updatedJson);

        Console.WriteLine("updated_script.json has been created with filtered signatures.");
    }
}
