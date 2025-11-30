using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class InputDialog : Form
    {
        public string InputText => txtInput.Text;

        public string InputValue { get; internal set; }

        public InputDialog(string title, string prompt, string defaultText = "")
        {
            InitializeComponent();

            Text = title;
            lblPrompt.Text = prompt;
            txtInput.Text = defaultText;
        }

        public static string Show(string title, string prompt, string defaultText = "")
        {
            using (InputDialog dialog = new InputDialog(title, prompt, defaultText))
            {
                return dialog.ShowDialog() == DialogResult.OK ? dialog.InputText : null;
            }
        }
    }
}