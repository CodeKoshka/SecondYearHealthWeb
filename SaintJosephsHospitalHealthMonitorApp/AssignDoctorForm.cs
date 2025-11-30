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
            ApplyStyles();
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

                ConfigureDataGridViewColumns();

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
                ApplyStyles();

                if (dgvDoctors.Columns.Contains("doctor_id"))
                    dgvDoctors.Columns["doctor_id"].Visible = false;

                if (dgvDoctors.Columns.Contains("user_id"))
                    dgvDoctors.Columns["user_id"].Visible = false;

                if (dgvDoctors.Columns.Contains("doctor_name"))
                {
                    dgvDoctors.Columns["doctor_name"].HeaderText = "Doctor Name";
                    dgvDoctors.Columns["doctor_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvDoctors.Columns["doctor_name"].Resizable = DataGridViewTriState.False;
                }

                if (dgvDoctors.Columns.Contains("specialization"))
                {
                    dgvDoctors.Columns["specialization"].HeaderText = "Specialization";
                    dgvDoctors.Columns["specialization"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvDoctors.Columns["specialization"].Resizable = DataGridViewTriState.False;
                }

                if (dgvDoctors.Columns.Contains("duty_status"))
                {
                    dgvDoctors.Columns["duty_status"].HeaderText = "Duty Status";
                    dgvDoctors.Columns["duty_status"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvDoctors.Columns["duty_status"].Resizable = DataGridViewTriState.False;
                }

                if (dgvDoctors.Columns.Contains("availability_status"))
                {
                    dgvDoctors.Columns["availability_status"].HeaderText = "Availability";
                    dgvDoctors.Columns["availability_status"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvDoctors.Columns["availability_status"].Resizable = DataGridViewTriState.False;
                }

                foreach (DataGridViewColumn column in dgvDoctors.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Resizable = DataGridViewTriState.False;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Column configuration error: {ex.Message}", "Debug Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplyStyles()
        {
            dgvDoctors.AutoGenerateColumns = true;
            dgvDoctors.AllowUserToAddRows = false;
            dgvDoctors.AllowUserToDeleteRows = false;
            dgvDoctors.ReadOnly = true;
            dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctors.MultiSelect = false;
            dgvDoctors.RowHeadersVisible = false;
            dgvDoctors.EnableHeadersVisualStyles = false;
            dgvDoctors.AllowUserToResizeRows = false;
            dgvDoctors.AllowUserToOrderColumns = false;
            dgvDoctors.AllowUserToResizeColumns = false;
            dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDoctors.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 153, 225);
            dgvDoctors.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoctors.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDoctors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDoctors.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 153, 225);
            dgvDoctors.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvDoctors.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgvDoctors.ColumnHeadersHeight = 50;
            dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvDoctors.DefaultCellStyle.BackColor = Color.White;
            dgvDoctors.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
            dgvDoctors.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255); 
            dgvDoctors.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44); 
            dgvDoctors.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDoctors.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
            dgvDoctors.RowTemplate.Height = 45;

            dgvDoctors.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvDoctors.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255); 
            dgvDoctors.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44); 

            dgvDoctors.GridColor = Color.FromArgb(226, 232, 240);
            dgvDoctors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDoctors.BackgroundColor = Color.White;
            dgvDoctors.BorderStyle = BorderStyle.None;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgvDoctors, new object[] { true });

            dgvDoctors.RowPostPaint -= DgvDoctors_RowPostPaint;
            dgvDoctors.RowPostPaint += DgvDoctors_RowPostPaint;

            dgvDoctors.RowPrePaint -= DgvDoctors_RowPrePaint;
            dgvDoctors.RowPrePaint += DgvDoctors_RowPrePaint;
        }

        private void DgvDoctors_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvDoctors.Rows.Count) return;

                DataGridViewRow row = dgvDoctors.Rows[e.RowIndex];

                if (row.Selected)
                {
                    int slabWidth = 10;

                    using (SolidBrush slabBrush = new SolidBrush(Color.FromArgb(52, 152, 219)))
                    {
                        Rectangle slabRect = new Rectangle(
                            e.RowBounds.Left,
                            e.RowBounds.Top,
                            slabWidth,
                            e.RowBounds.Height
                        );

                        e.Graphics.FillRectangle(slabBrush, slabRect);
                    }
                }
            }
            catch { }
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
                }
                else if (dutyStatus == "On Duty" && availStatus == "Busy")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230);
                }
                else 
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 245);
                }

                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255);
                row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
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

                string priorityQuery = "SELECT priority FROM patientqueue WHERE queue_id = @queueId";
                object priorityResult = DatabaseHelper.ExecuteScalar(priorityQuery,
                    new MySqlParameter("@queueId", queueId));

                string patientPriority = priorityResult?.ToString() ?? "Normal";

                if (dutyStatus == "Off Duty")
                {
                    if (patientPriority.Equals("Normal", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(
                            $"❌ CANNOT ASSIGN OFF-DUTY DOCTOR\n\n" +
                            $"Doctor: {doctorName}\n" +
                            $"Status: Off Duty\n" +
                            $"Patient Priority: {patientPriority}\n\n" +
                            "⚠️ RESTRICTION:\n" +
                            "Off-duty doctors can only be assigned to:\n" +
                            "• Emergency patients\n" +
                            "• Urgent patients\n\n" +
                            "For Normal priority patients:\n" +
                            "• Please select an on-duty doctor, OR\n" +
                            "• Change patient priority to Urgent/Emergency first",
                            "Off-Duty Doctor Restriction",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        $"⚠️ ASSIGN OFF-DUTY DOCTOR\n\n" +
                        $"Doctor: {doctorName}\n" +
                        $"Status: Off Duty\n" +
                        $"Patient Priority: {patientPriority}\n\n" +
                        "This doctor is currently off duty, but the patient priority\n" +
                        $"is {patientPriority}, which allows assignment.\n\n" +
                        "⚠️ The doctor will need to come on duty to see the patient.\n\n" +
                        "Do you want to proceed with this assignment?",
                        "Off-Duty Doctor - Urgent/Emergency",
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
                    $"Patient Priority: {patientPriority}\n" +
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
                SET doctor_id = @doctorId,
                status = CASE WHEN status = 'Waiting' THEN 'Waiting' ELSE status END
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

                string successMessage = $"✅ DOCTOR ASSIGNED\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Patient Priority: {patientPriority}\n" +
                    $"Doctor: {doctorName}\n\n" +
                    "✓ Doctor marked as busy\n" +
                    "✓ Patient assigned to doctor\n\n";

                if (dutyStatus == "Off Duty")
                {
                    successMessage += "⚠️ NOTE: Doctor is off duty and will need to come on duty\n" +
                                    "to see this patient.\n\n";
                }

                successMessage += "The doctor will be available again after completing this patient.";

                MessageBox.Show(
                    successMessage,
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