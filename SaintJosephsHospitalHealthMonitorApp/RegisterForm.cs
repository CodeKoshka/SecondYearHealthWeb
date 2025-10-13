using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SaintJosephsHospitalHealthMonitorApp
{
    /*
    some code here are no longer use due to how a hospital system actually works and have to redo 
    some of the program so its just left behind
    dont wanna touch it yet since if its not broken dont touch it
    ill revisit it when the entire program is fix and working just incase
    */
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        //this handles the changing role selection in the combo box
        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this shows patient specific panel if Patient is selected
            if (cmbRole.SelectedItem.ToString() == "Patient")
            {
                panelPatientInfo.Visible = true;
                panelDoctorInfo.Visible = false;
            }
            else
            {
                panelPatientInfo.Visible = false;
                panelDoctorInfo.Visible = true;
            }
        }

        //this handles registration when Register button is clicked
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //this inserts a new user into the users table
                string insertUser = @"INSERT INTO Users (name, role, email, password, age, gender) 
                                     VALUES (@name, @role, @email, @password, @age, @gender);
                                     SELECT SCOPE_IDENTITY();";

                object result = DatabaseHelper.ExecuteScalar(insertUser,
                    new MySqlParameter("@name", txtName.Text),
                    new MySqlParameter("@role", cmbRole.SelectedItem.ToString()),
                    new MySqlParameter("@email", txtEmail.Text),
                    new MySqlParameter("@password", txtPassword.Text),
                    new MySqlParameter("@age", int.Parse(txtAge.Text)),
                    new MySqlParameter("@gender", cmbGender.SelectedItem.ToString()));

                int userId = Convert.ToInt32(result);

                //this inserts the role specific data
                if (cmbRole.SelectedItem.ToString() == "Patient")
                {
                    string insertPatient = @"INSERT INTO Patients (user_id, blood_type, allergies) 
                                           VALUES (@userId, @bloodType, @allergies)";
                    DatabaseHelper.ExecuteNonQuery(insertPatient,
                        new MySqlParameter("@userId", userId),
                        new MySqlParameter("@bloodType", txtBloodType.Text),
                        new MySqlParameter("@allergies", txtAllergies.Text));
                }
                else
                {
                    string insertDoctor = @"INSERT INTO Doctors (user_id, specialization) 
                                          VALUES (@userId, @specialization)";
                    DatabaseHelper.ExecuteNonQuery(insertDoctor,
                        new MySqlParameter("@userId", userId),
                        new MySqlParameter("@specialization", txtSpecialization.Text));
                }

                MessageBox.Show("Registration successful! You can now login.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}