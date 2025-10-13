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

        //this retrieves only available and active doctors showing name and specialization
        //theres nothing much here (in the name itself para pang assign lang to ng doctor if available lang siya o hindi)
        //this is not finished yet btw need to connect it
        private void LoadDoctors()
        {
            string query = @"SELECT d.doctor_id, u.name + ' - ' + d.specialization AS doctor_info
                           FROM Doctors d
                           INNER JOIN Users u ON d.user_id = u.user_id
                           WHERE d.is_available = 1 AND u.is_active = 1
                           ORDER BY u.name";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbDoctor.DisplayMember = "doctor_info";
            cmbDoctor.ValueMember = "doctor_id";
            cmbDoctor.DataSource = dt;
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

                string query = @"UPDATE PatientQueue 
                               SET doctor_id = @doctorId 
                               WHERE queue_id = @queueId";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@queueId", queueId));

                MessageBox.Show("Doctor assigned successfully!", "Success",
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