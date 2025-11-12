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
                u.email,
                CASE 
                    WHEN NOT EXISTS (SELECT 1 FROM PatientQueue WHERE patient_id = p.patient_id) 
                    THEN 'Never Visited'
                    WHEN EXISTS (SELECT 1 FROM PatientQueue WHERE patient_id = p.patient_id AND queue_date = CURDATE())
                    THEN 'In Queue Today'
                    ELSE CONCAT('Last Visit: ', DATE_FORMAT(
                        (SELECT MAX(queue_date) FROM PatientQueue WHERE patient_id = p.patient_id), 
                        '%Y-%m-%d'))
                END AS status,
                (SELECT COUNT(*) FROM PatientQueue WHERE patient_id = p.patient_id) as total_visits
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            WHERE u.is_active = 1
            ORDER BY u.name";

                DataTable dtPatients = DatabaseHelper.ExecuteQuery(queryPatients);
                dgvPatients.DataSource = dtPatients;

                dgvPatients.DataBindingComplete += (s, ev) =>
                {
                    if (dgvPatients.Columns["patient_id"] != null)
                        dgvPatients.Columns["patient_id"].Visible = false;

                    if (dgvPatients.Columns["status"] != null)
                    {
                        dgvPatients.Columns["status"].HeaderText = "Visit Status";
                        dgvPatients.Columns["status"].Width = 200;
                    }

                    if (dgvPatients.Columns["total_visits"] != null)
                    {
                        dgvPatients.Columns["total_visits"].HeaderText = "Total Visits";
                        dgvPatients.Columns["total_visits"].Width = 80;
                    }

                    foreach (DataGridViewRow row in dgvPatients.Rows)
                    {
                        if (row.Cells["status"].Value != null)
                        {
                            string status = row.Cells["status"].Value.ToString();

                            if (status.Contains("Never Visited"))
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(140, 100, 0);
                            }
                            else if (status.Contains("In Queue Today"))
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 100, 0);
                            }
                        }
                    }
                };

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
            b.bill_id,
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
        WHEN b.status = 'Cancelled' THEN 'Discharge Allowed'
        ELSE 'Processing'
    END AS 'Discharge Status'
FROM (
    SELECT q1.*
    FROM patientqueue q1
    INNER JOIN (
        SELECT patient_id, MAX(completed_time) AS latest_completed
        FROM patientqueue
        WHERE status = 'Completed'
        GROUP BY patient_id
    ) latest
    ON q1.patient_id = latest.patient_id AND q1.completed_time = latest.latest_completed
) q
INNER JOIN Patients p ON q.patient_id = p.patient_id
INNER JOIN Users u ON p.user_id = u.user_id
LEFT JOIN (
    SELECT b1.*
    FROM Billing b1
    INNER JOIN (
        SELECT patient_id, MAX(bill_date) AS latest_bill
        FROM Billing
        GROUP BY patient_id
    ) latestBill
    ON b1.patient_id = latestBill.patient_id AND b1.bill_date = latestBill.latest_bill
) b ON b.patient_id = q.patient_id
WHERE q.status != 'Discharged'
ORDER BY 
    CASE 
        WHEN b.bill_id IS NULL THEN 1
        WHEN b.status = 'Pending' THEN 2
        WHEN b.status = 'Partially Paid' THEN 3
        WHEN b.status = 'Paid' THEN 4
        ELSE 5
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

        private bool HasPatientIntakeData(int patientId)
        {
            try
            {
                string query = @"
            SELECT COUNT(*) 
            FROM PatientQueue 
            WHERE patient_id = @patientId";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@patientId", patientId));

                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
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
                MessageBox.Show("Please select a patient first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvBilling.SelectedRows[0];
            object billIdObj = selectedRow.Cells["bill_id"].Value;
            object patientIdObj = selectedRow.Cells["patient_id"].Value;

            if (patientIdObj == DBNull.Value || patientIdObj == null)
            {
                MessageBox.Show("This patient record is invalid.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int patientId = Convert.ToInt32(patientIdObj);
            if (billIdObj == DBNull.Value || billIdObj == null)
            {
                MessageBox.Show(
                    "No bill found for this patient.\n\n" +
                    "Please create a bill first using the 'Create Bill' or 'Update Bill' button.",
                    "No Bill Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            int billId = Convert.ToInt32(billIdObj);
            int currentUserIdValue = currentUser?.UserId ?? 1;
            using (BillingForm billingForm = new BillingForm(currentUserIdValue, patientId, billId, viewOnly: true))
            {
                billingForm.ShowDialog();
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
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.Sizable,
                    MaximizeBox = true,
                    MinimumSize = new Size(800, 600),
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
                    Text = $"📋 Equipment & Services Report - Read Only",
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
                    Text = "This report was created by the doctor",
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
                    BackColor = Color.FromArgb(250, 250, 250),
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
                };

                Button btnCreateBill = new Button
                {
                    Text = "💳 Create Bill from This Report",
                    Size = new Size(250, 45),
                    Location = new Point(510, 590),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };
                btnCreateBill.FlatAppearance.BorderSize = 0;
                btnCreateBill.Click += (s, ev) =>
                {
                    int userId = currentUser.UserId;
                    reportView.Close();
                    BillingForm billingForm = new BillingForm(userId, patientId);
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
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
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
                            "• YES - View the report first (recommended)\n" +
                            "• NO - Go directly to create bill\n\n" +
                            "The billing form will auto-populate from the doctor's report.",
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

        private void BtnDoctorServiceReport_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view their service report.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();

            ShowEquipmentReportFromQueue(patientId, patientName);
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
        private void BtnCreateBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to create a bill.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvBilling.SelectedRows[0];
            object billIdObj = selectedRow.Cells["bill_id"].Value;
            object patientIdObj = selectedRow.Cells["patient_id"].Value;

            int billId = (billIdObj == DBNull.Value || billIdObj == null) ? 0 : Convert.ToInt32(billIdObj);
            int patientId = (patientIdObj == DBNull.Value || patientIdObj == null) ? 0 : Convert.ToInt32(patientIdObj);

            string patientName = selectedRow.Cells["Patient Name"].Value?.ToString() ?? "Unknown";

            if (billId > 0)
            {
                MessageBox.Show(
                    $"A bill already exists for patient: {patientName}.\n\n" +
                    "Use 'Update Bill' or 'View Bill' instead.",
                    "Bill Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int userId = currentUser?.UserId ?? 1;
            using (BillingForm billingForm = new BillingForm(userId, patientId))
            {
                var result = billingForm.ShowDialog();
                if (result == DialogResult.OK)
                    LoadBillingData();
            }
        }

        private void BtnUpdateBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBilling.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a bill to update.", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedRow = dgvBilling.SelectedRows[0];

                object billIdObj = selectedRow.Cells["bill_id"].Value;
                object patientIdObj = selectedRow.Cells["patient_id"].Value;

                if (billIdObj == DBNull.Value || billIdObj == null)
                {
                    MessageBox.Show("There is no existing bill for the selected patient. Use Create Bill instead.",
                        "No Bill Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (patientIdObj == DBNull.Value || patientIdObj == null)
                {
                    MessageBox.Show("Selected row does not contain a valid patient ID.", "Invalid Row",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int billId = Convert.ToInt32(billIdObj);
                int patientId = Convert.ToInt32(patientIdObj);

                int userId = currentUser?.UserId ?? 1;

                using (BillingForm billingForm = new BillingForm(userId, patientId, billId))
                {
                    var result = billingForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        LoadBillingData();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BtnUpdateBill_Click error: {ex}");
                MessageBox.Show("An error occurred while trying to open the bill: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDischargePatient_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to discharge.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvBilling.SelectedRows[0];
            object patientIdObj = selectedRow.Cells["patient_id"].Value;
            object billIdObj = selectedRow.Cells["bill_id"].Value;
            string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";
            string patientName = selectedRow.Cells["Patient Name"].Value?.ToString() ?? "Unknown";

            if (patientIdObj == DBNull.Value || patientIdObj == null)
            {
                MessageBox.Show("Invalid patient record.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int patientId = Convert.ToInt32(patientIdObj);

            if (status != "Paid" && status != "Cancelled")
            {
                MessageBox.Show(
                    $"Cannot discharge patient '{patientName}' yet.\n\n" +
                    $"Bill status must be 'Paid' or 'Cancelled'.\n" +
                    $"Current Status: {status}",
                    "Discharge Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string confirmMessage = $"🏥 DISCHARGE PATIENT: {patientName}\n\n" +
                "This will:\n" +
                "✓ Mark patient as 'Discharged'\n" +
                "✓ Remove from current queue\n" +
                "✓ Clear temporary intake data\n" +
                "✓ Archive billing records\n" +
                "✓ Clear equipment/service checklist\n\n" +
                "⚕️ Medical records will be PRESERVED\n\n" +
                "Patient can be re-added to queue for future visits.\n\n" +
                "Continue with discharge?";

            DialogResult result = MessageBox.Show(
                confirmMessage,
                "Confirm Patient Discharge",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string archiveVisitQuery = @"
                            INSERT INTO CompletedVisits (queue_id, patient_id, queue_date, completed_time, archived_by, archived_date, notes)
                            SELECT queue_id, patient_id, queue_date, completed_time, @archivedBy, NOW(), 
                                   CONCAT('Discharged: ', NOW(), ' - Billing Status: ', @billStatus)
                            FROM patientqueue
                            WHERE patient_id = @patientId 
                            AND status = 'Completed'
                            AND queue_date = CURDATE()";

                                using (var cmd = new MySqlCommand(archiveVisitQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    cmd.Parameters.AddWithValue("@archivedBy", currentUser.UserId);
                                    cmd.Parameters.AddWithValue("@billStatus", status);
                                    cmd.ExecuteNonQuery();
                                }

                                string dischargeQuery = @"
                            UPDATE patientqueue
                            SET status = 'Discharged', 
                                discharged_time = NOW(),
                                equipment_checklist = NULL
                            WHERE patient_id = @patientId
                            AND queue_date = CURDATE()
                            AND status IN ('Completed', 'In Progress', 'Called')";

                                using (var cmd = new MySqlCommand(dischargeQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    cmd.ExecuteNonQuery();
                                }

                                if (billIdObj != DBNull.Value && billIdObj != null)
                                {
                                    int billId = Convert.ToInt32(billIdObj);

                                    string archiveBillingQuery = @"
                                UPDATE CompletedVisits 
                                SET notes = CONCAT(notes, '\nBilling: Bill ID ', @billId, ' - Status: ', @status, ' - Archived on discharge')
                                WHERE patient_id = @patientId 
                                AND queue_date = CURDATE()
                                ORDER BY archived_date DESC
                                LIMIT 1";

                                    using (var cmd = new MySqlCommand(archiveBillingQuery, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@billId", billId);
                                        cmd.Parameters.AddWithValue("@status", status);
                                        cmd.Parameters.AddWithValue("@patientId", patientId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    string deleteBillServicesQuery = "DELETE FROM BillServices WHERE bill_id = @billId";
                                    using (var cmd = new MySqlCommand(deleteBillServicesQuery, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@billId", billId);
                                        cmd.ExecuteNonQuery();
                                    }

                                    string deleteBillingQuery = "DELETE FROM Billing WHERE bill_id = @billId";
                                    using (var cmd = new MySqlCommand(deleteBillingQuery, conn, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@billId", billId);
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                                string clearIntakeQuery = @"
                            UPDATE patientqueue
                            SET reason_for_visit = NULL
                            WHERE patient_id = @patientId
                            AND queue_date = CURDATE()";

                                using (var cmd = new MySqlCommand(clearIntakeQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    cmd.ExecuteNonQuery();
                                }

                                string deleteQueueQuery = @"
                            DELETE FROM patientqueue
                            WHERE patient_id = @patientId
                            AND queue_date = CURDATE()
                            AND status = 'Discharged'";

                                using (var cmd = new MySqlCommand(deleteQueueQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                MessageBox.Show(
                                    $"✅ PATIENT DISCHARGED SUCCESSFULLY\n\n" +
                                    $"Patient: {patientName}\n\n" +
                                    "Actions completed:\n" +
                                    "✓ Visit archived to CompletedVisits\n" +
                                    "✓ Billing record archived and cleared\n" +
                                    "✓ Equipment checklist cleared\n" +
                                    "✓ Intake data cleared\n" +
                                    "✓ Removed from today's queue\n\n" +
                                    "⚕️ Medical records preserved\n\n" +
                                    "Patient can now be re-added to queue for future visits.",
                                    "Discharge Complete",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                LoadData();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw new Exception($"Transaction failed: {ex.Message}", ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"❌ ERROR DURING DISCHARGE\n\n" +
                        $"Error: {ex.Message}\n\n" +
                        "The discharge process was rolled back.\n" +
                        "No changes were made.\n\n" +
                        "Please try again or contact support.",
                        "Discharge Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private bool CanPatientBeQueued(int patientId)
        {
            try
            {
                string query = @"
            SELECT COUNT(*) 
            FROM patientqueue 
            WHERE patient_id = @patientId 
            AND queue_date = CURDATE()
            AND status != 'Discharged'";

                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@patientId", patientId)));

                return count == 0;
            }
            catch
            {
                return false;
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
                SELECT 
                p.patient_id, 
                u.name, 
                u.age, 
                u.gender, 
                COALESCE(p.blood_type, 'Unknown') AS blood_type,
                CASE 
                WHEN NOT EXISTS (
                SELECT 1 FROM PatientQueue 
                WHERE patient_id = p.patient_id 
                AND queue_date = CURDATE()
                ) THEN 'Available for Queue'
                WHEN EXISTS (
                SELECT 1 FROM PatientQueue 
                WHERE patient_id = p.patient_id 
                AND queue_date = CURDATE()
                AND status = 'Discharged'
                ) THEN 'Recently Discharged - Can Re-queue'
                ELSE 'Already in Queue'
                END AS queue_status,
                CASE 
                WHEN NOT EXISTS (SELECT 1 FROM CompletedVisits WHERE patient_id = p.patient_id) 
                THEN 'First Visit'
                ELSE CONCAT('Previous Visits: ', 
                CAST((SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = p.patient_id) AS CHAR))
                END AS visit_info
                FROM Patients p
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.is_active = 1
                AND NOT EXISTS (
                SELECT 1 FROM patientqueue 
                WHERE patient_id = p.patient_id 
                AND queue_date = CURDATE()
                AND status NOT IN ('Discharged')
                )
                ORDER BY u.name";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgv.DataSource = dt;

                if (dgv.Columns["patient_id"] != null)
                {
                    dgv.Columns["patient_id"].Visible = false;
                }

                if (dgv.Columns["name"] != null)
                    dgv.Columns["name"].HeaderText = "Patient Name";
                if (dgv.Columns["age"] != null)
                    dgv.Columns["age"].HeaderText = "Age";
                if (dgv.Columns["gender"] != null)
                    dgv.Columns["gender"].HeaderText = "Gender";
                if (dgv.Columns["blood_type"] != null)
                    dgv.Columns["blood_type"].HeaderText = "Blood Type";
                if (dgv.Columns["visit_info"] != null)
                    dgv.Columns["visit_info"].HeaderText = "Visit History";

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

                    using (PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId))
                    {
                        intakeForm.ShowDialog();
                    }

                    LoadData();
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

            if (!HasPatientIntakeData(patientId))
            {
                MessageBox.Show(
                    "No intake data found for this patient.\n\n" +
                    "This patient has not been added to the queue yet,\n" +
                    "so there is no intake information to view.",
                    "No Data Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: true))
            {
                intakeForm.ShowDialog();
            }
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

            using (PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: true))
            {
                intakeForm.ShowDialog();
            }
            LoadData();
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
                    "✓ Patient record created successfully!\n\n" +
                    "The patient is now registered in the system.\n\n" +
                    "To add them to today's queue:\n" +
                    "1. Go to 'Patient Queue' tab\n" +
                    "2. Click 'Add to Queue'\n" +
                    "3. Select the patient\n" +
                    "4. Complete the intake form",
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