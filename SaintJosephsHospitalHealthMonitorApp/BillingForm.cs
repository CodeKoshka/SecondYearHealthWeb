using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
            LoadPatients();
        }
        //same as assigndoctorForm theres nothing much here need to be connected aswell
        //this is to fetch all patients with their names for dropdown selection
        private void LoadPatients()
        {
            string query = @"SELECT p.patient_id, u.name FROM Patients p
                           INNER JOIN Users u ON p.user_id = u.user_id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbPatient.DisplayMember = "name";
            cmbPatient.ValueMember = "patient_id";
            cmbPatient.DataSource = dt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue == null || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                int patientId = Convert.ToInt32(cmbPatient.SelectedValue);

                string query = @"INSERT INTO Billing (patient_id, amount, description, status)
                               VALUES (@patientId, @amount, @description, 'Pending')";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@amount", amount),
                    new MySqlParameter("@description", txtDescription.Text));

                MessageBox.Show("Invoice created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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