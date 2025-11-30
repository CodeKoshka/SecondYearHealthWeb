using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class SetSecurityQuestionForm : Form
    {
        private int userId;
        private string userName;
        private string userEmail;

        public SetSecurityQuestionForm(int uid, string name, string email)
        {
            InitializeComponent();
            userId = uid;
            userName = name;
            userEmail = email;
            SetupForm();
        }

        private void SetupForm()
        {
            lblUserInfo.Text = $"👤 {userName}\n📧 {userEmail}";
            
            cmbSecurityQuestion.Items.AddRange(new string[]
            {
                "What was the name of your first pet?",
                "What city were you born in?",
                "What is your mother's maiden name?",
                "What was the name of your elementary school?",
                "What is your favorite color?",
                "What is your favorite food?",
                "What was your first job?",
                "What is your favorite movie?"
            });
            
            if (cmbSecurityQuestion.Items.Count > 0)
            {
                cmbSecurityQuestion.SelectedIndex = 0;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbSecurityQuestion.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a security question.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSecurityAnswer.Text))
            {
                MessageBox.Show("Please provide an answer to the security question.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE Users 
                                SET security_question = @question,
                                    security_answer = @answer
                                WHERE user_id = @userId";
                
                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@question", cmbSecurityQuestion.SelectedItem.ToString()),
                    new MySqlParameter("@answer", txtSecurityAnswer.Text.Trim()),
                    new MySqlParameter("@userId", userId));

                MessageBox.Show(
                    "✓ Security question configured successfully!\n\n" +
                    $"User: {userName}\n" +
                    "The user can now use Forgot Password feature.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving security question: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}