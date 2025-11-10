using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ViewOrderDetailsForm : Form
    {
        private int orderId;

        public ViewOrderDetailsForm(int oId)
        {
            InitializeComponent();
            orderId = oId;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                string query = @"
                    SELECT 
                        mo.order_id,
                        mo.patient_id,
                        u_patient.name AS patient_name,
                        u_doctor.name AS doctor_name,
                        mo.medicine_name,
                        mo.dosage,
                        mo.frequency,
                        mo.quantity,
                        mo.priority,
                        mo.status,
                        mo.order_date,
                        mo.validated_date,
                        mo.dispensed_date,
                        IFNULL(u_validated.name, '-') AS validated_by,
                        IFNULL(u_dispensed.name, '-') AS dispensed_by
                    FROM MedicationOrders mo
                    INNER JOIN Patients p ON mo.patient_id = p.patient_id
                    INNER JOIN Users u_patient ON p.user_id = u_patient.user_id
                    INNER JOIN Doctors d ON mo.doctor_id = d.doctor_id
                    INNER JOIN Users u_doctor ON d.user_id = u_doctor.user_id
                    LEFT JOIN Users u_validated ON mo.validated_by = u_validated.user_id
                    LEFT JOIN Users u_dispensed ON mo.dispensed_by = u_dispensed.user_id
                    WHERE mo.order_id = @orderId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@orderId", orderId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    
                    lblOrderIdValue.Text = row["order_id"].ToString();
                    lblPatientValue.Text = row["patient_name"].ToString();
                    lblPatientIdValue.Text = row["patient_id"].ToString();
                    lblDoctorValue.Text = row["doctor_name"].ToString();
                    lblMedicineValue.Text = row["medicine_name"].ToString();
                    lblDosageValue.Text = row["dosage"].ToString();
                    lblFrequencyValue.Text = row["frequency"].ToString();
                    lblQuantityValue.Text = row["quantity"].ToString();
                    lblOrderDateValue.Text = Convert.ToDateTime(row["order_date"]).ToString("yyyy-MM-dd HH:mm");

                    
                    lblStatusValue.Text = row["status"].ToString();
                    string status = row["status"].ToString();
                    if (status == "Pending")
                        lblStatusValue.ForeColor = Color.Orange;
                    else if (status == "Validated")
                        lblStatusValue.ForeColor = Color.Blue;
                    else if (status == "Dispensed")
                        lblStatusValue.ForeColor = Color.Green;
                    else if (status == "Completed")
                        lblStatusValue.ForeColor = Color.DarkGreen;
                    else if (status == "Cancelled")
                        lblStatusValue.ForeColor = Color.Red;

                    
                    lblPriorityValue.Text = row["priority"].ToString();
                    string priority = row["priority"].ToString();
                    if (priority == "Emergency")
                        lblPriorityValue.ForeColor = Color.Red;
                    else if (priority == "Urgent")
                        lblPriorityValue.ForeColor = Color.OrangeRed;
                    else
                        lblPriorityValue.ForeColor = Color.Black;
                }
                else
                {
                    MessageBox.Show("Order not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}