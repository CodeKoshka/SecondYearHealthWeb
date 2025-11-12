using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public class InputDialog : Form
    {
        private Label lblPrompt;
        private TextBox txtInput;
        private Button btnOk;
        private Button btnCancel;

        public string InputText => txtInput.Text;

        public string InputValue { get; internal set; }

        public InputDialog(string title, string prompt, string defaultText = "")
        {
            Text = title;
            Width = 400;
            Height = 180;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            lblPrompt = new Label
            {
                Text = prompt,
                AutoSize = true,
                Location = new Point(15, 15)
            };

            txtInput = new TextBox
            {
                Text = defaultText,
                Location = new Point(15, 45),
                Width = 350
            };

            btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(200, 90),
                Width = 75
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(290, 90),
                Width = 75
            };

            Controls.Add(lblPrompt);
            Controls.Add(txtInput);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);

            AcceptButton = btnOk;
            CancelButton = btnCancel;
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
