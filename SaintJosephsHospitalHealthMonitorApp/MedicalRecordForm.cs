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

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class MedicalRecordForm : Form
    {
        private int patientId;
        private int doctorId;
        private string patientName;

        public MedicalRecordForm(int pId, int dId, string pName)
        {
            patientId = pId;
            doctorId = dId;
            patientName = pName;
            InitializeComponent();
            lblPatientName.Text = $"Patient: {patientName}";
        }
        //nothing much here itself just to handle medical records
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Please enter a diagnosis.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO MedicalRecords 
                               (patient_id, doctor_id, diagnosis, prescription, lab_tests)
                               VALUES (@patientId, @doctorId, @diagnosis, @prescription, @labTests)";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@diagnosis", txtDiagnosis.Text),
                    new MySqlParameter("@prescription", txtPrescription.Text),
                    new MySqlParameter("@labTests", txtLabTests.Text));

                MessageBox.Show("Medical record saved successfully!", "Success",
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
