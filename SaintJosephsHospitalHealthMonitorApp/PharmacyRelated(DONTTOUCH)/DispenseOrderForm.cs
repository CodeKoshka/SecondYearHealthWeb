using MySqlConnector;
using SaintJosephsHospitalHealthMonitorApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class DispenseOrderForm : Form
{
    private int orderId;
    private int userId;

    public DispenseOrderForm(int oId, int uId)
    {
        orderId = oId;
        userId = uId;
        InitializeComponent();
        LoadOrderInfo();
    }

    private void LoadOrderInfo()
    {
        try
        {
            string query = @"
                    SELECT 
                        mo.*,
                        u_patient.name AS patient_name,
                        p.patient_id
                    FROM MedicationOrders mo
                    INNER JOIN Patients p ON mo.patient_id = p.patient_id
                    INNER JOIN Users u_patient ON p.user_id = u_patient.user_id
                    WHERE mo.order_id = @orderId";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@orderId", orderId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblOrderDetails.Text = $"Patient: {row["patient_name"]}\n" +
                                      $"Medicine: {row["medicine_name"]}\n" +
                                      $"Dosage: {row["dosage"]}\n" +
                                      $"Quantity: {row["quantity"]}";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            string query = @"
                    UPDATE MedicationOrders 
                    SET status = 'Dispensed',
                        dispensed_by = @userId,
                        dispensed_date = NOW()
                    WHERE order_id = @orderId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@userId", userId),
                new MySqlParameter("@orderId", orderId));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}