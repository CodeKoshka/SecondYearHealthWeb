using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySqlConnector;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both email and password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = User.Authenticate(txtEmail.Text.Trim(), txtPassword.Text);

            if (user != null)
            {
                if (user.Role != "Headadmin" &&
                    user.Role != "Admin" &&
                    user.Role != "Receptionist" &&
                    user.Role != "Doctor" &&
                    user.Role != "Pharmacist")
                {
                    MessageBox.Show("Invalid role for login. Patients cannot login here.", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Welcome, {user.Name}!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form dashboard = null;
                switch (user.Role)
                {
                    case "Headadmin":
                        dashboard = new AdminDashboard(user);
                        break;
                    case "Admin":
                        dashboard = new AdminDashboard(user);
                        break;
                    case "Receptionist":
                        dashboard = new ReceptionistDashboard(user);
                        break;
                    case "Doctor":
                        dashboard = new DoctorDashboard(user);
                        break;
                    case "Pharmacist":
                        dashboard = new PharmacyStaffDashboard(user);
                        break;
                }

                if (dashboard != null)
                {
                    this.Hide();
                    dashboard.FormClosed += (s, args) => this.Close();
                    dashboard.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}