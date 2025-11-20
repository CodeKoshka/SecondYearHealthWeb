using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class AssignDoctorForm : Form
    {
        private int queueId;
        private string patientName;

        public AssignDoctorForm(int qId, string pName)
        {
            queueId = qId;
            patientName = pName;
            InitializeComponent();
            lblPatientInfo.Text = $"Assigning doctor for: {patientName}";
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            string query = @"
        SELECT 
            d.doctor_id, 
            CONCAT(u.name, ' - ', d.specialization, 
                CASE 
                    WHEN (SELECT COUNT(*) FROM patientqueue 
                          WHERE doctor_id = d.doctor_id 
                          AND queue_date = CURDATE() 
                          AND status IN ('Called', 'In Progress')) > 0 
                    THEN ' (Busy with patient)'
                    ELSE ''
                END
            ) AS doctor_info,
            CASE 
                WHEN (SELECT COUNT(*) FROM patientqueue 
                      WHERE doctor_id = d.doctor_id 
                      AND queue_date = CURDATE() 
                      AND status IN ('Called', 'In Progress')) > 0 
                THEN 0 
                ELSE 1 
            END as is_available
        FROM Doctors d
        INNER JOIN Users u ON d.user_id = u.user_id
        WHERE u.is_active = 1
        ORDER BY is_available DESC, u.name";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            DataView dv = new DataView(dt);
            dv.RowFilter = "is_available = 1";

            if (dv.Count == 0)
            {
                MessageBox.Show(
                    "❌ NO AVAILABLE DOCTORS\n\n" +
                    "All doctors are currently busy with patients.\n\n" +
                    "Please wait for a doctor to complete their current consultation.",
                    "No Doctors Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            cmbDoctor.DisplayMember = "doctor_info";
            cmbDoctor.ValueMember = "doctor_id";
            cmbDoctor.DataSource = dv.ToTable();
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int doctorId = Convert.ToInt32(cmbDoctor.SelectedValue);

                string doctorInfo = cmbDoctor.Text;
                string doctorName = doctorInfo.Split('-')[0].Trim();

                DialogResult confirm = MessageBox.Show(
                    $"📋 ASSIGN DOCTOR\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Doctor: {doctorName}\n\n" +
                    "The doctor will be marked as busy until this patient is completed.\n\n" +
                    "Proceed with assignment?",
                    "Confirm Assignment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                string assignQuery = @"
            UPDATE PatientQueue 
            SET doctor_id = @doctorId 
            WHERE queue_id = @queueId";

                DatabaseHelper.ExecuteNonQuery(assignQuery,
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@queueId", queueId));

                string updateDoctorQuery = @"
            UPDATE Doctors 
            SET is_available = 0 
            WHERE doctor_id = @doctorId";

                DatabaseHelper.ExecuteNonQuery(updateDoctorQuery,
                    new MySqlParameter("@doctorId", doctorId));

                MessageBox.Show(
                    $"✅ DOCTOR ASSIGNED\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Doctor: {doctorName}\n\n" +
                    "✓ Doctor marked as busy\n" +
                    "✓ Patient assigned to doctor\n\n" +
                    "The doctor will be available again after completing this patient.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
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