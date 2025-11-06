using System;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoadingScreenForm());
        }
    }
}