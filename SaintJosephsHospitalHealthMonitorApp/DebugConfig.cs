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

        private static string GetProjectConfigDirectory()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            DirectoryInfo dir = new DirectoryInfo(baseDir);

            while (dir != null)
            {
                string csprojPath = Path.Combine(dir.FullName, "SaintJosephsHospitalHealthMonitorApp.csproj");
                if (File.Exists(csprojPath))
                {
                    string configDir = Path.Combine(dir.FullName, "Config");
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Found project root with .csproj: {configDir}");
                    return configDir;
                }

                string loginFormPath = Path.Combine(dir.FullName, "LoginForm.cs");
                string databaseHelperPath = Path.Combine(dir.FullName, "DatabaseHelper.cs");

                if (File.Exists(loginFormPath) || File.Exists(databaseHelperPath))
                {
                    string configDir = Path.Combine(dir.FullName, "Config");
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Found project root by source files: {configDir}");
                    return configDir;
                }

                dir = dir.Parent;
            }
            string fallbackConfigDir = Path.Combine(baseDir, "Config");
            System.Diagnostics.Debug.WriteLine($"[DebugConfig] Project root not found, using fallback: {fallbackConfigDir}");
            return fallbackConfigDir;
        }

        private static readonly string ConfigDirectory = GetProjectConfigDirectory();
        private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "debug_settings.json");

        public void SaveToJson()
        {
            try
            {
                if (!Directory.Exists(ConfigDirectory))
                {
                    Directory.CreateDirectory(ConfigDirectory);
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Created config directory: {ConfigDirectory}");
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(ConfigFilePath, json);

                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Settings saved to: {ConfigFilePath}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Failed to save JSON: {ex.Message}");
                throw;
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
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Settings loaded from: {ConfigFilePath}");
                    return config;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Config file not found at: {ConfigFilePath}");
                    System.Diagnostics.Debug.WriteLine("[DebugConfig] Creating new config with defaults");

                    var defaultConfig = new DebugConfig();
                    defaultConfig.SaveToJson();

                    return defaultConfig;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Failed to load JSON: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Attempted path: {ConfigFilePath}");
                return new DebugConfig();
            }
        }

        public static bool JsonConfigExists()
        {
            bool exists = File.Exists(ConfigFilePath);
            System.Diagnostics.Debug.WriteLine($"[DebugConfig] Config exists check: {exists} at {ConfigFilePath}");
            return exists;
        }

        public static void DeleteJsonConfig()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    File.Delete(ConfigFilePath);
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Config deleted from: {ConfigFilePath}");
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

        public static string GetConfigDirectory()
        {
            return ConfigDirectory;
        }

        public static string GetDiagnosticInfo()
        {
            return $@"Debug Config Diagnostic Info:
                    ========================================
                    Base Directory: {AppDomain.CurrentDomain.BaseDirectory}
                    Config Directory: {ConfigDirectory}
                    Config File Path: {ConfigFilePath}
                    Config File Exists: {File.Exists(ConfigFilePath)}
                    Config Directory Exists: {Directory.Exists(ConfigDirectory)}
                    ========================================";
        }
    }
}