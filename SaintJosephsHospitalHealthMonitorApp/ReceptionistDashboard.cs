using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ReceptionistDashboard : Form
    {
        private User currentUser;
        private byte[] currentUserProfileImage;
        private System.Threading.Timer searchDebounceTimer;
        private const int SEARCH_DEBOUNCE_MS = 300;

        public ReceptionistDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            ApplyStyle();
            UpdateWelcomeMessage();
            ConfigureAllDataGridViews();
            InitializeUniversalSearch();
            LoadUserProfile();
            LoadData();
        }

        private void ApplyStyle()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            Color sidebarBg = Color.FromArgb(26, 32, 44);
            Color accentColor = Color.FromArgb(231, 76, 60);

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

            UpdateMenuButton(btnQueueMenu, 290, "👥", "Patient Queue");
            UpdateMenuButton(btnPatientsMenu, 345, "📋", "Patient Records");
            UpdateMenuButton(btnBillingMenu, 400, "💰", "Billing & Discharge");

            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);

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
                if (btn.BackColor != Color.FromArgb(231, 76, 60))
                    btn.BackColor = Color.FromArgb(45, 55, 72);
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn.BackColor != Color.FromArgb(231, 76, 60))
                    btn.BackColor = Color.Transparent;
            };
        }

        private void UpdateWelcomeMessage()
        {
            lblWelcome.Text = $"{currentUser.Name}";
            lblRole.Text = $"Role: {currentUser.Role}";
            lblHospitalName.Text = "St. Joseph's Hospital";
        }

        private void ConfigureAllDataGridViews()
        {
            if (dgvQueue != null) ConfigureDataGridView(dgvQueue);
            if (dgvPatients != null) ConfigureDataGridView(dgvPatients);
            if (dgvBilling != null) ConfigureDataGridView(dgvBilling);
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 76, 60);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 205, 210);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
            dgv.RowTemplate.Height = 45;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 205, 210);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            typeof(DataGridView).InvokeMember("DoubleBuffered",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,null, dgv, new object[] { true });
            dgv.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            };
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
                case "Queue": return Color.FromArgb(72, 187, 120);
                case "Patients": return Color.FromArgb(66, 153, 225);
                case "Billing": return Color.FromArgb(243, 156, 18);
                default: return Color.FromArgb(113, 128, 150);
            }
        }

        private string GetCategoryIcon(string source)
        {
            switch (source)
            {
                case "Queue": return "👥";
                case "Patients": return "👤";
                case "Billing": return "💰";
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
            try
            {
                string query = "SELECT profile_image FROM Users WHERE user_id = @userId";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@userId", currentUser.UserId));

                if (dt.Rows.Count > 0 && dt.Rows[0]["profile_image"] != DBNull.Value)
                {
                    currentUserProfileImage = (byte[])dt.Rows[0]["profile_image"];
                    using (MemoryStream ms = new MemoryStream(currentUserProfileImage))
                    {
                        Image img = Image.FromStream(ms);
                        pictureBoxProfile.Image = img;
                        pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    SetDefaultProfileImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Profile Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string icon = "👤";
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
                ReorderQueueNumbers();
                string queryQueue = @"
                SELECT 
                q.queue_id, 
                q.queue_number, 
                q.patient_id,
                u.name AS Patient, 
                IFNULL(d.name, 'Not Assigned') AS Doctor, 
                q.priority, 
                q.status,
                q.registered_time
                FROM patientqueue q
                INNER JOIN Patients p ON q.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                LEFT JOIN Doctors doc ON q.doctor_id = doc.doctor_id
                LEFT JOIN Users d ON doc.user_id = d.user_id
                WHERE q.queue_date = CURDATE()
                AND q.status != 'Completed'
                ORDER BY 
                CASE q.priority 
                WHEN 'Emergency' THEN 1 
                WHEN 'Urgent' THEN 2 
                ELSE 3 
                END, 
                q.registered_time";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(queryQueue);
                dgvQueue.DataSource = dtQueue;
                if (dgvQueue.Columns["patient_id"] != null)
                {
                    dgvQueue.Columns["patient_id"].Visible = false;
                }

                int queueCount = dtQueue.Rows.Count;
                lblQueueCount.Text = $"Total in Queue Today: {queueCount}";

                string queryPatients = @"
                SELECT 
                p.patient_id, 
                u.name, 
                u.age, 
                u.gender, 
                IFNULL(p.blood_type, 'Unknown') AS blood_type, 
                IFNULL(p.phone_number, 'N/A') AS phone_number, 
                u.email
                FROM Patients p
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.is_active = 1
                ORDER BY u.name";

                dgvPatients.DataSource = DatabaseHelper.ExecuteQuery(queryPatients);

                LoadBillingData();

                if (dgvQueue.Rows.Count > 0) dgvQueue.ClearSelection();
                if (dgvPatients.Rows.Count > 0) dgvPatients.ClearSelection();
                if (dgvBilling.Rows.Count > 0) dgvBilling.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReorderQueueNumbers()
        {
            try
            {
                string selectQuery = @"
                SELECT queue_id
                FROM patientqueue
                WHERE queue_date = CURDATE()
                AND status != 'Completed'
                ORDER BY 
                CASE priority 
                WHEN 'Emergency' THEN 1 
                WHEN 'Urgent' THEN 2 
                ELSE 3 
                END,
                registered_time";

                DataTable dt = DatabaseHelper.ExecuteQuery(selectQuery);

                int newQueueNumber = 1;
                foreach (DataRow row in dt.Rows)
                {
                    int queueId = Convert.ToInt32(row["queue_id"]);

                    string updateQuery = @"
                UPDATE patientqueue 
                SET queue_number = @queueNumber 
                WHERE queue_id = @queueId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@queueNumber", newQueueNumber),
                        new MySqlParameter("@queueId", queueId));

                    newQueueNumber++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Queue reorder error: {ex.Message}");
            }
        }

        private void LoadBillingData()
        {
            try
            {
                string queryBilling = @"
                SELECT 
                IFNULL(b.bill_id, 0) AS bill_id,
                q.patient_id,
                u.name AS 'Patient Name',
                DATE_FORMAT(IFNULL(b.bill_date, q.completed_time), '%Y-%m-%d %H:%i') AS 'Bill Date',
                IFNULL(b.amount, 0) AS 'Total Amount',
                CASE 
                WHEN b.bill_id IS NULL THEN 'Awaiting Bill'
                ELSE b.status
                END AS 'Status',
                IFNULL(b.payment_method, 'N/A') AS 'Payment Method',
                CASE 
                WHEN b.bill_id IS NULL THEN 'Create Bill Required'
                WHEN b.status = 'Paid' THEN 'Ready for Discharge'
                ELSE 'Processing'
                END AS 'Discharge Status'
                FROM patientqueue q
                INNER JOIN Patients p ON q.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                LEFT JOIN Billing b ON b.patient_id = q.patient_id 
                AND DATE(b.bill_date) = CURDATE()
                WHERE q.queue_date = CURDATE()
                AND q.status = 'Completed'
                AND (b.bill_id IS NULL OR b.status IN ('Pending', 'Partially Paid', 'Paid'))
                ORDER BY 
                CASE 
                WHEN b.bill_id IS NULL THEN 1
                WHEN b.status = 'Paid' THEN 2
                ELSE 3
                END,
                q.completed_time DESC";

                DataTable dtBills = DatabaseHelper.ExecuteQuery(queryBilling);
                dgvBilling.DataSource = dtBills;

                if (dgvBilling.Columns["bill_id"] != null)
                    dgvBilling.Columns["bill_id"].Visible = false;
                if (dgvBilling.Columns["patient_id"] != null)
                    dgvBilling.Columns["patient_id"].Visible = false;
                if (dgvBilling.Columns["Total Amount"] != null)
                {
                    dgvBilling.Columns["Total Amount"].DefaultCellStyle.Format = "₱#,##0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (chkSearchQueue.Checked)
                {
                    string queueQuery = @"
                        SELECT q.queue_id, q.patient_id, u.name AS patient_name, 
                               q.priority, q.status, 'Queue' as source
                        FROM patientqueue q
                        INNER JOIN Patients p ON q.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE q.queue_date = CURDATE()
                        AND (u.name LIKE @search OR q.status LIKE @search)
                        ORDER BY q.queue_number
                        LIMIT 5";

                    DataTable queue = DatabaseHelper.ExecuteQuery(queueQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in queue.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["queue_id"]),
                            DisplayText = $"{row["patient_name"]} - {row["priority"]} - {row["status"]}",
                            Source = "Queue",
                            Data = row
                        });
                        totalResults++;
                    }
                }

                if (chkSearchPatients.Checked)
                {
                    string patientQuery = @"
                        SELECT p.patient_id, u.user_id, u.name, u.email, u.age, u.gender,
                               p.blood_type, 'Patients' as source
                        FROM Patients p
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE u.is_active = 1
                        AND (u.name LIKE @search OR u.email LIKE @search OR p.blood_type LIKE @search)
                        ORDER BY u.name
                        LIMIT 5";

                    DataTable patients = DatabaseHelper.ExecuteQuery(patientQuery,
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

                if (chkSearchBilling.Checked)
                {
                    string billingQuery = @"
                        SELECT b.bill_id, b.patient_id, u.name AS patient_name,
                               b.amount, b.status, 'Billing' as source
                        FROM Billing b
                        INNER JOIN Patients p ON b.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE DATE(b.bill_date) = CURDATE()
                        AND (u.name LIKE @search OR b.status LIKE @search)
                        ORDER BY b.bill_date DESC
                        LIMIT 5";

                    DataTable billing = DatabaseHelper.ExecuteQuery(billingQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in billing.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["bill_id"]),
                            DisplayText = $"{row["patient_name"]} - ₱{Convert.ToDecimal(row["amount"]):N2} - {row["status"]}",
                            Source = "Billing",
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
                    case "Queue":
                        SwitchToTab(0);
                        FocusOnQueue(selectedItem.Id);
                        break;

                    case "Patients":
                        SwitchToTab(1);
                        FocusOnPatient(selectedItem.Id);
                        break;

                    case "Billing":
                        SwitchToTab(2);
                        FocusOnBilling(selectedItem.Data);
                        break;
                }
            }
        }

        private void FocusOnQueue(int queueId)
        {
            foreach (DataGridViewRow row in dgvQueue.Rows)
            {
                if (row.Cells["queue_id"].Value != null &&
                    Convert.ToInt32(row.Cells["queue_id"].Value) == queueId)
                {
                    row.Selected = true;
                    dgvQueue.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvQueue.Focus();
                    break;
                }
            }
        }

        private void FocusOnPatient(int patientId)
        {
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

        private void FocusOnBilling(DataRow billingData)
        {
            int billId = Convert.ToInt32(billingData["bill_id"]);

            foreach (DataGridViewRow row in dgvBilling.Rows)
            {
                if (row.Cells["bill_id"].Value != null &&
                    Convert.ToInt32(row.Cells["bill_id"].Value) == billId)
                {
                    row.Selected = true;
                    dgvBilling.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvBilling.Focus();
                    break;
                }
            }
        }

        private void BtnClearUniversalSearch_Click(object sender, EventArgs e)
        {
            txtUniversalSearch.Clear();
            HideSearchSuggestions();
        }

        private void BtnQueueMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(0);
        }

        private void BtnPatientsMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(1);
        }

        private void BtnBillingMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(2);
        }

        private void SwitchToTab(int index)
        {
            tabControl.SelectedIndex = index;

            btnQueueMenu.BackColor = Color.Transparent;
            btnPatientsMenu.BackColor = Color.Transparent;
            btnBillingMenu.BackColor = Color.Transparent;

            btnQueueMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnPatientsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnBillingMenu.ForeColor = Color.FromArgb(226, 232, 240);

            Button activeBtn = index == 0 ? btnQueueMenu : (index == 1 ? btnPatientsMenu : btnBillingMenu);
            activeBtn.BackColor = Color.FromArgb(231, 76, 60);
            activeBtn.ForeColor = Color.White;
        }

        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            ViewBillDetails(billId);
        }

        private void ViewBillDetails(int billId)
        {
            try
            {
                string query = @"
                SELECT 
                    b.*,
                    u.name AS patient_name,
                    p.blood_type,
                    p.phone_number
                FROM Billing b
                INNER JOIN Patients p ON b.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE b.bill_id = @billId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bill not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow bill = dt.Rows[0];

                Form viewForm = new Form
                {
                    Text = $"Bill Details - Invoice #{billId}",
                    Size = new Size(700, 650),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    BackColor = Color.White
                };

                RichTextBox rtbDetails = new RichTextBox
                {
                    Location = new Point(20, 20),
                    Size = new Size(640, 520),
                    ReadOnly = true,
                    Font = new Font("Consolas", 10F),
                    BorderStyle = BorderStyle.FixedSingle
                };

                string details = $@"═══════════════════════════════════════════════
                                                SAINT JOSEPH'S HOSPITAL
                                                    BILLING STATEMENT
                                    ═══════════════════════════════════════════════
                                    Invoice #: {billId}
                                    Date: {Convert.ToDateTime(bill["bill_date"]):yyyy-MM-dd HH:mm}

                                                    PATIENT INFORMATION
                                    ───────────────────────────────────────────────
                                    Name: {bill["patient_name"]}
                                    Patient ID: {bill["patient_id"]}
                                    Blood Type: {bill["blood_type"]}
                                    Contact: {bill["phone_number"]}

                                    BILLING DETAILS
                                    ───────────────────────────────────────────────
                                    {bill["description"]}

                                    PAYMENT SUMMARY
                                    ───────────────────────────────────────────────
                                    Subtotal:        ₱{Convert.ToDecimal(bill["subtotal"]):N2}
                                    Discount ({Convert.ToDecimal(bill["discount_percent"])}%): -₱{Convert.ToDecimal(bill["discount_amount"]):N2}
                                    Tax ({Convert.ToDecimal(bill["tax_percent"])}%):      ₱{Convert.ToDecimal(bill["tax_amount"]):N2}
                                    ═══════════════════════════════════════════════
                                    TOTAL AMOUNT:    ₱{Convert.ToDecimal(bill["amount"]):N2}
                                    ═══════════════════════════════════════════════

                                    Payment Method: {bill["payment_method"]}
                                    Status: {bill["status"]}

                                    Notes: {bill["notes"]}

                                    ═══════════════════════════════════════════════";

                rtbDetails.Text = details;

                Button btnClose = new Button
                {
                    Text = "Close",
                    Size = new Size(100, 35),
                    Location = new Point(560, 560),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) => viewForm.Close();

                viewForm.Controls.AddRange(new Control[] { rtbDetails, btnClose });
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing bill: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to manage billing.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvBilling.SelectedRows[0].Cells["Status"].Value.ToString();
            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();

            if (status == "Awaiting Bill" || billId == 0)
            {
                CreateBillFromCompletedVisit(patientId, patientName);
                return;
            }

            string checkDescQuery = "SELECT description FROM Billing WHERE bill_id = @billId";
            DataTable dtDesc = DatabaseHelper.ExecuteQuery(checkDescQuery,
                new MySqlParameter("@billId", billId));

            bool isAutoGenerated = false;
            if (dtDesc.Rows.Count > 0)
            {
                string description = dtDesc.Rows[0]["description"]?.ToString() ?? "";
                isAutoGenerated = description.Contains("Auto-generated from doctor's service checklist");
            }

            if (isAutoGenerated)
            {
                DialogResult result = MessageBox.Show(
                    "⚠️ AUTO-GENERATED BILL\n\n" +
                    "This bill was automatically created from the doctor's equipment checklist.\n\n" +
                    "The services and prices match exactly what the doctor used.\n\n" +
                    "Do you want to:\n" +
                    "• YES - View the equipment report (recommended)\n" +
                    "• NO - Edit the bill directly\n" +
                    "• CANCEL - Go back\n\n" +
                    "Note: Editing may cause discrepancies with the medical record.",
                    "Auto-Generated Bill",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    ShowEquipmentReportFromQueue(patientId, patientName);
                    return;
                }
            }

            BillingForm billingForm = new BillingForm(billId, currentUser.UserId);
            if (billingForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ShowEquipmentReportFromQueue(int patientId, string patientName)
        {
            try
            {
                string query = @"
                SELECT equipment_checklist
                FROM patientqueue
                WHERE patient_id = @patientId 
                AND queue_date = CURDATE()
                AND status = 'Completed'
                ORDER BY completed_time DESC
                LIMIT 1";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count == 0 || dt.Rows[0]["equipment_checklist"] == DBNull.Value)
                {
                    MessageBox.Show(
                        "No equipment report found for this patient.\n\n" +
                        "The doctor has not completed the equipment & services report yet.",
                        "No Report Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                string equipmentReport = dt.Rows[0]["equipment_checklist"].ToString();

                Form reportView = new Form
                {
                    Text = $"Equipment & Services Report - {patientName}",
                    Size = new Size(900, 700),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    BackColor = Color.White
                };

                Panel headerPanel = new Panel
                {
                    BackColor = Color.FromArgb(52, 152, 219),
                    Dock = DockStyle.Top,
                    Height = 100
                };

                Label lblTitle = new Label
                {
                    Text = $"📋 Equipment & Services Report",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 15),
                    AutoSize = true
                };

                Label lblPatient = new Label
                {
                    Text = $"Patient: {patientName}",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(20, 50),
                    AutoSize = true
                };

                Label lblNote = new Label
                {
                    Text = "Use this report to create the patient bill",
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.FromArgb(220, 220, 220),
                    Location = new Point(20, 75),
                    AutoSize = true
                };

                headerPanel.Controls.AddRange(new Control[] { lblTitle, lblPatient, lblNote });

                RichTextBox rtbReport = new RichTextBox
                {
                    Location = new Point(20, 120),
                    Size = new Size(840, 450),
                    ReadOnly = true,
                    Font = new Font("Consolas", 10F),
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = equipmentReport,
                    BackColor = Color.FromArgb(250, 250, 250)
                };

                Button btnCreateBill = new Button
                {
                    Text = "💳 Create Bill from Report",
                    Size = new Size(220, 45),
                    Location = new Point(540, 590),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnCreateBill.FlatAppearance.BorderSize = 0;
                btnCreateBill.Click += (s, ev) =>
                {
                    reportView.Close();
                    BillingForm billingForm = new BillingForm(currentUser.UserId, patientId);
                    if (billingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                };

                Button btnClose = new Button
                {
                    Text = "Close",
                    Size = new Size(120, 45),
                    Location = new Point(770, 590),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) => reportView.Close();

                reportView.Controls.AddRange(new Control[] {
                    headerPanel, rtbReport, btnCreateBill, btnClose
                });
                reportView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateBillFromCompletedVisit(int patientId, string patientName)
        {
            try
            {
                string checkQueueQuery = @"
                SELECT q.queue_id, d.doctor_id, q.equipment_checklist
                FROM patientqueue q
                LEFT JOIN Doctors d ON q.doctor_id = d.doctor_id
                WHERE q.patient_id = @patientId 
                AND q.queue_date = CURDATE()
                AND q.status = 'Completed'
                ORDER BY q.completed_time DESC
                LIMIT 1";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(checkQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                if (dtQueue.Rows.Count > 0)
                {
                    int queueId = Convert.ToInt32(dtQueue.Rows[0]["queue_id"]);
                    int doctorId = dtQueue.Rows[0]["doctor_id"] != DBNull.Value
                        ? Convert.ToInt32(dtQueue.Rows[0]["doctor_id"])
                        : 0;
                    string equipmentReport = dtQueue.Rows[0]["equipment_checklist"]?.ToString();

                    if (!string.IsNullOrEmpty(equipmentReport))
                    {
                        DialogResult result = MessageBox.Show(
                            "✅ EQUIPMENT REPORT FOUND\n\n" +
                            $"The doctor has completed an equipment & services report for {patientName}.\n\n" +
                            "Would you like to:\n" +
                            "• YES - View the equipment report and create bill\n" +
                            "• NO - Create a manual bill instead",
                            "Equipment Report Available",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            ShowEquipmentReportFromQueue(patientId, patientName);
                            return;
                        }
                    }
                    else if (doctorId > 0)
                    {
                        DialogResult askReport = MessageBox.Show(
                            "⚠️ NO EQUIPMENT REPORT FOUND\n\n" +
                            $"The doctor has not created an equipment report for {patientName}.\n\n" +
                            "Would you like to create a manual bill?",
                            "Missing Equipment Report",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (askReport != DialogResult.Yes)
                            return;
                    }
                }

                BillingForm billingForm = new BillingForm(currentUser.UserId, patientId);
                if (billingForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProcessPayment_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to process payment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvBilling.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Awaiting Bill")
            {
                MessageBox.Show(
                    "❌ NO BILL CREATED YET\n\n" +
                    "Please create a bill for this patient first.\n\n" +
                    "Click 'Update Bill' to create the invoice.",
                    "Bill Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();
            decimal amount = Convert.ToDecimal(dgvBilling.SelectedRows[0].Cells["Total Amount"].Value);

            DialogResult result = MessageBox.Show(
                $"Process payment for {patientName}?\n\n" +
                $"Invoice #{billId}\n" +
                $"Amount: ₱{amount:N2}\n\n" +
                "Mark this bill as PAID?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string updateQuery = @"
                UPDATE Billing 
                SET status = 'Paid', 
                    payment_method = @paymentMethod
                WHERE bill_id = @billId";

                string paymentMethod = "Cash";
                using (var methodForm = new Form())
                {
                    methodForm.Text = "Payment Method";
                    methodForm.Size = new Size(300, 200);
                    methodForm.StartPosition = FormStartPosition.CenterParent;
                    methodForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    methodForm.MaximizeBox = false;

                    Label lbl = new Label
                    {
                        Text = "Select Payment Method:",
                        Location = new Point(20, 20),
                        AutoSize = true
                    };

                    ComboBox cmb = new ComboBox
                    {
                        Location = new Point(20, 50),
                        Size = new Size(240, 25),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    cmb.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Check", "Bank Transfer" });
                    cmb.SelectedIndex = 0;

                    Button btnOk = new Button
                    {
                        Text = "OK",
                        Location = new Point(100, 110),
                        Size = new Size(75, 30),
                        DialogResult = DialogResult.OK
                    };

                    Button btnCancel = new Button
                    {
                        Text = "Cancel",
                        Location = new Point(185, 110),
                        Size = new Size(75, 30),
                        DialogResult = DialogResult.Cancel
                    };

                    methodForm.Controls.AddRange(new Control[] { lbl, cmb, btnOk, btnCancel });
                    methodForm.AcceptButton = btnOk;
                    methodForm.CancelButton = btnCancel;

                    if (methodForm.ShowDialog() == DialogResult.OK)
                    {
                        paymentMethod = cmb.SelectedItem.ToString();
                    }
                    else
                    {
                        return;
                    }
                }

                DatabaseHelper.ExecuteNonQuery(updateQuery,
                    new MySqlParameter("@paymentMethod", paymentMethod),
                    new MySqlParameter("@billId", billId));

                MessageBox.Show(
                    $"✓ Payment processed successfully!\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Amount Paid: ₱{amount:N2}\n" +
                    $"Payment Method: {paymentMethod}\n\n" +
                    "Patient is now ready for discharge.",
                    "Payment Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDischargePatient_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to discharge.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvBilling.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status == "Awaiting Bill")
            {
                MessageBox.Show(
                    "❌ CANNOT DISCHARGE - NO BILL CREATED\n\n" +
                    "Please create a bill for this patient first.\n\n" +
                    "Click 'Update Bill' to create the invoice.",
                    "Bill Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (status != "Paid")
            {
                MessageBox.Show(
                    "❌ CANNOT DISCHARGE - PAYMENT REQUIRED\n\n" +
                    "The bill must be marked as PAID before discharge.\n\n" +
                    "Please process the payment first.",
                    "Payment Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Discharge patient: {patientName}?\n\n" +
                "This will:\n" +
                "• Remove patient from today's queue\n" +
                "• Archive the completed visit\n" +
                "• Close the billing record\n" +
                "• Reorder remaining queue numbers\n\n" +
                "Continue with discharge?",
                "Confirm Discharge",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string deleteQueueQuery = @"
        DELETE FROM patientqueue 
        WHERE patient_id = @patientId 
        AND queue_date = CURDATE()
        AND status = 'Completed'";

                DatabaseHelper.ExecuteNonQuery(deleteQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                MessageBox.Show(
                    $"✓ Patient discharged successfully!\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n\n" +
                    "Visit completed and archived.\n" +
                    "Queue numbers reordered automatically.",
                    "Discharge Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error discharging patient: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddToQueue_Click(object sender, EventArgs e)
        {
            using (var selectForm = new Form())
            {
                selectForm.Text = "Select Patient";
                selectForm.Size = new Size(500, 400);
                selectForm.StartPosition = FormStartPosition.CenterParent;

                var lblInstruction = new Label
                {
                    Text = "Select a patient to add to queue:",
                    Location = new Point(20, 20),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                var dgv = new DataGridView
                {
                    Location = new Point(20, 50),
                    Size = new Size(440, 250),
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false,
                    AllowUserToAddRows = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                string query = @"
                SELECT p.patient_id, u.name, u.age, u.gender, p.blood_type
                FROM Patients p
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.is_active = 1
                AND p.patient_id NOT IN (
                SELECT patient_id 
                FROM patientqueue 
                WHERE queue_date = CURDATE())
                ORDER BY u.name";
                dgv.DataSource = DatabaseHelper.ExecuteQuery(query);

                var btnSelect = new Button
                {
                    Text = "Select & Continue to Intake",
                    Location = new Point(150, 310),
                    Size = new Size(200, 35),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btnSelect.FlatAppearance.BorderSize = 0;

                btnSelect.Click += (s, ev) =>
                {
                    if (dgv.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dgv.SelectedRows[0].Cells["patient_id"].Value);

                        string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM patientqueue 
                        WHERE patient_id = @patientId 
                        AND queue_date = CURDATE()";
                        int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                            new MySqlParameter("@patientId", patientId)));

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This patient is already in today's queue.\n\n" +
                                "A patient can only be added to the queue once per day.",
                                "Already in Queue",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        selectForm.DialogResult = DialogResult.OK;
                        selectForm.Tag = patientId;
                        selectForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select a patient.", "Selection Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                selectForm.Controls.AddRange(new Control[] { lblInstruction, dgv, btnSelect });

                if (selectForm.ShowDialog() == DialogResult.OK && selectForm.Tag != null)
                {
                    int patientId = (int)selectForm.Tag;

                    PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId);
                    intakeForm.FormClosed += (s, args) => LoadData();
                    intakeForm.ShowDialog();
                }
            }
        }

        private void BtnAssignDoctor_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            AssignDoctorForm assignForm = new AssignDoctorForm(queueId, patientName);
            assignForm.FormClosed += (s, args) => LoadData();
            assignForm.ShowDialog();
        }

        private void BtnCallNext_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to call.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            string doctorName = dgvQueue.SelectedRows[0].Cells["Doctor"].Value.ToString();

            if (doctorName == "Not Assigned")
            {
                MessageBox.Show(
                    "❌ CANNOT CALL PATIENT\n\n" +
                    "A doctor must be assigned before calling the patient.\n\n" +
                    "Please use 'Assign Doctor' button first.",
                    "Doctor Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (status != "Waiting")
            {
                MessageBox.Show("This patient is already being attended or completed.", "Invalid Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
                string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();
                int queueNumber = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_number"].Value);

                string query = @"UPDATE PatientQueue 
                               SET status = 'Called', called_time = NOW()
                               WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@queueId", queueId));

                MessageBox.Show($"Now calling: Queue #{queueNumber} - {patientName}", "Patient Called",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            int patientId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["patient_id"].Value);
            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    $"❌ CANNOT REMOVE COMPLETED PATIENT\n\n" +
                    $"Patient: {patientName}\n\n" +
                    "This patient has completed their visit.\n\n" +
                    "To discharge this patient:\n" +
                    "1. Go to the 'Billing' tab\n" +
                    "2. Create/Process their bill\n" +
                    "3. Use the 'Discharge Patient' button\n\n" +
                    "This ensures proper billing and discharge workflow.",
                    "Use Billing Tab",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Remove {patientName} from queue?\n\n" +
                $"Status: {status}\n\n" +
                "This will permanently remove them from today's queue.\n" +
                "Queue numbers will be automatically reordered.\n\n" +
                "Are you sure?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string deleteQuery = "DELETE FROM PatientQueue WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(deleteQuery,
                    new MySqlParameter("@queueId", queueId));

                MessageBox.Show(
                    $"✓ {patientName} removed from queue.\n\n" +
                    "Queue numbers have been reordered automatically.",
                    "Removed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing patient: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: true);
            intakeForm.ShowDialog();
        }

        private void BtnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: false);
            intakeForm.FormClosed += (s, args) => LoadData();
            intakeForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            RegisterForm createPatientForm = new RegisterForm(currentUser.UserId, currentUser.Role);

            if (createPatientForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "✓ Patient record has been created successfully!\n\n" +
                    "The patient is now registered in the system.\n\n" +
                    "To add them to the queue:\n" +
                    "1. Click 'Add to Queue' button\n" +
                    "2. Select the patient\n" +
                    "3. Complete the intake form",
                    "Patient Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
        }

        private void BtnCheckMedicalHistory_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to check their medical history.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

            try
            {
                string checkQuery = @"SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @patientId";
                int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                    new MySqlParameter("@patientId", patientId)));

                string checkVisitsQuery = @"SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = @patientId";
                int visitCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkVisitsQuery,
                    new MySqlParameter("@patientId", patientId)));

                if (recordCount == 0 && visitCount == 0)
                {
                    MessageBox.Show(
                        $"Patient: {patientName}\n\n" +
                        "✓ NEW PATIENT\n\n" +
                        "This patient has no previous medical records or visits.\n" +
                        "They are visiting the hospital for the first time.",
                        "Medical History - New Patient",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    ShowDetailedMedicalHistory(patientId, patientName, recordCount, visitCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking medical history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetailedMedicalHistory(int patientId, string patientName, int recordCount, int visitCount)
        {
            Form historyForm = new Form
            {
                Text = $"Medical History - {patientName}",
                Size = new Size(1200, 750),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.FromArgb(240, 245, 250)
            };

            Panel headerPanel = new Panel
            {
                BackColor = Color.FromArgb(156, 39, 176),
                Dock = DockStyle.Top,
                Height = 100
            };

            Label lblTitle = new Label
            {
                Text = $"📋 Complete Medical History - {patientName}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblStats = new Label
            {
                Text = $"Medical Records: {recordCount} | Total Visits: {visitCount}",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                Location = new Point(20, 50),
                AutoSize = true
            };

            Label lblInstruction = new Label
            {
                Text = "Double-click any record to view full medical documentation",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(220, 220, 220),
                Location = new Point(20, 75),
                AutoSize = true
            };

            headerPanel.Controls.AddRange(new Control[] { lblTitle, lblStats, lblInstruction });

            DataGridView dgvHistory = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1150, 520),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 40 }
            };

            string query = @"
                SELECT 
                mr.record_id,
                DATE_FORMAT(mr.record_date, '%Y-%m-%d %H:%i') AS 'Date & Time',
                mr.visit_type AS 'Visit Type',
                u.name AS 'Attending Doctor',
                CASE 
                    WHEN LENGTH(mr.diagnosis) > 100 
                    THEN CONCAT(SUBSTRING(mr.diagnosis, 1, 100), '...')
                    ELSE mr.diagnosis
                END AS 'Clinical Summary',
                CASE 
                    WHEN mr.prescription IS NOT NULL AND mr.prescription != '' 
                    THEN 'Yes' 
                    ELSE 'No' 
                END AS 'Rx',
                CASE 
                    WHEN mr.lab_tests IS NOT NULL AND mr.lab_tests != '' 
                    THEN 'Yes' 
                    ELSE 'No' 
                END AS 'Labs'
                FROM MedicalRecords mr
                INNER JOIN Doctors d ON mr.doctor_id = d.doctor_id
                INNER JOIN Users u ON d.user_id = u.user_id
                WHERE mr.patient_id = @patientId
                ORDER BY mr.record_date DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@patientId", patientId));
            dgvHistory.DataSource = dt;

            dgvHistory.DataBindingComplete += (s, ev) =>
            {
                if (dgvHistory.Columns["record_id"] != null)
                {
                    dgvHistory.Columns["record_id"].Visible = false;
                }
                if (dgvHistory.Columns["Date & Time"] != null)
                {
                    dgvHistory.Columns["Date & Time"].Width = 150;
                }
                if (dgvHistory.Columns["Visit Type"] != null)
                {
                    dgvHistory.Columns["Visit Type"].Width = 120;
                }
                if (dgvHistory.Columns["Attending Doctor"] != null)
                {
                    dgvHistory.Columns["Attending Doctor"].Width = 150;
                }
                if (dgvHistory.Columns["Rx"] != null)
                {
                    dgvHistory.Columns["Rx"].Width = 50;
                }
                if (dgvHistory.Columns["Labs"] != null)
                {
                    dgvHistory.Columns["Labs"].Width = 50;
                }
            };

            dgvHistory.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    int recordId = Convert.ToInt32(dgvHistory.Rows[ev.RowIndex].Cells["record_id"].Value);
                    ShowEnhancedMedicalRecord(recordId);
                }
            };

            Button btnViewDetails = new Button
            {
                Text = "👁️ View Full Record",
                Size = new Size(180, 45),
                Location = new Point(20, 660),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Click += (s, ev) =>
            {
                if (dgvHistory.SelectedRows.Count > 0)
                {
                    int recordId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["record_id"].Value);
                    ShowEnhancedMedicalRecord(recordId);
                }
                else
                {
                    MessageBox.Show("Please select a record to view.", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            Button btnPrint = new Button
            {
                Text = "🖨️ Print History",
                Size = new Size(150, 45),
                Location = new Point(210, 660),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Click += (s, ev) =>
            {
                MessageBox.Show("Print functionality will be implemented in future update.",
                    "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Button btnClose = new Button
            {
                Text = "✓ Close",
                Size = new Size(150, 45),
                Location = new Point(1020, 660),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, ev) => historyForm.Close();

            historyForm.Controls.AddRange(new Control[] {
                headerPanel, dgvHistory, btnViewDetails, btnPrint, btnClose
            });
            historyForm.ShowDialog();
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