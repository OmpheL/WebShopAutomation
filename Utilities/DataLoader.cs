using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WebShopAutomation.Utilities
{
    // Static class for loading data from JSON files.
    public static class DataLoader
    {
        // Loads user data from a JSON file and returns a UsersRoot object.
        public static UsersRoot LoadUsersFromJson(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at path {filePath} was not found.");
            }

            try
            {
                var jsonData = File.ReadAllText(filePath);
                // Deserialize the JSON data into a UsersRoot object.
                return JsonConvert.DeserializeObject<UsersRoot>(jsonData);
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization errors.
                throw new InvalidOperationException("Failed to deserialize JSON data.", ex);
            }
            catch (IOException ex)
            {
                // Handle file read errors.
                throw new InvalidOperationException("Failed to read the file.", ex);
            }
        }
    }
}
