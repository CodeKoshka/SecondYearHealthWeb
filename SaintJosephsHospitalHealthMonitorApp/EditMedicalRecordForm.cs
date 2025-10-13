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
    public partial class EditMedicalRecordForm : Form
    {
        private int recordId;

        public EditMedicalRecordForm(int rId, string diagnosis, string prescription, string labTests)
        {
            recordId = rId;
            InitializeComponent();
            txtDiagnosis.Text = diagnosis;
            txtPrescription.Text = prescription;
            txtLabTests.Text = labTests;
        }
        //nothing much here this just meant for editing medicalrecords no need for explanation
        //this just updates the medicalrecords table
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE medicalrecords 
                               SET diagnosis = @diagnosis, prescription = @prescription, lab_tests = @labTests
                               WHERE record_id = @recordId";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@diagnosis", txtDiagnosis.Text),
                    new MySqlParameter("@prescription", txtPrescription.Text),
                    new MySqlParameter("@labTests", txtLabTests.Text),
                    new MySqlParameter("@recordId", recordId));

                MessageBox.Show("Medical record updated successfully!", "Success",
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