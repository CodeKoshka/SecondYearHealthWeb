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
        private DataTable allDoctorsData;

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
            try
            {
                string query = @"
                    SELECT 
                        d.doctor_id,
                        u.user_id,
                        u.name AS doctor_name,
                        d.specialization,
                        COALESCE(d.duty_status, 'Off Duty') as duty_status,
                        CASE 
                            WHEN (SELECT COUNT(*) FROM patientqueue 
                                  WHERE doctor_id = d.doctor_id 
                                  AND queue_date = CURDATE() 
                                  AND status IN ('Called', 'In Progress')) > 0 
                            THEN 'Busy'
                            ELSE 'Available'
                        END as availability_status
                    FROM Doctors d
                    INNER JOIN Users u ON d.user_id = u.user_id
                    WHERE u.is_active = 1
                    ORDER BY 
                        CASE COALESCE(d.duty_status, 'Off Duty') WHEN 'On Duty' THEN 1 ELSE 2 END,
                        availability_status,
                        u.name";

                allDoctorsData = DatabaseHelper.ExecuteQuery(query);

                if (allDoctorsData == null || allDoctorsData.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "⚠️ NO DOCTORS IN SYSTEM\n\n" +
                        "No doctors are registered in the hospital system.\n\n" +
                        "Please ask an administrator to register doctors first.",
                        "No Doctors Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}\n\nPlease contact support.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ApplyFilters()
        {
            try
            {
                if (allDoctorsData == null || allDoctorsData.Rows.Count == 0)
                {
                    dgvDoctors.DataSource = null;
                    lblDoctorCount.Text = "No doctors found";
                    lblDoctorCount.ForeColor = Color.FromArgb(220, 53, 69);
                    return;
                }

                DataView dv = new DataView(allDoctorsData);
                string filter = "";

                if (rbOnDuty.Checked)
                {
                    filter = "(duty_status = 'On Duty')";
                }
                else if (rbOffDuty.Checked)
                {
                    filter = "(duty_status = 'Off Duty' OR duty_status IS NULL)";
                }

                string searchText = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(searchText))
                {
                    string escapedSearch = searchText.Replace("'", "''");
                    string searchFilter = $"(doctor_name LIKE '%{escapedSearch}%' OR specialization LIKE '%{escapedSearch}%')";

                    if (!string.IsNullOrEmpty(filter))
                    {
                        filter += " AND " + searchFilter;
                    }
                    else
                    {
                        filter = searchFilter;
                    }
                }

                dv.RowFilter = filter;

                DataTable filteredTable = dv.ToTable();

                dgvDoctors.DataSource = null;
                dgvDoctors.DataSource = filteredTable;

                dgvDoctors.Refresh();

                if (filteredTable.Rows.Count == 0)
                {
                    string message = "No doctors found";
                    if (rbOnDuty.Checked)
                    {
                        message = "⚠️ No doctors currently on duty";
                    }
                    else if (rbOffDuty.Checked)
                    {
                        message = "No doctors currently off duty";
                    }

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        message += $" matching '{searchText}'";
                    }

                    lblDoctorCount.Text = message;
                    lblDoctorCount.ForeColor = Color.FromArgb(220, 53, 69);
                    return;
                }
                ConfigureDataGridViewColumns();

                int totalCount = filteredTable.Rows.Count;
                int onDutyAvailable = 0;
                int onDutyBusy = 0;
                int offDuty = 0;

                foreach (DataRow row in filteredTable.Rows)
                {
                    string dutyStatus = row["duty_status"]?.ToString() ?? "Off Duty";
                    string availStatus = row["availability_status"]?.ToString() ?? "Available";

                    if (dutyStatus == "On Duty")
                    {
                        if (availStatus == "Available")
                            onDutyAvailable++;
                        else
                            onDutyBusy++;
                    }
                    else
                    {
                        offDuty++;
                    }
                }

                string countText = $"Found {totalCount} doctor(s)";

                if (rbAll.Checked)
                {
                    countText += $" | 🟢 {onDutyAvailable} available | 🟡 {onDutyBusy} busy | 🔴 {offDuty} off duty";
                }
                else if (rbOnDuty.Checked)
                {
                    countText += $" | {onDutyAvailable} available, {onDutyBusy} busy";
                }

                lblDoctorCount.Text = countText;
                lblDoctorCount.ForeColor = onDutyAvailable > 0
                    ? Color.FromArgb(46, 204, 113)
                    : Color.FromArgb(243, 156, 18);

                if (dgvDoctors.Rows.Count > 0)
                {
                    dgvDoctors.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filters: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            try
            {
                if (dgvDoctors.Columns.Contains("doctor_id"))
                    dgvDoctors.Columns["doctor_id"].Visible = false;

                if (dgvDoctors.Columns.Contains("user_id"))
                    dgvDoctors.Columns["user_id"].Visible = false;

                if (dgvDoctors.Columns.Contains("doctor_name"))
                {
                    dgvDoctors.Columns["doctor_name"].HeaderText = "Doctor Name";
                }

                if (dgvDoctors.Columns.Contains("specialization"))
                {
                    dgvDoctors.Columns["specialization"].HeaderText = "Specialization";
                }

                if (dgvDoctors.Columns.Contains("duty_status"))
                {
                    dgvDoctors.Columns["duty_status"].HeaderText = "Duty Status";
                }

                if (dgvDoctors.Columns.Contains("availability_status"))
                {
                    dgvDoctors.Columns["availability_status"].HeaderText = "Availability";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Column configuration error: {ex.Message}", "Debug Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvDoctors_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDoctors.Columns[e.ColumnIndex].Name == "duty_status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status == "On Duty")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113);
                        e.CellStyle.Font = new Font(dgvDoctors.Font, FontStyle.Bold);
                        e.Value = "🟢 On Duty";
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69);
                        e.Value = "🔴 Off Duty";
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (dgvDoctors.Columns[e.ColumnIndex].Name == "availability_status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status == "Available")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113);
                        e.CellStyle.Font = new Font(dgvDoctors.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60);
                    }
                }
            }
        }

        private void DgvDoctors_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDoctors.Rows.Count)
            {
                DataGridViewRow row = dgvDoctors.Rows[e.RowIndex];

                string dutyStatus = row.Cells["duty_status"].Value?.ToString() ?? "Off Duty";
                string availStatus = row.Cells["availability_status"].Value?.ToString() ?? "Available";

                if (dutyStatus == "On Duty" && availStatus == "Available")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
                }
                else if (dutyStatus == "On Duty" && availStatus == "Busy")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(243, 156, 18);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 245);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 53, 69);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void RbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
                ApplyFilters();
        }

        private void RbOnDuty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnDuty.Checked)
                ApplyFilters();
        }

        private void RbOffDuty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOffDuty.Checked)
                ApplyFilters();
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            if (dgvDoctors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int doctorId = Convert.ToInt32(dgvDoctors.SelectedRows[0].Cells["doctor_id"].Value);
                string doctorName = dgvDoctors.SelectedRows[0].Cells["doctor_name"].Value.ToString();
                string dutyStatus = dgvDoctors.SelectedRows[0].Cells["duty_status"].Value.ToString();
                string availabilityStatus = dgvDoctors.SelectedRows[0].Cells["availability_status"].Value.ToString();

                if (dutyStatus == "Off Duty")
                {
                    DialogResult result = MessageBox.Show(
                        $"⚠️ DOCTOR OFF DUTY\n\n" +
                        $"Doctor: {doctorName}\n" +
                        $"Status: Off Duty\n\n" +
                        "This doctor is currently off duty.\n\n" +
                        "Do you still want to assign this patient to them?\n" +
                        "(The doctor will need to come on duty to see the patient)",
                        "Doctor Off Duty",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (result != DialogResult.Yes)
                        return;
                }

                if (availabilityStatus == "Busy")
                {
                    DialogResult result = MessageBox.Show(
                        $"⚠️ DOCTOR CURRENTLY BUSY\n\n" +
                        $"Doctor: {doctorName}\n" +
                        $"Status: Busy with another patient\n\n" +
                        "This doctor is currently attending to another patient.\n\n" +
                        "Do you still want to assign this patient to them?\n" +
                        "(The patient will wait until the doctor is available)",
                        "Doctor Busy",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (result != DialogResult.Yes)
                        return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"📋 ASSIGN DOCTOR\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Doctor: {doctorName}\n" +
                    $"Duty Status: {dutyStatus}\n" +
                    $"Availability: {availabilityStatus}\n\n" +
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

        private void DgvDoctors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnAssign_Click(sender, e);
            }
        }
    }
}