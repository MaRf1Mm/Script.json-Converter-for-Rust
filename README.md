# Script.json-Converter-for-Rust
**A basic JSON converter for Rust, designed to translate addresses from script.json into HEX format.**

## Description
- This project is a C# application designed to filter and transform JSON data based on specific 'Signature' fields provided in a separate text file.
- It reads a JSON file (script.json) and a text file containing signature patterns (Signature.txt).
- The application then searches for these signatures within the JSON data, modifies specific fields (like converting 'Address' values to HEX format), and generates a new JSON file (updated_script.json) containing only the matched and transformed data.

## How to Use
1. **Select JSON File:** On launching the application, select your script.json file using the file dialog.
2. **Select Signature File:** Next, select your Signature.txt file which contains the signature patterns to search for.
 
 - ![image](https://github.com/MaRf1Mm/Script.json-Converter-for-Rust/assets/107577770/5d63822a-dc39-4f3a-b5f4-1a1f6d729b6e)

3. **Processing:** The application processes the JSON file, filters, and transforms the data according to the signatures.
4. **Output:** The resultant filtered data is saved in updated_script.json in the application's directory.

## Requirements
- .NET Framework
- Newtonsoft.Json library

## Setup and Installation
- Clone the repository to your local machine.
- Ensure .NET Framework is installed.
- Open the solution in Visual Studio.
- Build and run the application.

## Contributions
Contributions, issues, and feature requests are welcome! Feel free to check [issues page](https://github.com/MaRf1Mm/Script.json-Converter-for-Rust/issues). 

## License
Distributed under the MIT License. See [LICENSE](https://github.com/MaRf1Mm/Script.json-Converter-for-Rust/blob/main/LICENSE) for more information.
