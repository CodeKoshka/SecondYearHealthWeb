namespace SaintJosephsHospitalHealthMonitorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database initialization error: " + ex.Message);
            }

            Application.Run(new LoginForm());
        }
    }
}
