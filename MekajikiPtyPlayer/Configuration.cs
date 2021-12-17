using System;
using System.IO;
using System.Text.Json;

namespace MekajikiPtyPlayer
{
    public class Configuration
    {
        public string? Token { get; set; }
        public Uri? Server { get; set; }

        public void Save(string fileName)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(this, new JsonSerializerOptions{ WriteIndented = true }));
        }

        public static Configuration FromFile(string fileName)
        {
            return JsonSerializer.Deserialize<Configuration>(File.ReadAllText(fileName));
        }

        public static bool Exists(string fileName) => File.Exists(fileName);
    }
}