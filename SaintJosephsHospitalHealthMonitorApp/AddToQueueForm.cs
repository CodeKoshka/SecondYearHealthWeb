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
    public partial class AddToQueueForm : Form
    {
        private int registeredBy;

        public AddToQueueForm(int userId)
        {
            registeredBy = userId;
            InitializeComponent();
            LoadPatients();
        }

        // this is to Load all active patients from the database into the combobox
        // it also joins the Patients table with the Users table to get patient name and age
        private void LoadPatients()
        {
            string query = @"SELECT p.patient_id, u.name + ' (Age: ' + CAST(u.age AS NVARCHAR) + ')' AS patient_info
                           FROM Patients p
                           INNER JOIN Users u ON p.user_id = u.user_id
                           WHERE u.is_active = 1
                           ORDER BY u.name";

            //this executse the query and store results in a DataTable
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbPatient.DisplayMember = "patient_info";
            cmbPatient.ValueMember = "patient_id";
            cmbPatient.DataSource = dt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int patientId = Convert.ToInt32(cmbPatient.SelectedValue);

                //this is to check if patient is already in queue today
                string checkQuery = @"SELECT COUNT(*) FROM PatientQueue 
                                    WHERE patient_id = @patientId 
                                    AND queue_date = CAST(GETDATE() AS DATE) 
                                    AND status IN ('Waiting', 'Called')";

                //this is the executeScalar returns one value (located yung method sa database helper)
                int inQueue = (int)DatabaseHelper.ExecuteScalar(checkQuery,
                    new MySqlParameter("@patientId", patientId));

                if (inQueue > 0)
                {
                    MessageBox.Show("This patient is already in today's queue.", "Duplicate Entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //this get next queue number
                string queueNumQuery = @"SELECT ISNULL(MAX(queue_number), 0) + 1 
                                       FROM PatientQueue 
                                       WHERE queue_date = CAST(GETDATE() AS DATE)";
                int queueNumber = (int)DatabaseHelper.ExecuteScalar(queueNumQuery);

                //this inserts the new queue entry into the database
                string insertQuery = @"INSERT INTO PatientQueue 
                                     (patient_id, queue_number, priority, reason_for_visit, registered_by)
                                     VALUES (@patientId, @queueNum, @priority, @reason, @registeredBy)";

                //executeNonQuery is used for INSERT, UPDATE, DELETE
                DatabaseHelper.ExecuteNonQuery(insertQuery,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@queueNum", queueNumber),
                    new MySqlParameter("@priority", cmbPriority.SelectedItem.ToString()),
                    new MySqlParameter("@reason", txtReason.Text),
                    new MySqlParameter("@registeredBy", registeredBy));

                MessageBox.Show($"Patient added to queue with Queue Number: {queueNumber}", "Success",
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