using MySqlConnector;
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

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class EditUserForm : Form
    {
        private int userId;

        public EditUserForm(int uId)
        {
            userId = uId;
            InitializeComponent();
            LoadUserData();
        }

        //nothing much here this just meant for editing the user no need for explanation
        private void LoadUserData()
        {
            string query = "SELECT name, email, age, gender, role FROM Users WHERE user_id = @userId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["name"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtAge.Text = row["age"].ToString();
                cmbGender.SelectedItem = row["gender"].ToString();
                cmbRole.SelectedItem = row["role"].ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE Users 
                               SET name = @name, email = @email, age = @age, gender = @gender, role = @role
                               WHERE user_id = @userId";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@name", txtName.Text),
                    new MySqlParameter("@email", txtEmail.Text),
                    new MySqlParameter("@age", int.Parse(txtAge.Text)),
                    new MySqlParameter("@gender", cmbGender.SelectedItem.ToString()),
                    new MySqlParameter("@role", cmbRole.SelectedItem.ToString()),
                    new MySqlParameter("@userId", userId));

                MessageBox.Show("User information updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}