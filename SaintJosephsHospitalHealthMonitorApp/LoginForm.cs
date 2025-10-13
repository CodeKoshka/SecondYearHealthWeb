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

            //this trys to authenticate the user using the provided email and password based on admindashboard
            //the User.Authenticate will return a User object if successful if failed it will return null
            User user = User.Authenticate(txtEmail.Text.Trim(), txtPassword.Text);

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Name}!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this open appropriate dashboard based on role
                //this is also the bridge between the different dashboards
                Form dashboard = null;
                switch (user.Role)
                {
                    case "Admin":
                        dashboard = new AdminDashboard(user);
                        break;
                    case "Doctor":
                        dashboard = new DoctorDashboard(user);
                        break;
                    case "Patient":
                        dashboard = new PatientDashboard(user);
                        break;
                    case "Secretary":
                        dashboard = new SecretaryDashboard(user);
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