using System;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeConfigFile();

            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Initialization Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new LoginForm());
        }
        //this was made so config starts to be made instantly instead of going to debug first to make it
        private static void InitializeConfigFile()
        {
            try
            {
                if (!DebugConfig.JsonConfigExists())
                {
                    System.Diagnostics.Debug.WriteLine("[Program] Config file not found. Creating with default settings...");

                    DebugConfig defaultConfig = new DebugConfig();
                    defaultConfig.SaveToJson();

                    System.Diagnostics.Debug.WriteLine($"[Program] Config file created at: {DebugConfig.GetConfigFilePath()}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[Program] Config file already exists at: {DebugConfig.GetConfigFilePath()}");

                    DebugConfig.LoadFromJson();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Program] Failed to initialize config file: {ex.Message}");
            }
        }
    }
}