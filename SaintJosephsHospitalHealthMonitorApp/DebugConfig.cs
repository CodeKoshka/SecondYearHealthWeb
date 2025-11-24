using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

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

        public bool AllowCreateAdmin { get; set; } = true;
        public bool AllowCreateReceptionist { get; set; } = true;
        public bool AllowCreateDoctor { get; set; } = true;
        public bool AllowCreatePharmacist { get; set; } = false;
        public bool AllowCreatePatient { get; set; } = true;

        private static string _cachedConfigDirectory = null;
        private static string _cachedConfigFilePath = null;

        private static string GetProjectConfigDirectory()
        {
            if (_cachedConfigDirectory != null && Directory.Exists(_cachedConfigDirectory))
            {
                return _cachedConfigDirectory;
            }

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dir = new DirectoryInfo(baseDir);

            while (dir != null)
            {
                string csprojPath = Path.Combine(dir.FullName, "SaintJosephsHospitalHealthMonitorApp.csproj");
                if (File.Exists(csprojPath))
                {
                    string configDir = Path.Combine(dir.FullName, "Config");
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Found project root via .csproj: {configDir}");
                    _cachedConfigDirectory = configDir;
                    return configDir;
                }

                dir = dir.Parent;
            }

            dir = new DirectoryInfo(baseDir);
            while (dir != null)
            {
                string loginFormPath = Path.Combine(dir.FullName, "LoginForm.cs");
                string databaseHelperPath = Path.Combine(dir.FullName, "DatabaseHelper.cs");

                if (File.Exists(loginFormPath) || File.Exists(databaseHelperPath))
                {
                    string configDir = Path.Combine(dir.FullName, "Config");
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Found project root via source files: {configDir}");
                    _cachedConfigDirectory = configDir;
                    return configDir;
                }

                dir = dir.Parent;
            }

            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "SaintJosephsHospital",
                "Config"
            );

            System.Diagnostics.Debug.WriteLine($"[DebugConfig] Using AppData fallback: {appDataPath}");
            _cachedConfigDirectory = appDataPath;
            return appDataPath;
        }

        private static string ConfigDirectory
        {
            get
            {
                if (_cachedConfigDirectory == null)
                {
                    _cachedConfigDirectory = GetProjectConfigDirectory();
                }
                return _cachedConfigDirectory;
            }
        }

        private static string ConfigFilePath
        {
            get
            {
                if (_cachedConfigFilePath == null)
                {
                    _cachedConfigFilePath = Path.Combine(ConfigDirectory, "debug_settings.json");
                }
                return _cachedConfigFilePath;
            }
        }

        public void SaveToJson()
        {
            int retryCount = 0;
            int maxRetries = 3;
            Exception lastException = null;

            while (retryCount < maxRetries)
            {
                try
                {
                    string directory = ConfigDirectory;
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                        System.Diagnostics.Debug.WriteLine($"[DebugConfig] Created config directory: {directory}");
                    }

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize(this, options);

                    string filePath = ConfigFilePath;
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Attempting to save to: {filePath}");

                    string tempFile = filePath + ".tmp";
                    File.WriteAllText(tempFile, json);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    File.Move(tempFile, filePath);

                    if (File.Exists(filePath))
                    {
                        string readBack = File.ReadAllText(filePath);
                        System.Diagnostics.Debug.WriteLine($"[DebugConfig] ✓ Settings saved successfully!");
                        System.Diagnostics.Debug.WriteLine($"[DebugConfig] File size: {new FileInfo(filePath).Length} bytes");
                        System.Diagnostics.Debug.WriteLine($"[DebugConfig] Content preview: {readBack.Substring(0, Math.Min(100, readBack.Length))}...");
                        return; 
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    lastException = ex;
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Access denied on attempt {retryCount + 1}: {ex.Message}");
                }
                catch (IOException ex)
                {
                    lastException = ex;
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] IO error on attempt {retryCount + 1}: {ex.Message}");
                    System.Threading.Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Error on attempt {retryCount + 1}: {ex.Message}");
                }

                retryCount++;
            }

            string errorMsg = $"Failed to save settings after {maxRetries} attempts.\n\n" +
                            $"Path: {ConfigFilePath}\n" +
                            $"Error: {lastException?.Message}\n\n" +
                            "Please check:\n" +
                            "1. File permissions\n" +
                            "2. Disk space\n" +
                            "3. Antivirus settings";

            System.Diagnostics.Debug.WriteLine($"[DebugConfig] ✗ {errorMsg}");
            throw new Exception(errorMsg, lastException);
        }

        public static DebugConfig LoadFromJson()
        {
            try
            {
                string filePath = ConfigFilePath;

                if (File.Exists(filePath))
                {
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Loading from: {filePath}");

                    string json = File.ReadAllText(filePath);

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        System.Diagnostics.Debug.WriteLine("[DebugConfig] Config file is empty, creating new default config");
                        var newConfig = new DebugConfig();
                        newConfig.SaveToJson();
                        return newConfig;
                    }

                    DebugConfig config = JsonSerializer.Deserialize<DebugConfig>(json);
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] ✓ Settings loaded successfully");
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] EnableAdmin={config.EnableAdmin}, EnableDoctor={config.EnableDoctor}");
                    return config;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Config file not found at: {filePath}");
                    System.Diagnostics.Debug.WriteLine("[DebugConfig] Creating new config with defaults");

                    var defaultConfig = new DebugConfig();
                    defaultConfig.SaveToJson();

                    return defaultConfig;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] ✗ Failed to load JSON: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Stack trace: {ex.StackTrace}");
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] Attempted path: {ConfigFilePath}");

                return new DebugConfig();
            }
        }

        public static bool JsonConfigExists()
        {
            string path = ConfigFilePath;
            bool exists = File.Exists(path);
            System.Diagnostics.Debug.WriteLine($"[DebugConfig] Config exists check: {exists} at {path}");

            if (exists)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(path);
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] File size: {fileInfo.Length} bytes");
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Last modified: {fileInfo.LastWriteTime}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Could not read file info: {ex.Message}");
                }
            }

            return exists;
        }

        public static void DeleteJsonConfig()
        {
            try
            {
                string path = ConfigFilePath;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] ✓ Config deleted from: {path}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[DebugConfig] Config file does not exist: {path}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DebugConfig] ✗ Failed to delete JSON: {ex.Message}");
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
            string configDir = ConfigDirectory;
            string configFile = ConfigFilePath;

            return $@"Debug Config Diagnostic Info:
            ========================================
            Base Directory: {AppDomain.CurrentDomain.BaseDirectory}
            Config Directory: {configDir}
            Config File Path: {configFile}
            Config File Exists: {File.Exists(configFile)}
            Config Directory Exists: {Directory.Exists(configDir)}
            Directory Writable: {IsDirectoryWritable(configDir)}
            File Size: {(File.Exists(configFile) ? new FileInfo(configFile).Length.ToString() + " bytes" : "N/A")}
            Last Modified: {(File.Exists(configFile) ? new FileInfo(configFile).LastWriteTime.ToString() : "N/A")}
            ========================================";
        }

        private static bool IsDirectoryWritable(string dirPath)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                string testFile = Path.Combine(dirPath, $"test_write_{Guid.NewGuid()}.tmp");
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}