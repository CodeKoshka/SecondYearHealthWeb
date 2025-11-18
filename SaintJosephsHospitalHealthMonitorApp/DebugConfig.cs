using System;
using System.IO;
using System.Text.Json;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public class DebugConfig
    {
        public bool EnableAdmin { get; set; } = true;
        public bool EnableReceptionist { get; set; } = true;
        public bool EnableDoctor { get; set; } = true;
        public bool EnablePharmacist { get; set; } = false;
        public bool CreateDefaultHeadadmin { get; set; } = true;
        public bool CreateDefaultAdmin { get; set; } = true;
        public bool CreateDefaultReceptionist { get; set; } = true;
        public bool CreateDefaultPharmacist { get; set; } = false;
        public bool CreateDefaultDoctor { get; set; } = false;
        public bool CreateDefaultPatient { get; set; } = false;

        private static readonly string ConfigDirectory = Path.Combine(
            GetProjectRoot(),
            "Config"
        );

        private static string GetProjectRoot()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dir = new DirectoryInfo(baseDir);
            while (dir != null && !File.Exists(Path.Combine(dir.FullName, "SaintJosephsHospitalHealthMonitorApp.csproj")))
            {
                dir = dir.Parent;
            }
            return dir?.FullName ?? baseDir;
        }

        private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "debug_settings.json");

        public void SaveToJson()
        {
            try
            {
                if (!Directory.Exists(ConfigDirectory))
                {
                    Directory.CreateDirectory(ConfigDirectory);
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(ConfigFilePath, json);

                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Settings saved to JSON: {ConfigFilePath}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Failed to save JSON: {ex.Message}");
            }
        }

        public static DebugConfig LoadFromJson()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    DebugConfig config = JsonSerializer.Deserialize<DebugConfig>(json);
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Settings loaded from JSON: {ConfigFilePath}");
                    return config;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("[DebugConfig] JSON file not found, using defaults");
                    return new DebugConfig();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Failed to load JSON: {ex.Message}");
                return new DebugConfig();
            }
        }

        public static bool JsonConfigExists()
        {
            return File.Exists(ConfigFilePath);
        }

        public static void DeleteJsonConfig()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    File.Delete(ConfigFilePath);
                    System.Diagnostics.Debug.WriteLine("[DebugConfig] JSON config deleted");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Failed to delete JSON: {ex.Message}");
            }
        }

        public static string GetConfigFilePath()
        {
            return ConfigFilePath;
        }
    }
}