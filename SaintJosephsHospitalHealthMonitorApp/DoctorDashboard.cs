using MySqlConnector;
using SaintJosephsHospitalHealthMonitorApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class DoctorDashboard : Form
    {
        private User currentUser;
        private int doctorId;
        private byte[] currentUserProfileImage;
        private System.Threading.Timer searchDebounceTimer;
        private const int SEARCH_DEBOUNCE_MS = 300;

        public DoctorDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            ApplyStyle();
            UpdateWelcomeMessage();
            ConfigureAllDataGridViews();
            InitializeUniversalSearch();
            LoadUserProfile();
            GetDoctorId();
            LoadData();
        }

        private void ApplyStyle()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();

            Color sidebarBg = Color.FromArgb(26, 32, 44);
            Color accentColor = Color.FromArgb(26, 188, 156);

            panelSidebar.BackColor = sidebarBg;
            panelHeader.BackColor = accentColor;
            panelHeader.Height = 80;

            Panel headerShadow = new Panel();
            headerShadow.Dock = DockStyle.Bottom;
            headerShadow.Height = 1;
            headerShadow.BackColor = Color.FromArgb(226, 232, 240);
            panelHeader.Controls.Add(headerShadow);
            headerShadow.BringToFront();

            lblHospitalName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHospitalName.ForeColor = Color.White;
            lblHospitalName.Location = new Point(15, 10);
            lblHospitalName.AutoSize = true;

            Label lblSubtitle = panelHeader.Controls.Find("label1", false).FirstOrDefault() as Label;
            if (lblSubtitle != null)
            {
                lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lblSubtitle.ForeColor = Color.FromArgb(255, 255, 255);
                lblSubtitle.Location = new Point(15, 38);
                lblSubtitle.AutoSize = true;
            }

            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(20, 200);
            lblWelcome.AutoSize = false;
            lblWelcome.Width = 240;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.ForeColor = Color.FromArgb(160, 174, 192);
            lblRole.Location = new Point(20, 225);
            lblRole.AutoSize = false;
            lblRole.Width = 240;
            lblRole.TextAlign = ContentAlignment.MiddleCenter;

            UpdateMenuButton(btnAppointmentsMenu, 290, "📅", "My Appointments");
            UpdateMenuButton(btnPatientsMenu, 345, "👥", "My Patients & Records");

            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);
            btnLogout.Size = new Size(250, 50);
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.Location = new Point(15, panelSidebar.Height - btnLogout.Height - 20);

            SwitchToTab(0);
        }

        private void UpdateMenuButton(Button btn, int yPos, string icon, string text)
        {
            btn.BackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.ForeColor = Color.FromArgb(226, 232, 240);
            btn.Location = new Point(15, yPos);
            btn.Size = new Size(250, 45);
            btn.Text = $"  {icon}  {text}";
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);

            btn.MouseEnter += (s, e) =>
            {
                if (btn.BackColor != Color.FromArgb(26, 188, 156))
                    btn.BackColor = Color.FromArgb(45, 55, 72);
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn.BackColor != Color.FromArgb(26, 188, 156))
                    btn.BackColor = Color.Transparent;
            };
        }

        private void UpdateWelcomeMessage()
        {
            lblWelcome.Text = $"Dr. {currentUser.Name}";
            lblRole.Text = $"Role: {currentUser.Role}";
            lblHospitalName.Text = "St. Joseph's Hospital";
        }

        private void GetDoctorId()
        {
            string query = "SELECT doctor_id FROM Doctors WHERE user_id = @userId";
            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@userId", currentUser.UserId));
            doctorId = Convert.ToInt32(result);
        }

        private void ConfigureAllDataGridViews()
        {
            if (dgvAppointments != null) ConfigureDataGridView(dgvAppointments);
            if (dgvPatients != null) ConfigureDataGridView(dgvPatients);
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 188, 156);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 235, 225);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
            dgv.RowTemplate.Height = 45;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(178, 235, 225);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);

            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            dgv.DataBindingComplete += (s, ev) =>
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            };

            dgv.RowPostPaint -= DgvUniversal_RowPostPaint;
            dgv.RowPostPaint += DgvUniversal_RowPostPaint;
        }

        private void DgvUniversal_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv == null || e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count)
                    return;

                DataGridViewRow row = dgv.Rows[e.RowIndex];

                if (row.Selected)
                {
                    Color slabColor = Color.FromArgb(52, 152, 219);
                    using (SolidBrush slabBrush = new SolidBrush(slabColor))
                    {
                        Rectangle slabRect = new Rectangle(
                            e.RowBounds.Left,
                            e.RowBounds.Top,
                            10,
                            e.RowBounds.Height
                        );
                        e.Graphics.FillRectangle(slabBrush, slabRect);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Universal RowPostPaint error: {ex.Message}");
            }
        }

        private void InitializeUniversalSearch()
        {
            InitializeSearchComponents();
            SetupSearchSuggestionsList();
        }

        private Color GetCategoryColor(string source)
        {
            switch (source)
            {
                case "Appointments": return Color.FromArgb(72, 187, 120);
                case "Patients": return Color.FromArgb(66, 153, 225);
                default: return Color.FromArgb(113, 128, 150);
            }
        }

        private string GetCategoryIcon(string source)
        {
            switch (source)
            {
                case "Appointments": return "📅";
                case "Patients": return "👤";
                default: return "📄";
            }
        }

        private void SearchSuggestionsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            int index = searchSuggestionsListBox.IndexFromPoint(e.Location);
            if (index >= 0 && index != searchSuggestionsListBox.SelectedIndex)
            {
                searchSuggestionsListBox.SelectedIndex = index;
            }
        }

        private void RefreshSearchResults()
        {
            if (!string.IsNullOrWhiteSpace(txtUniversalSearch.Text))
            {
                ShowUniversalSearchSuggestions(txtUniversalSearch.Text.Trim());
            }
        }

        private void LoadUserProfile()
        {
            string query = "SELECT profile_image FROM Users WHERE user_id = @userId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@userId", currentUser.UserId));

            if (dt.Rows.Count > 0 && dt.Rows[0]["profile_image"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])dt.Rows[0]["profile_image"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBoxProfile.Image = Image.FromStream(ms);
                    pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                SetDefaultProfileImage();
            }
        }


        private void SetDefaultProfileImage()
        {
            Bitmap placeholder = new Bitmap(80, 80);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.FromArgb(230, 240, 255));
                using (Font font = new Font("Segoe UI", 32, FontStyle.Regular))
                {
                    string icon = "👨‍⚕️";
                    SizeF textSize = g.MeasureString(icon, font);
                    g.DrawString(icon, font, Brushes.Gray,
                        (80 - textSize.Width) / 2, (80 - textSize.Height) / 2);
                }
            }
            pictureBoxProfile.Image = placeholder;
        }

        private void LoadData()
        {
            try
            {
                string queryQueue = @"
                SELECT 
                q.queue_id,
                q.patient_id,         
                q.queue_number,
                u.name AS patient_name,  
                u.age, 
                u.gender,
                q.priority,
                q.status,
                q.registered_time,
                q.called_time,
                q.completed_time
                FROM patientqueue q
                INNER JOIN Patients p ON q.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE q.doctor_id = @doctorId
                AND q.queue_date = CURDATE()
                AND q.status IN ('Called', 'In Progress')
                AND q.discharged_time IS NULL
                ORDER BY 
                CASE q.priority 
                    WHEN 'Emergency' THEN 1 
                    WHEN 'Urgent' THEN 2 
                    ELSE 3 
                END, 
                CASE 
                    WHEN q.status = 'In Progress' THEN 1
                    WHEN q.status = 'Called' THEN 2
                    ELSE 3
                END,
                q.called_time";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(queryQueue,
                    new MySqlParameter("@doctorId", doctorId));

                dgvAppointments.DataSource = dtQueue;

                string queryPatients = @"
                SELECT DISTINCT 
                p.patient_id,
                u.user_id, 
                u.name AS patient_name, 
                u.age, 
                u.gender, 
                IFNULL(p.blood_type, 'Unknown') AS blood_type, 
                IFNULL(p.allergies, 'None') AS allergies, 
                u.email,
                (SELECT COUNT(*) FROM MedicalRecords mr 
                 WHERE mr.patient_id = p.patient_id AND mr.doctor_id = @doctorId) AS total_visits,
                (SELECT MAX(mr.record_date) FROM MedicalRecords mr 
                 WHERE mr.patient_id = p.patient_id AND mr.doctor_id = @doctorId) AS last_visit
                FROM PatientQueue pq
                INNER JOIN Patients p ON pq.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE pq.doctor_id = @doctorId
                ORDER BY last_visit DESC, u.name ASC";

                DataTable dtPatients = DatabaseHelper.ExecuteQuery(queryPatients,
                    new MySqlParameter("@doctorId", doctorId));

                dgvPatients.DataSource = dtPatients;

                if (dgvAppointments.Rows.Count > 0)
                {
                    dgvAppointments.ClearSelection();
                }
                if (dgvPatients.Rows.Count > 0)
                {
                    dgvPatients.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}\n\nStack: {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnCompleteAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to complete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["queue_id"].Value);
            int patientId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvAppointments.SelectedRows[0].Cells["patient_name"].Value.ToString();

            try
            {
                string checkRecordQuery = @"
            SELECT COUNT(*) 
            FROM medicalrecords 
            WHERE patient_id = @patientId 
            AND doctor_id = @doctorId 
            AND queue_id = @queueId";

                int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkRecordQuery,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@queueId", queueId)));

                string checkChecklistQuery = @"
            SELECT equipment_checklist 
            FROM patientqueue 
            WHERE queue_id = @queueId";

                DataTable dtChecklist = DatabaseHelper.ExecuteQuery(checkChecklistQuery,
                    new MySqlParameter("@queueId", queueId));

                bool hasChecklist = false;
                if (dtChecklist.Rows.Count > 0)
                {
                    string checklistData = dtChecklist.Rows[0]["equipment_checklist"]?.ToString();
                    hasChecklist = !string.IsNullOrWhiteSpace(checklistData);
                }

                if (recordCount == 0 && !hasChecklist)
                {
                    MessageBox.Show(
                        $"⚠️ CONSULTATION INCOMPLETE\n\n" +
                        $"Patient: {patientName}\n\n" +
                        "❌ Missing Medical Record\n" +
                        "❌ Missing Equipment Report\n\n" +
                        "REQUIRED STEPS:\n" +
                        "1. Go to 'My Patients Records' tab\n" +
                        "2. Select this patient and click 'Add Medical Record'\n" +
                        "3. Complete and save the medical assessment form\n" +
                        "4. Return to 'My Appointments' tab\n" +
                        "5. Click 'Service Checklist' to complete the equipment report\n" +
                        "6. Then you can mark this visit as completed\n\n" +
                        "Both forms are required before completing the consultation.",
                        "Forms Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                else if (recordCount == 0)
                {
                    MessageBox.Show(
                        $"⚠️ MEDICAL RECORD MISSING\n\n" +
                        $"Patient: {patientName}\n\n" +
                        "✓ Equipment Report: Completed\n" +
                        "❌ Medical Record: Not completed\n\n" +
                        "Please create a medical record before completing this visit:\n\n" +
                        "1. Go to 'My Patients Records' tab\n" +
                        "2. Select this patient\n" +
                        "3. Click 'Add Medical Record'\n" +
                        "4. Complete and save the cardiac assessment form\n" +
                        "5. Return here to mark the visit as completed",
                        "Medical Record Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                else if (!hasChecklist)
                {
                    MessageBox.Show(
                        $"⚠️ EQUIPMENT REPORT MISSING\n\n" +
                        $"Patient: {patientName}\n\n" +
                        "✓ Medical Record: Completed\n" +
                        "❌ Equipment Report: Not completed\n\n" +
                        "Please complete the equipment checklist before finishing:\n\n" +
                        "1. Select this patient in the appointments list\n" +
                        "2. Click 'Service Checklist' button\n" +
                        "3. Add all equipment and services used\n" +
                        "4. Save the equipment report\n" +
                        "5. Return here to mark the visit as completed",
                        "Equipment Report Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"📋 COMPLETE VISIT\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Queue ID: #{queueId}\n\n" +
                    "✓ Medical record completed\n" +
                    "✓ Equipment report completed\n\n" +
                    "Mark this visit as completed?\n\n" +
                    "The patient will be moved to 'Completed' status and can proceed to billing.\n" +
                    "You will become available to take another patient.",
                    "Confirm Completion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                string updateQuery = @"
            UPDATE patientqueue 
            SET status = 'Completed', 
                completed_time = NOW()
            WHERE queue_id = @queueId";

                DatabaseHelper.ExecuteNonQuery(updateQuery,
                    new MySqlParameter("@queueId", queueId));

                string makeDoctorAvailableQuery = @"
            UPDATE Doctors 
            SET is_available = 1 
            WHERE doctor_id = @doctorId";

                DatabaseHelper.ExecuteNonQuery(makeDoctorAvailableQuery,
                    new MySqlParameter("@doctorId", doctorId));

                MessageBox.Show(
                    $"✅ VISIT COMPLETED SUCCESSFULLY\n\n" +
                    $"Patient: {patientName}\n\n" +
                    "Status: Completed ✓\n\n" +
                    "Completed Documentation:\n" +
                    "• Medical Record (Cardiac Assessment)\n" +
                    "• Equipment & Services Report\n\n" +
                    "✓ You are now available to take another patient\n" +
                    "✓ Patient can proceed to receptionist for billing",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing visit: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnServiceChecklist_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["queue_id"].Value);
            string patientName = dgvAppointments.SelectedRows[0].Cells["patient_name"].Value.ToString();

            try
            {
                string getPatientQuery = "SELECT patient_id FROM patientqueue WHERE queue_id = @queueId";
                int patientId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(getPatientQuery,
                    new MySqlParameter("@queueId", queueId)));

                OpenServiceChecklist(queueId, patientId, patientName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartCompleteVisitWorkflow(int patientId, string patientName)
        {
            try
            {
                string checkActiveQueueQuery = @"
            SELECT queue_id, status 
            FROM patientqueue 
            WHERE patient_id = @patientId
            AND discharged_time IS NULL
            AND status IN ('Called', 'In Progress')
            ORDER BY registered_time DESC
            LIMIT 1";

                DataTable dtActiveQueue = DatabaseHelper.ExecuteQuery(checkActiveQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                int? queueId = null;
                string status = null;

                if (dtActiveQueue.Rows.Count > 0)
                {
                    queueId = Convert.ToInt32(dtActiveQueue.Rows[0]["queue_id"]);
                    status = dtActiveQueue.Rows[0]["status"].ToString();

                    string checkRecordQuery = @"
                SELECT COUNT(*) 
                FROM medicalrecords 
                WHERE patient_id = @patientId 
                AND doctor_id = @doctorId 
                AND queue_id = @queueId";

                    int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkRecordQuery,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@queueId", queueId)));

                    if (recordCount > 0)
                    {
                        MessageBox.Show(
                            $"⚠ A medical record already exists for this active visit.\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Queue ID: #{queueId}\n" +
                            $"Status: {status}\n\n" +
                            "Please complete or discharge the visit before creating another record.",
                            "Duplicate Medical Record",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    string checkRecentQueueQuery = @"
                SELECT queue_id, status, discharged_time 
                FROM patientqueue 
                WHERE patient_id = @patientId 
                ORDER BY registered_time DESC
                LIMIT 1";

                    DataTable dtRecentQueue = DatabaseHelper.ExecuteQuery(checkRecentQueueQuery,
                        new MySqlParameter("@patientId", patientId));

                    if (dtRecentQueue.Rows.Count > 0)
                    {
                        string lastStatus = dtRecentQueue.Rows[0]["status"].ToString();
                        int lastQueueId = Convert.ToInt32(dtRecentQueue.Rows[0]["queue_id"]);
                        bool wasDischarged = dtRecentQueue.Rows[0]["discharged_time"] != DBNull.Value;

                        if (wasDischarged || lastStatus == "Completed" || lastStatus == "Discharged")
                        {
                            DialogResult result = MessageBox.Show(
                                $"⚕️ PATIENT ALREADY DISCHARGED\n\n" +
                                $"Patient: {patientName}\n" +
                                $"Last Visit ID: {lastQueueId}\n" +
                                $"Status: {lastStatus}\n\n" +
                                "This patient's previous visit has already been discharged.\n\n" +
                                "Would you like to create a follow-up note (not linked to a queue)?",
                                "Discharged Patient",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result != DialogResult.Yes)
                                return;

                            queueId = null;
                        }
                        else
                        {
                            MessageBox.Show(
                                $"⚠️ PATIENT NOT IN ACTIVE CONSULTATION\n\n" +
                                $"Patient: {patientName}\n" +
                                $"Current Status: {lastStatus}\n\n" +
                                "Medical records can only be created for patients currently 'Called' or 'In Progress'.",
                                "Inactive Queue",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                            $"⚠️ PATIENT NOT IN QUEUE\n\n" +
                            $"Patient: {patientName}\n\n" +
                            "This patient has no active queue entry.\n\n" +
                            "Would you like to create a standalone medical record?",
                            "Patient Not Queued",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result != DialogResult.Yes)
                            return;
                    }
                }

                MedicalRecordForm recordForm = new MedicalRecordForm(patientId, doctorId, patientName, queueId ?? 0);

                recordForm.FormClosed += (s, args) =>
                {
                    if (recordForm.DialogResult == DialogResult.OK)
                    {
                        MessageBox.Show(
                            $"✓ Medical record successfully saved for {patientName}.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadData();
                };

                recordForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenServiceChecklist(int queueId, int patientId, string patientName)
        {
            ServiceChecklistForm checklistForm = new ServiceChecklistForm(queueId, patientId, doctorId, patientName);

            checklistForm.FormClosed += (s, args) =>
            {
                if (checklistForm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show(
                        "✅ VISIT COMPLETED SUCCESSFULLY!\n\n" +
                        $"Patient: {patientName}\n\n" +
                        "✓ Medical record saved\n" +
                        "✓ Equipment report completed\n\n" +
                        "Status: Ready for billing\n" +
                        "The patient can now proceed to the receptionist for billing.",
                        "Visit Completed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                }
                else
                {
                    string checkRecordQuery = @"
                    SELECT COUNT(*) FROM medicalrecords 
                    WHERE patient_id = @patientId 
                    AND doctor_id = @doctorId 
                    AND DATE(record_date) = CURDATE()";

                    int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkRecordQuery,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@doctorId", doctorId)));

                    string checkEquipmentQuery = @"
                    SELECT equipment_checklist FROM patientqueue 
                    WHERE queue_id = @queueId";

                    DataTable dtEquipment = DatabaseHelper.ExecuteQuery(checkEquipmentQuery,
                        new MySqlParameter("@queueId", queueId));

                    bool hasEquipmentReport = dtEquipment.Rows.Count > 0 &&
                        !string.IsNullOrEmpty(dtEquipment.Rows[0]["equipment_checklist"]?.ToString());

                    if (recordCount > 0 && !hasEquipmentReport)
                    {
                        MessageBox.Show(
                            "⚠️ Equipment report was not completed.\n\n" +
                            "Note: Medical record was saved, but both forms are required.\n" +
                            "The visit is still marked as 'In Progress'.\n\n" +
                            "You can complete the equipment report later.",
                            "Incomplete Visit",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    LoadData();
                }
            };

            checklistForm.ShowDialog();
        }

        private void BtnViewPatientHistory_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["patient_name"].Value.ToString();

            ShowPatientMedicalRecordsList(patientId, patientName);
        }

        private void ShowPatientMedicalRecordsList(int patientId, string patientName)
        {
            try
            {
                string query = @"
                SELECT 
                m.record_id,
                m.record_date AS 'Date & Time',
                m.visit_type AS 'Visit Type',
                u.name AS 'Doctor'
                FROM MedicalRecords m
                INNER JOIN Doctors d ON m.doctor_id = d.doctor_id
                INNER JOIN Users u ON d.user_id = u.user_id
                WHERE m.patient_id = @patientId
                ORDER BY m.record_date DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        $"No medical records found for {patientName}.\n\n" +
                        "⚕️ This patient has no previous medical records on file.",
                        "Medical Records",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                Form historyForm = new Form
                {
                    Text = $"Medical Records - {patientName}",
                    Size = new Size(1200, 750),
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.FromArgb(240, 244, 248),
                    AutoScroll = true,
                    MinimumSize = new Size(800, 600)
                };

                Panel headerPanel = new Panel
                {
                    BackColor = Color.FromArgb(66, 153, 225),
                    Dock = DockStyle.Top,
                    Height = 100
                };

                Label lblTitle = new Label
                {
                    Text = $"📋 Medical Records - {patientName}",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 15),
                    AutoSize = true
                };

                Label lblCount = new Label
                {
                    Text = $"Total Records: {dt.Rows.Count}",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.FromArgb(224, 224, 224),
                    Location = new Point(20, 50),
                    AutoSize = true
                };

                Label lblInstruction = new Label
                {
                    Text = "Double-click a record to view full details or use the button below",
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.FromArgb(200, 200, 200),
                    Location = new Point(20, 75),
                    AutoSize = true
                };

                headerPanel.Controls.AddRange(new Control[] { lblTitle, lblCount, lblInstruction });

                DataGridView dgvRecords = new DataGridView
                {
                    Location = new Point(20, 120),
                    Size = new Size(1150, 500),
                    BackgroundColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    AllowUserToAddRows = false,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    RowTemplate = { Height = 40 },
                    DataSource = dt
                };

                dgvRecords.DefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 153, 225);
                dgvRecords.DefaultCellStyle.SelectionForeColor = Color.White;
                dgvRecords.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 153, 225);
                dgvRecords.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

                dgvRecords.DataBindingComplete += (s, ev) =>
                {
                    if (dgvRecords.Columns["record_id"] != null)
                    {
                        dgvRecords.Columns["record_id"].Visible = false;
                    }
                };

                dgvRecords.CellDoubleClick += (s, ev) =>
                {
                    if (ev.RowIndex >= 0)
                    {
                        int recordId = Convert.ToInt32(dgvRecords.Rows[ev.RowIndex].Cells["record_id"].Value);
                        ShowEnhancedMedicalRecord(recordId);
                    }
                };

                Panel buttonPanel = new Panel
                {
                    Location = new Point(20, 635),
                    Size = new Size(1150, 60),
                    BackColor = Color.Transparent
                };

                Button btnViewDetails = new Button
                {
                    Text = "👁️ View Full Record",
                    Location = new Point(0, 0),
                    Size = new Size(200, 45),
                    BackColor = Color.FromArgb(66, 153, 225),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnViewDetails.FlatAppearance.BorderSize = 0;
                btnViewDetails.Click += (s, ev) =>
                {
                    if (dgvRecords.SelectedRows.Count > 0)
                    {
                        int recordId = Convert.ToInt32(dgvRecords.SelectedRows[0].Cells["record_id"].Value);
                        ShowEnhancedMedicalRecord(recordId);
                    }
                    else
                    {
                        MessageBox.Show("Please select a record to view.", "Selection Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                Button btnClose = new Button
                {
                    Text = "✕ Close",
                    Location = new Point(1000, 0),
                    Size = new Size(150, 45),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) => historyForm.Close();

                buttonPanel.Controls.AddRange(new Control[] { btnViewDetails, btnClose });

                historyForm.Controls.AddRange(new Control[] { headerPanel, dgvRecords, buttonPanel });
                historyForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medical records: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompletePatientVisit(int queueId, string patientName)
        {
            string query = @"UPDATE patientqueue 
                           SET status = 'Completed', completed_time = NOW()
                           WHERE queue_id = @id";
            DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", queueId));

            MessageBox.Show($"{patientName} marked as completed!\n\nThe patient can now proceed to billing.",
                "Visit Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void TxtUniversalSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtUniversalSearch.Text.Trim();

            btnClearUniversalSearch.Visible = !string.IsNullOrWhiteSpace(searchText);

            searchDebounceTimer?.Dispose();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                HideSearchSuggestions();
                return;
            }

            searchDebounceTimer = new System.Threading.Timer(_ =>
            {
                this.Invoke(new Action(() =>
                {
                    ShowUniversalSearchSuggestions(searchText);
                }));
            }, null, SEARCH_DEBOUNCE_MS, System.Threading.Timeout.Infinite);
        }

        private void TxtUniversalSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (searchSuggestionsListBox == null) return;

            dynamic refs = searchSuggestionsListBox.Tag;
            if (refs == null) return;

            Panel container = refs.Container;

            if (e.KeyCode == Keys.Enter)
            {
                if (container.Visible && searchSuggestionsListBox.Items.Count > 0)
                {
                    if (searchSuggestionsListBox.SelectedIndex < 0)
                        searchSuggestionsListBox.SelectedIndex = 0;
                    SelectFromUniversalSearch();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (container.Visible && searchSuggestionsListBox.Items.Count > 0)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    if (searchSuggestionsListBox.SelectedIndex < 0)
                        searchSuggestionsListBox.SelectedIndex = 0;
                    else if (searchSuggestionsListBox.SelectedIndex < searchSuggestionsListBox.Items.Count - 1)
                        searchSuggestionsListBox.SelectedIndex++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (container.Visible && searchSuggestionsListBox.Items.Count > 0)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    if (searchSuggestionsListBox.SelectedIndex > 0)
                        searchSuggestionsListBox.SelectedIndex--;
                    else
                        txtUniversalSearch.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideSearchSuggestions();
                txtUniversalSearch.Clear();
                lblSearchStatus.Visible = false;
                panelSearchCategories.Visible = false;
            }
        }

        private void ShowUniversalSearchSuggestions(string searchText)
        {
            try
            {
                searchSuggestionsListBox.Items.Clear();
                int totalResults = 0;

                if (chkSearchAppointments.Checked)
                {
                    string apptQuery = @"
                        SELECT q.queue_id, u.name AS patient_name, 
                        q.priority, q.status, 'Appointments' as source
                        FROM patientqueue q
                        INNER JOIN Patients p ON q.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE q.doctor_id = @doctorId
                        AND q.queue_date = CURDATE()
                        AND (u.name LIKE @search OR q.status LIKE @search)
                        ORDER BY q.called_time DESC
                        LIMIT 5";

                    DataTable appointments = DatabaseHelper.ExecuteQuery(apptQuery,
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in appointments.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["queue_id"]),
                            DisplayText = $"{row["patient_name"]} - {row["priority"]} - {row["status"]}",
                            Source = "Appointments",
                            Data = row
                        });
                        totalResults++;
                    }
                }

                if (chkSearchPatients.Checked)
                {
                    string patientQuery = @"
                        SELECT DISTINCT p.patient_id, u.user_id, u.name, u.email, u.age, u.gender,
                        p.blood_type, 'Patients' as source
                        FROM PatientQueue pq
                        INNER JOIN Patients p ON pq.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE pq.doctor_id = @doctorId
                        AND (u.name LIKE @search OR u.email LIKE @search OR p.blood_type LIKE @search)
                        ORDER BY u.name
                        LIMIT 5";

                    DataTable patients = DatabaseHelper.ExecuteQuery(patientQuery,
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in patients.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["patient_id"]),
                            DisplayText = $"{row["name"]} - {row["age"]} yrs, {row["gender"]} - {row["blood_type"]}",
                            Source = "Patients",
                            Data = row
                        });
                        totalResults++;
                    }
                }

                lblSearchStatus.Text = totalResults > 0
                    ? $"Found {totalResults} result{(totalResults != 1 ? "s" : "")}"
                    : "No results found";
                lblSearchStatus.ForeColor = totalResults > 0
                    ? Color.FromArgb(72, 187, 120)
                    : Color.FromArgb(229, 62, 62);

                if (searchSuggestionsListBox.Items.Count > 0)
                {
                    PositionSearchSuggestions();
                }
                else
                {
                    HideSearchSuggestions();
                }
            }
            catch (Exception ex)
            {
                lblSearchStatus.Text = "Search error occurred";
                lblSearchStatus.ForeColor = Color.FromArgb(229, 62, 62);
                MessageBox.Show($"Error showing suggestions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblUniversalSearchIcon_Click(object sender, EventArgs e)
        {
            txtUniversalSearch.Focus();
        }

        private void HideSearchSuggestions()
        {
            if (searchSuggestionsListBox?.Tag != null)
            {
                dynamic refs = searchSuggestionsListBox.Tag;
                Panel container = refs.Container;
                Panel shadow = refs.Shadow;

                container.Visible = false;
                shadow.Visible = false;
            }
        }

        private void SearchSuggestionsListBox_Click(object sender, EventArgs e)
        {
            if (searchSuggestionsListBox.SelectedItem != null)
            {
                SelectFromUniversalSearch();
            }
        }

        private void SearchSuggestionsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectFromUniversalSearch();
                e.Handled = true;
            }
        }

        private void SelectFromUniversalSearch()
        {
            if (searchSuggestionsListBox.SelectedItem is UniversalSearchItem selectedItem)
            {
                HideSearchSuggestions();

                switch (selectedItem.Source)
                {
                    case "Appointments":
                        SwitchToTab(0);
                        FocusOnAppointment(selectedItem.Id);
                        break;

                    case "Patients":
                        SwitchToTab(1);
                        FocusOnPatient(selectedItem.Data);
                        break;
                }
            }
        }

        private void FocusOnAppointment(int queueId)
        {
            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.Cells["queue_id"].Value != null &&
                    Convert.ToInt32(row.Cells["queue_id"].Value) == queueId)
                {
                    row.Selected = true;
                    dgvAppointments.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvAppointments.Focus();
                    break;
                }
            }
        }

        private void FocusOnPatient(DataRow patientData)
        {
            int patientId = Convert.ToInt32(patientData["patient_id"]);

            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                if (row.Cells["patient_id"].Value != null &&
                    Convert.ToInt32(row.Cells["patient_id"].Value) == patientId)
                {
                    row.Selected = true;
                    dgvPatients.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvPatients.Focus();
                    break;
                }
            }
        }

        private void BtnClearUniversalSearch_Click(object sender, EventArgs e)
        {
            txtUniversalSearch.Clear();
            HideSearchSuggestions();
        }

        private void BtnViewPatient_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["queue_id"].Value);

            string query = @"
                SELECT 
                p.patient_id
                FROM PatientQueue q
                INNER JOIN Patients p ON q.patient_id = p.patient_id
                WHERE q.queue_id = @queueId";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@queueId", queueId));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Patient information not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int patientId = Convert.ToInt32(dt.Rows[0]["patient_id"]);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, 0, true);
            intakeForm.ShowDialog();
        }

        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["patient_name"].Value.ToString();

            ShowPatientMedicalRecordsList(patientId, patientName);
        }

        private void ShowEnhancedMedicalRecord(int recordId)
        {
            MedicalRecordForm viewer = MedicalRecordForm.CreateViewMode(
                recordId,
                currentUser.UserId,
                currentUser.Role
            );
            viewer.ShowDialog();
        }

        private void BtnAddMedicalRecord_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["patient_name"].Value.ToString();

            try
            {
                string checkActiveQueueQuery = @"
                SELECT queue_id, status 
                FROM patientqueue 
                WHERE patient_id = @patientId
                AND discharged_time IS NULL
                AND status IN ('Called', 'In Progress')
                ORDER BY registered_time DESC";

                DataTable dtActiveQueue = DatabaseHelper.ExecuteQuery(checkActiveQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                int? queueId = null;
                string status = null;

                if (dtActiveQueue.Rows.Count > 0)
                {
                    if (dtActiveQueue.Rows.Count > 1)
                    {
                        string msg = "⚠ Multiple active queue entries found for this patient:\n\n";
                        foreach (DataRow row in dtActiveQueue.Rows)
                            msg += $"• Queue #{row["queue_id"]} — Status: {row["status"]}\n";

                        msg += "\nEnter the queue ID you want to attach this medical record to:";

                        string input = Microsoft.VisualBasic.Interaction.InputBox(
                            msg, "Select Queue ID", dtActiveQueue.Rows[0]["queue_id"].ToString());

                        if (!int.TryParse(input, out int chosenQueueId))
                        {
                            MessageBox.Show("Invalid queue ID entered. Record creation cancelled.",
                                "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        queueId = chosenQueueId;
                        status = "Called";
                    }
                    else
                    {
                        queueId = Convert.ToInt32(dtActiveQueue.Rows[0]["queue_id"]);
                        status = dtActiveQueue.Rows[0]["status"].ToString();
                    }

                    string checkRecordQuery = @"
                SELECT record_id 
                FROM medicalrecords 
                WHERE patient_id = @patientId 
                AND doctor_id = @doctorId 
                AND queue_id = @queueId
                LIMIT 1";

                    object existingRecord = DatabaseHelper.ExecuteScalar(checkRecordQuery,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@queueId", queueId));

                    if (existingRecord != null && existingRecord != DBNull.Value)
                    {
                        MessageBox.Show(
                            $"⚠ This patient already has a medical record for this active visit.\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Queue ID: #{queueId}\n\n" +
                            "You can mark this visit as completed using the 'Mark Completed' button in the Appointments tab.",
                            "Record Already Exists",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    string checkRecentQueueQuery = @"
                SELECT queue_id, status, discharged_time 
                FROM patientqueue 
                WHERE patient_id = @patientId 
                ORDER BY registered_time DESC 
                LIMIT 1";

                    DataTable dtRecentQueue = DatabaseHelper.ExecuteQuery(checkRecentQueueQuery,
                        new MySqlParameter("@patientId", patientId));

                    if (dtRecentQueue.Rows.Count > 0)
                    {
                        string lastStatus = dtRecentQueue.Rows[0]["status"].ToString();
                        int lastQueueId = Convert.ToInt32(dtRecentQueue.Rows[0]["queue_id"]);
                        bool wasDischarged = dtRecentQueue.Rows[0]["discharged_time"] != DBNull.Value;

                        if (wasDischarged || lastStatus == "Completed" || lastStatus == "Discharged")
                        {
                            DialogResult result = MessageBox.Show(
                                $"⚕️ PATIENT ALREADY DISCHARGED\n\n" +
                                $"Patient: {patientName}\n" +
                                $"Last Visit Status: {lastStatus}\n" +
                                $"Queue Entry: #{lastQueueId}\n\n" +
                                "This patient's last visit is complete.\n\n" +
                                "Do you want to create a follow-up note (not linked to a queue)?",
                                "Discharged Patient",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result != DialogResult.Yes)
                                return;

                            queueId = null;
                        }
                        else
                        {
                            MessageBox.Show(
                                $"⚠️ PATIENT NOT IN ACTIVE CONSULTATION\n\n" +
                                $"Patient: {patientName}\n" +
                                $"Current Status: {lastStatus}\n\n" +
                                "Medical records can only be created for patients who are:\n" +
                                "• Currently 'Called' or 'In Progress'\n\n" +
                                "Please ensure the receptionist calls this patient first.",
                                "Not in Active Consultation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                            $"⚠️ PATIENT NOT IN QUEUE\n\n" +
                            $"Patient: {patientName}\n\n" +
                            "This patient is not currently queued.\n\n" +
                            "Do you still want to create a standalone medical record?",
                            "Patient Not Queued",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result != DialogResult.Yes)
                            return;
                    }
                }

                MedicalRecordForm recordForm = new MedicalRecordForm(patientId, doctorId, patientName, queueId ?? 0);

                recordForm.FormClosed += (s, args) =>
                {
                    if (recordForm.DialogResult == DialogResult.OK)
                    {
                        MessageBox.Show(
                            $"✓ Medical record saved successfully for {patientName}!\n\n" +
                            "📋 Next Steps:\n" +
                            "1. Go to 'My Appointments' tab\n" +
                            "2. Select this patient\n" +
                            "3. Click 'Mark Completed' to finish the visit\n\n" +
                            "The patient will remain 'In Progress' until you mark them as completed.",
                            "Record Saved",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadData();
                    }
                };

                recordForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void BtnAppointmentsMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(0);
        }

        private void BtnPatientsMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(1);
        }

        private void SwitchToTab(int index)
        {
            tabControl.SelectedIndex = index;

            btnAppointmentsMenu.BackColor = Color.Transparent;
            btnPatientsMenu.BackColor = Color.Transparent;

            btnAppointmentsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnPatientsMenu.ForeColor = Color.FromArgb(226, 232, 240);

            Button activeBtn = index == 0 ? btnAppointmentsMenu : btnPatientsMenu;
            activeBtn.BackColor = Color.FromArgb(26, 188, 156);
            activeBtn.ForeColor = Color.White;
        }

        public class UniversalSearchItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }
            public string Source { get; set; }
            public DataRow Data { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}