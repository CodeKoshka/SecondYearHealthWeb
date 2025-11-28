using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class AdminDashboard : Form
    {
        private User currentUser;
        private byte[] currentUserProfileImage;
        private ListBox searchSuggestionsListBox;
        private Label lblSection;
        private System.Threading.Timer searchDebounceTimer;
        private const int SEARCH_DEBOUNCE_MS = 300;
        private Label lblSearchStatus;

        public AdminDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            ApplyStyle();
            ApplyRoleBasedAccess();
            UpdateUserDisplay();
            ConfigureAllDataGridViews();
            ConfigureBillingGrids();
            InitializeUniversalSearch();
            LoadData();
            LoadUserProfile();
        }

        private void ApplyStyle()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1200, 700);
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            Color sidebarBg = Color.FromArgb(26, 32, 44);
            Color sidebarHover = Color.FromArgb(45, 55, 72);
            Color accentColor = Color.FromArgb(66, 153, 225);

            panelSidebar.BackColor = sidebarBg;
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Width = 280;

            panelHeader.BackColor = Color.FromArgb(0, 102, 204);
            panelHeader.Height = 70;
            panelHeader.Dock = DockStyle.Top;

            Panel headerShadow = new Panel();
            headerShadow.Dock = DockStyle.Bottom;
            headerShadow.Height = 1;
            headerShadow.BackColor = Color.FromArgb(226, 232, 240);
            panelHeader.Controls.Add(headerShadow);
            headerShadow.BringToFront();

            lblHospitalName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHospitalName.ForeColor = Color.FromArgb(224, 224, 224);
            lblHospitalName.Location = new Point(28, 8);
            lblHospitalName.AutoSize = true;

            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.Location = new Point(65, 44);
            pictureBoxProfile.Size = new Size(150, 150);

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

            lblSection = new Label();
            lblSection.Text = "OVERVIEW";
            lblSection.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSection.ForeColor = Color.FromArgb(113, 128, 150);
            lblSection.Location = new Point(25, 265);
            lblSection.AutoSize = true;
            panelSidebar.Controls.Add(lblSection);

            UpdateMenuButton(btnUsersMenu, 290, "👥", "User Management");
            UpdateMenuButton(btnMedicalRecordsMenu, 345, "📋", "Medical Records");
            UpdateMenuButton(btnBillingMenu, 400, "💰", "Billing And Payments");

            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);
            btnLogout.Size = new Size(250, 50);
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.Location = new Point(15, panelSidebar.Height - btnLogout.Height - 20);

            panelUniversalSearch.Anchor = AnchorStyles.None;

            this.Resize += (s, e) =>
            {
                CenterSearchBar();
                RepositionBillingComponents();
            };

            tabControl.SelectedIndexChanged += (s, e) =>
            {
                if (tabControl.SelectedIndex == 2)
                {
                    RepositionBillingComponents();
                }
            };

            CenterSearchBar();

            panelHeaderRight.Visible = false;

            SwitchToTab(0);
        }

        private void ApplyRoleBasedAccess()
        {
            if (currentUser.Role == "Admin")
            {
                btnBillingMenu.Visible = false;
            }
            else if (currentUser.Role == "Headadmin")
            {
                btnBillingMenu.Visible = true;
            }
            if (currentUser.Role == "Admin")
            {
                if (tabControl.TabPages.Contains(tabBilling))
                {
                    tabControl.TabPages.Remove(tabBilling);
                }
            }
        }

        private void CenterSearchBar()
        {
            if (panelHeader != null && panelUniversalSearch != null)
            {
                int centerX = (panelHeader.Width - panelUniversalSearch.Width) / 2;
                panelUniversalSearch.Location = new Point(centerX, 15);
            }
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
                if (btn.BackColor != Color.FromArgb(66, 153, 225))
                    btn.BackColor = Color.FromArgb(45, 55, 72);
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn.BackColor != Color.FromArgb(66, 153, 225))
                    btn.BackColor = Color.Transparent;
            };
        }

        private void UpdateUserDisplay()
        {
            lblWelcome.Text = $"Welcome, {currentUser.Name}";
            lblRole.Text = $"Role: {currentUser.Role}";
        }

        public void RefreshUserData()
        {
            try
            {
                string query = "SELECT name, role, email, profile_image FROM Users WHERE user_id = @userId";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@userId", currentUser.UserId));

                if (dt.Rows.Count > 0)
                {
                    currentUser.Name = dt.Rows[0]["name"].ToString();
                    currentUser.Role = dt.Rows[0]["role"].ToString();
                    currentUser.Email = dt.Rows[0]["email"].ToString();

                    UpdateUserDisplay();
                    LoadUserProfile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing user data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureAllDataGridViews()
        {
            if (dgvUsers != null)
            {
                ConfigureDataGridView(dgvUsers);
                dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            }
            if (dgvAdmins != null)
            {
                ConfigureDataGridView(dgvAdmins);
                dgvAdmins.SelectionChanged += DgvUsers_SelectionChanged;
            }
            if (dgvDoctors != null)
            {
                ConfigureDataGridView(dgvDoctors);
                dgvDoctors.SelectionChanged += DgvUsers_SelectionChanged;
            }
            if (dgvPatients != null) ConfigureDataGridView(dgvPatients);
            if (dgvStaff != null)
            {
                ConfigureDataGridView(dgvStaff);
                dgvStaff.SelectionChanged += DgvUsers_SelectionChanged;
            }
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null || dgv.SelectedRows.Count == 0)
            {
                btnToggleAccountStatus.Visible = false;
                return;
            }

            var userIdCell = dgv.SelectedRows[0].Cells["User ID"];
            var roleCell = dgv.SelectedRows[0].Cells["Role"];

            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                btnToggleAccountStatus.Visible = false;
                return;
            }

            string uniqueId = userIdCell.Value.ToString();
            string role = roleCell?.Value?.ToString() ?? "";

            string getUserQuery = @"SELECT user_id, is_active, email, role FROM Users WHERE unique_id = @uniqueId";
            DataTable dt = DatabaseHelper.ExecuteQuery(getUserQuery,
                new MySqlParameter("@uniqueId", uniqueId));

            if (dt.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);
                bool isActive = Convert.ToBoolean(dt.Rows[0]["is_active"]);
                string email = dt.Rows[0]["email"]?.ToString() ?? "";
                string userRole = dt.Rows[0]["role"]?.ToString() ?? "";


                if (userRole == "Headadmin" && isActive)
                {
                    btnToggleAccountStatus.Visible = false;
                    return;
                }

                if (userId == currentUser.UserId && isActive)
                {
                    btnToggleAccountStatus.Visible = false;
                    return;
                }

                btnToggleAccountStatus.Visible = true;

                if (isActive)
                {
                    btnToggleAccountStatus.Text = "🔒 Deactivate Account";
                    btnToggleAccountStatus.BackColor = Color.FromArgb(231, 76, 60);
                }
                else
                {
                    btnToggleAccountStatus.Text = "🔓 Activate Account";
                    btnToggleAccountStatus.BackColor = Color.FromArgb(46, 204, 113);
                }
            }
            else
            {
                btnToggleAccountStatus.Visible = false;
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

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
            dgv.AllowUserToResizeColumns = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Dock = DockStyle.Fill;

            bool isBillingGrid = (dgv == dgvBilling || dgv == dgvDischargedBills);

            if (isBillingGrid)
            {
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 153, 225);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 153, 225);
                dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
                dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dgv.ColumnHeadersHeight = 40;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
                dgv.DefaultCellStyle.Padding = new Padding(8, 3, 8, 3);
                dgv.RowTemplate.Height = 35;
            }
            else
            {
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 153, 225);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 153, 225);
                dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
                dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dgv.ColumnHeadersHeight = 50;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
                dgv.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
                dgv.RowTemplate.Height = 45;
            }

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);

            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            dgv.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;

                    string originalName = column.DataPropertyName;
                    if (!string.IsNullOrWhiteSpace(originalName))
                    {
                        column.HeaderText = RenameColumns(originalName);
                    }
                }

                if (dgv == dgvUsers || dgv == dgvAdmins || dgv == dgvDoctors || dgv == dgvStaff)
                {
                    HideStatusColumnAndHighlight(dgv);
                }
            };

            dgv.RowPostPaint -= DgvUniversal_RowPostPaint;
            dgv.RowPostPaint += DgvUniversal_RowPostPaint;
        }

        private void ConfigureBillingGrids()
        {
            ConfigureDataGridView(dgvBilling);
            dgvBilling.Dock = DockStyle.Fill;

            ConfigureDataGridView(dgvDischargedBills);
            dgvDischargedBills.Dock = DockStyle.Fill;

            System.Diagnostics.Debug.WriteLine("[AdminDashboard] Billing grids configured with full styling");
        }

        private void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv == null) return;

                if (dgv.Columns.Count == 0 && dgv.DataSource != null)
                {
                    if (dgv.BindingContext == null)
                    {
                        dgv.BindingContext = new BindingContext();
                    }

                    dgv.Refresh();
                    Application.DoEvents();
                }

                if (dgv.Columns == null || dgv.Columns.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"[ConfigureDataGridView] No columns generated for {dgv.Name}");
                    return;
                }

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column == null) continue;

                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Resizable = DataGridViewTriState.False;

                    string friendlyName = RenameColumns(column.Name);
                    column.HeaderText = friendlyName;

                    string columnNameLower = (column.Name ?? "").ToLower();

                    try
                    {
                        if (columnNameLower.Contains("id"))
                        {
                            column.MinimumWidth = 80;
                        }
                        else if (columnNameLower.Contains("name"))
                        {
                            column.MinimumWidth = 150;
                        }
                        else if (columnNameLower.Contains("date") || columnNameLower.Contains("time"))
                        {
                            column.MinimumWidth = 140;
                        }
                        else if (columnNameLower.Contains("amount") || columnNameLower.Contains("total") ||
                                 columnNameLower.Contains("price") || columnNameLower.Contains("cost"))
                        {
                            column.MinimumWidth = 120;
                        }
                        else if (columnNameLower.Contains("email"))
                        {
                            column.MinimumWidth = 180;
                        }
                        else if (columnNameLower.Contains("phone") || columnNameLower.Contains("contact"))
                        {
                            column.MinimumWidth = 130;
                        }
                        else
                        {
                            column.MinimumWidth = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"[ConfigureDataGridView] Error setting MinimumWidth for column '{column.Name}': {ex.Message}");
                    }
                }

                if (dgv == dgvUsers || dgv == dgvAdmins || dgv == dgvDoctors || dgv == dgvStaff)
                {
                    HideStatusColumnAndHighlight(dgv);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ConfigureDataGridView] DataBindingComplete error: {ex.Message}");
            }
        }

        private string RenameColumns(string columnName)
        {
            var columnMappings = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
        {"user_id", "User ID"},
        {"name", "Name"},
        {"role", "Role"},
        {"email", "Email Address"},
        {"created_date", "Date Created"},
        {"age", "Age"},
        {"gender", "Gender"},
        {"is_active", "Status"},

        {"patient_id", "Patient ID"},
        {"Patient Name", "Patient Name"},
        {"blood_type", "Blood Type"},
        {"Blood Type", "Blood Type"},
        {"phone_number", "Phone Number"},
        {"Contact", "Contact Number"},
        {"emergency_contact", "Emergency Contact"},
        {"allergies", "Allergies"},
        {"medical_history", "Medical History"},
        {"Medical Records", "Medical Records"},
        {"Appointments", "Appointments"},

        {"bill_id", "Bill ID"},
        {"Bill ID", "Bill ID"},
        {"amount", "Amount"},
        {"Total Amount", "Total Amount"},
        {"subtotal", "Subtotal"},
        {"discount_percent", "Discount %"},
        {"discount_amount", "Discount Amount"},
        {"Discount", "Discount"},
        {"Discount Amount", "Discount Amount"},
        {"tax_percent", "Tax %"},
        {"tax_amount", "Tax Amount"},
        {"Tax", "Tax"},
        {"Tax Amount", "Tax Amount"},
        {"payment_method", "Payment Method"},
        {"Payment Method", "Payment Method"},
        {"status", "Status"},
        {"bill_date", "Bill Date"},
        {"Bill Date", "Bill Date"},
        {"discharged_time", "Discharged Date"},
        {"Discharged Date", "Discharged Date"},
        {"created_by", "Created By"},
        {"Created By", "Created By"},

        {"queue_id", "Queue ID"},
        {"queue_number", "Queue #"},
        {"priority", "Priority"},
        {"reason_for_visit", "Reason for Visit"},
        {"queue_date", "Queue Date"},
        {"registered_time", "Registered Time"},

        {"doctor_id", "Doctor ID"},
        {"specialization", "Specialization"},
        {"license_number", "License Number"},

        {"record_id", "Record ID"},
        {"diagnosis", "Diagnosis"},
        {"prescription", "Prescription"},
        {"lab_tests", "Lab Tests"},
        {"visit_type", "Visit Type"},
        {"record_date", "Record Date"}
        };

            if (columnMappings.ContainsKey(columnName))
                return columnMappings[columnName];

            return System.Globalization.CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(columnName.Replace("_", " ").ToLower());
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
                    Color slabColor = Color.FromArgb(66, 153, 225);
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
            lblSearchStatus = new Label();
            lblSearchStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSearchStatus.ForeColor = Color.FromArgb(113, 128, 150);
            lblSearchStatus.Visible = false;
            lblSearchStatus.AutoSize = true;
            lblSearchStatus.Name = "lblSearchStatus";

            Panel suggestionsContainer = new Panel();
            suggestionsContainer.BackColor = Color.Transparent;
            suggestionsContainer.Visible = false;
            suggestionsContainer.Name = "suggestionsContainer";

            searchSuggestionsListBox = new ListBox();
            searchSuggestionsListBox.Font = new Font("Segoe UI", 10F);
            searchSuggestionsListBox.BorderStyle = BorderStyle.None;
            searchSuggestionsListBox.BackColor = Color.White;
            searchSuggestionsListBox.ForeColor = Color.FromArgb(26, 32, 44);
            searchSuggestionsListBox.IntegralHeight = false;
            searchSuggestionsListBox.DrawMode = DrawMode.OwnerDrawFixed;
            searchSuggestionsListBox.ItemHeight = 50;
            searchSuggestionsListBox.Click += SearchSuggestionsListBox_Click;
            searchSuggestionsListBox.KeyDown += SearchSuggestionsListBox_KeyDown;
            searchSuggestionsListBox.MouseMove += SearchSuggestionsListBox_MouseMove;

            searchSuggestionsListBox.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.DrawBackground();

                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                if (isSelected)
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(237, 242, 247)))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                }

                if (searchSuggestionsListBox.Items[e.Index] is UniversalSearchItem item)
                {
                    int photoSize = 36;
                    int photoX = e.Bounds.X + 8;
                    int photoY = e.Bounds.Y + (e.Bounds.Height - photoSize) / 2;

                    Image profileImage = null;
                    if (item.Data != null)
                    {
                        if (item.Source == "Users" && item.Data.Table.Columns.Contains("profile_image"))
                        {
                            if (item.Data["profile_image"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])item.Data["profile_image"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    profileImage = Image.FromStream(ms);
                                }
                            }
                        }
                        else if ((item.Source == "Patients" || item.Source == "Billing") &&
                                 item.Data.Table.Columns.Contains("patient_image"))
                        {
                            if (item.Data["patient_image"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])item.Data["patient_image"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    profileImage = Image.FromStream(ms);
                                }
                            }
                        }
                    }

                    if (profileImage != null)
                    {
                        int circleSize = Math.Min(photoSize, e.Bounds.Height - 10);
                        int offsetY = e.Bounds.Y + (e.Bounds.Height - circleSize) / 2;

                        using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            gp.AddEllipse(photoX, offsetY, circleSize, circleSize);
                            using (Region clip = new Region(gp))
                            {
                                e.Graphics.SetClip(clip, System.Drawing.Drawing2D.CombineMode.Replace);
                                e.Graphics.DrawImage(profileImage, photoX, offsetY, circleSize, circleSize);
                                e.Graphics.ResetClip();

                                using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 2))
                                    e.Graphics.DrawEllipse(borderPen, photoX, offsetY, circleSize, circleSize);
                            }
                        }
                    }
                    else
                    {
                        using (SolidBrush iconBg = new SolidBrush(GetCategoryColor(item.Source)))
                        {
                            e.Graphics.FillEllipse(iconBg, photoX, photoY, photoSize, photoSize);
                        }

                        string icon = GetCategoryIcon(item.Source);
                        using (Font iconFont = new Font("Segoe UI Emoji", 16F))
                        using (SolidBrush iconBrush = new SolidBrush(Color.White))
                        {
                            SizeF iconSize = e.Graphics.MeasureString(icon, iconFont);
                            e.Graphics.DrawString(icon, iconFont, iconBrush,
                                photoX + (photoSize - iconSize.Width) / 2,
                                photoY + (photoSize - iconSize.Height) / 2);
                        }
                    }

                    string searchTerm = txtUniversalSearch.Text.Trim();
                    string displayText = item.DisplayText;

                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(26, 32, 44)))
                    using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(66, 153, 225)))
                    using (Font boldFont = new Font(e.Font, FontStyle.Bold))
                    {
                        float x = photoX + photoSize + 12;
                        float y = e.Bounds.Y + (e.Bounds.Height - e.Font.GetHeight(e.Graphics)) / 2;

                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            int index = displayText.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);
                            if (index >= 0)
                            {
                                string before = displayText.Substring(0, index);
                                string match = displayText.Substring(index, Math.Min(searchTerm.Length, displayText.Length - index));
                                string after = displayText.Substring(index + match.Length);

                                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                                using (StringFormat format = new StringFormat(StringFormat.GenericTypographic))
                                {
                                    float currentX = x;

                                    if (!string.IsNullOrEmpty(before))
                                    {
                                        e.Graphics.DrawString(before, e.Font, textBrush, currentX, y, format);
                                        SizeF beforeSize = e.Graphics.MeasureString(before, e.Font, new PointF(currentX, y), format);
                                        currentX += beforeSize.Width;
                                    }

                                    if (!string.IsNullOrEmpty(match))
                                    {
                                        e.Graphics.DrawString(match, boldFont, highlightBrush, currentX, y, format);
                                        SizeF matchSize = e.Graphics.MeasureString(match, boldFont, new PointF(currentX, y), format);
                                        currentX += matchSize.Width;
                                    }

                                    if (!string.IsNullOrEmpty(after))
                                    {
                                        e.Graphics.DrawString(after, e.Font, textBrush, currentX, y, format);
                                    }
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(displayText, e.Font, textBrush, x, y);
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(displayText, e.Font, textBrush, x, y);
                        }
                    }
                }

                if (e.Index < searchSuggestionsListBox.Items.Count - 1)
                {
                    using (Pen pen = new Pen(Color.FromArgb(226, 232, 240)))
                    {
                        e.Graphics.DrawLine(pen,
                            e.Bounds.Left + 15,
                            e.Bounds.Bottom - 1,
                            e.Bounds.Right - 15,
                            e.Bounds.Bottom - 1);
                    }
                }

                e.DrawFocusRectangle();
            };

            Panel suggestionsShadow = new Panel();
            suggestionsShadow.BackColor = Color.FromArgb(40, 0, 0, 0);
            suggestionsShadow.Visible = false;
            suggestionsShadow.Name = "suggestionsShadow";

            this.Controls.Add(lblSearchStatus);
            this.Controls.Add(suggestionsContainer);
            this.Controls.Add(suggestionsShadow);
            suggestionsContainer.Controls.Add(searchSuggestionsListBox);

            suggestionsShadow.SendToBack();
            suggestionsContainer.BringToFront();

            searchSuggestionsListBox.Tag = new
            {
                Container = suggestionsContainer,
                Shadow = suggestionsShadow
            };
        }

        private Color GetCategoryColor(string source)
        {
            switch (source)
            {
                case "Users": return Color.FromArgb(66, 153, 225);
                case "Patients": return Color.FromArgb(72, 187, 120);
                case "Billing": return Color.FromArgb(237, 137, 54);
                default: return Color.FromArgb(113, 128, 150);
            }
        }

        private string GetCategoryIcon(string source)
        {
            switch (source)
            {
                case "Users": return "👤";
                case "Patients": return "📋";
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
                        pictureBoxProfile.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    SetDefaultProfileImage();
                }
            }
            catch
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
                LoadUsersData();

                string queryPatients = @"
            SELECT 
                p.patient_id AS 'Patient ID',
                u.name AS 'Patient Name',
                u.age AS 'Age',
                u.gender AS 'Gender',
                p.blood_type AS 'Blood Type',
                p.phone_number AS 'Contact Number',
                COUNT(DISTINCT mr.record_id) AS 'Medical Records',
                COUNT(DISTINCT a.appointment_id) AS 'Appointments'
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            LEFT JOIN medicalrecords mr ON p.patient_id = mr.patient_id
            LEFT JOIN Appointments a ON p.patient_id = a.patient_id
            WHERE u.is_active = 1
            GROUP BY p.patient_id, u.name, u.age, u.gender, p.blood_type, p.phone_number
            ORDER BY u.name";

                DataTable patientsData = DatabaseHelper.ExecuteQuery(queryPatients);

                if (dgvPatients.BindingContext == null)
                {
                    dgvPatients.BindingContext = this.BindingContext ?? new BindingContext();
                }

                dgvPatients.DataSource = patientsData;

                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] Loaded {patientsData.Rows.Count} patients into Medical Records tab");

                LoadBillingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] LoadData error: {ex.Message}");
            }
        }

        private void LoadBillingData()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[AdminDashboard] LoadBillingData started");

                string queryActiveBilling = @"
            SELECT 
                b.bill_id AS 'Bill ID',
                u.name AS 'Patient Name',
                DATE_FORMAT(b.bill_date, '%Y-%m-%d %H:%i') AS 'Bill Date',
                CONCAT('₱', FORMAT(b.subtotal, 2)) AS 'Subtotal',
                CONCAT(b.discount_percent, '%') AS 'Discount',
                CONCAT('₱', FORMAT(b.discount_amount, 2)) AS 'Discount Amount',
                CONCAT(b.tax_percent, '%') AS 'Tax',
                CONCAT('₱', FORMAT(b.tax_amount, 2)) AS 'Tax Amount',
                CONCAT('₱', FORMAT(b.amount, 2)) AS 'Total Amount',
                b.payment_method AS 'Payment Method',
                b.status AS 'Status',
                creator.name AS 'Created By'
            FROM Billing b
            INNER JOIN Patients p ON b.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            LEFT JOIN Users creator ON b.created_by = creator.user_id
            LEFT JOIN patientqueue pq ON b.queue_id = pq.queue_id
            WHERE (pq.status IS NULL OR pq.status != 'Discharged')
            ORDER BY b.bill_date DESC";

                DataTable activeBillingData = DatabaseHelper.ExecuteQuery(queryActiveBilling);
                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] Loaded {activeBillingData.Rows.Count} active bills");

                string queryDischargedBilling = @"
            SELECT 
                b.bill_id AS 'Bill ID',
                u.name AS 'Patient Name',
                DATE_FORMAT(b.bill_date, '%Y-%m-%d %H:%i') AS 'Bill Date',
                DATE_FORMAT(pq.discharged_time, '%Y-%m-%d %H:%i') AS 'Discharged Date',
                CONCAT('₱', FORMAT(b.amount, 2)) AS 'Total Amount',
                b.payment_method AS 'Payment Method',
                b.status AS 'Status',
                creator.name AS 'Created By'
            FROM Billing b
            INNER JOIN Patients p ON b.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            INNER JOIN patientqueue pq ON b.queue_id = pq.queue_id AND pq.status = 'Discharged'
            LEFT JOIN Users creator ON b.created_by = creator.user_id
            ORDER BY pq.discharged_time DESC";

                DataTable dischargedBillingData = DatabaseHelper.ExecuteQuery(queryDischargedBilling);
                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] Loaded {dischargedBillingData.Rows.Count} discharged bills");

                dgvBilling.DataSource = null;
                dgvBilling.Columns.Clear();
                dgvBilling.AutoGenerateColumns = true;
                dgvBilling.DataSource = activeBillingData;
                dgvBilling.Refresh();

                dgvDischargedBills.DataSource = null;
                dgvDischargedBills.Columns.Clear();
                dgvDischargedBills.AutoGenerateColumns = true;
                dgvDischargedBills.DataSource = dischargedBillingData;
                dgvDischargedBills.Refresh();

                foreach (DataGridView dgv in new[] { dgvBilling, dgvDischargedBills })
                {
                    if (dgv.Columns.Contains("Status"))
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.Cells["Status"].Value != null)
                            {
                                string status = row.Cells["Status"].Value.ToString();
                                switch (status.ToUpper())
                                {
                                    case "PAID":
                                        row.Cells["Status"].Style.BackColor = Color.FromArgb(46, 204, 113);
                                        row.Cells["Status"].Style.ForeColor = Color.White;
                                        row.Cells["Status"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                                        break;
                                    case "PENDING":
                                        row.Cells["Status"].Style.BackColor = Color.FromArgb(241, 196, 15);
                                        row.Cells["Status"].Style.ForeColor = Color.White;
                                        row.Cells["Status"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                                        break;
                                    case "PARTIALLY PAID":
                                        row.Cells["Status"].Style.BackColor = Color.FromArgb(52, 152, 219);
                                        row.Cells["Status"].Style.ForeColor = Color.White;
                                        row.Cells["Status"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                                        break;
                                    case "CANCELLED":
                                        row.Cells["Status"].Style.BackColor = Color.FromArgb(231, 76, 60);
                                        row.Cells["Status"].Style.ForeColor = Color.White;
                                        row.Cells["Status"].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                                        break;
                                }
                            }
                        }
                    }
                }

                dgvDischargedBills.Visible = true;
                dgvDischargedBills.BringToFront();
                dgvDischargedBills.Refresh();
                Application.DoEvents();

                System.Diagnostics.Debug.WriteLine($"[DEBUG] Discharged Bills - Rows: {dgvDischargedBills.Rows.Count}, Visible: {dgvDischargedBills.Visible}");

                UpdateBillingStatistics(activeBillingData, dischargedBillingData);
                RepositionBillingComponents();

                System.Diagnostics.Debug.WriteLine("[AdminDashboard] LoadBillingData completed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing data: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] LoadBillingData error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void UpdateBillingStatistics(DataTable activeData, DataTable dischargedData)
        {
            try
            {
                int pendingCount = 0;
                int partiallyPaidCount = 0;
                int paidCount = 0;
                int cancelledCount = 0;
                decimal paidAmount = 0;

                foreach (DataRow row in activeData.Rows)
                {
                    string status = row["Status"].ToString();
                    decimal amount = 0;

                    string amountStr = row["Total Amount"].ToString();
                    amountStr = amountStr.Replace("₱", "").Replace(",", "").Trim();
                    if (decimal.TryParse(amountStr, out amount))
                    {
                        switch (status)
                        {
                            case "Pending":
                                pendingCount++;
                                break;
                            case "Partially Paid":
                                partiallyPaidCount++;
                                break;
                            case "Paid":
                                paidCount++;
                                paidAmount += amount;
                                break;
                            case "Cancelled":
                                cancelledCount++;
                                break;
                        }
                    }
                }

                foreach (DataRow row in dischargedData.Rows)
                {
                    string status = row["Status"].ToString();
                    if (status == "Paid")
                    {
                        paidCount++;

                        decimal amount = 0;
                        string amountStr = row["Total Amount"].ToString();
                        amountStr = amountStr.Replace("₱", "").Replace(",", "").Trim();
                        if (decimal.TryParse(amountStr, out amount))
                        {
                            paidAmount += amount;
                        }
                    }
                }

                int totalDischargedCount = dischargedData.Rows.Count;
                int totalActiveCount = activeData.Rows.Count;

                panelBillingStats.Controls.Clear();

                Label lblStatsTitle = new Label
                {
                    Text = $"📊 Billing Statistics Overview",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                panelBillingStats.Controls.Add(lblStatsTitle);
                lblStatsTitle.Left = (panelBillingStats.Width - lblStatsTitle.Width) / 2;
                lblStatsTitle.Top = 8;

                int cardWidth = 210;
                int cardSpacing = 20;
                int totalCardsWidth = (cardWidth * 5) + (cardSpacing * 4);
                int startX = (panelBillingStats.Width - totalCardsWidth) / 2;
                int cardY = 35;

                Panel cardPaid = CreateStatCard($"💰 Paid Bills", paidCount,
                    $"₱{paidAmount:N2}", Color.FromArgb(46, 204, 113), startX, cardY);

                Panel cardPending = CreateStatCard($"⏳ Pending Bills", pendingCount,
                    "Awaiting Payment", Color.FromArgb(241, 196, 15), startX + (cardWidth + cardSpacing), cardY);

                Panel cardPartial = CreateStatCard($"📊 Partially Paid", partiallyPaidCount,
                    "In Progress", Color.FromArgb(52, 152, 219), startX + (cardWidth + cardSpacing) * 2, cardY);

                Panel cardDischarged = CreateStatCard($"✅ Discharged & Completed", totalDischargedCount,
                    "Archived", Color.FromArgb(155, 89, 182), startX + (cardWidth + cardSpacing) * 3, cardY);

                Panel cardCancelled = CreateStatCard($"🚫 Cancelled", cancelledCount,
                    "No Payment", Color.FromArgb(231, 76, 60), startX + (cardWidth + cardSpacing) * 4, cardY);

                panelBillingStats.Controls.AddRange(new Control[] {
            cardPaid, cardPending, cardPartial, cardDischarged, cardCancelled});

                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] Stats - Paid: {paidCount} (₱{paidAmount:N2}), Pending: {pendingCount}, Discharged: {totalDischargedCount}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating billing statistics: {ex.Message}");
            }
        }

        private void RepositionBillingComponents()
        {
            if (panelBillingStats == null || !panelBillingStats.IsHandleCreated)
                return;

            int contentWidth = 1595;

            panelBillingButtons.Location = new Point(20, 20);
            panelBillingButtons.Size = new Size(contentWidth, 80);

            panelBillingStats.Location = new Point(20, 110);
            panelBillingStats.Size = new Size(contentWidth, 80);

            tabBillingControl.Location = new Point(20, 200);
            tabBillingControl.Size = new Size(contentWidth, this.ClientSize.Height - 270);

            panelBillingButtons.BringToFront();
            panelBillingStats.BringToFront();
            tabBillingControl.BringToFront();

            if (panelBillingStats.Controls.Count > 0)
            {
                int cardWidth = 210;
                int cardSpacing = 20;
                int totalCardsWidth = (cardWidth * 5) + (cardSpacing * 4);
                int startX = (panelBillingStats.Width - totalCardsWidth) / 2;
                int cardY = 35;

                for (int i = 1; i <= 5; i++)
                {
                    Control card = panelBillingStats.Controls[i];
                    card.Location = new Point(startX + (i - 1) * (cardWidth + cardSpacing), cardY);
                }

                Control title = panelBillingStats.Controls[0];
                title.Left = (panelBillingStats.Width - title.Width) / 2;
                title.Top = 8;
            }
        }

        private Panel CreateStatCard(string title, int count, string subtitle, Color accentColor, int x, int y)
        {
            Panel card = new Panel
            {
                BackColor = Color.FromArgb(247, 250, 252),
                Location = new Point(x, y),
                Size = new Size(210, 35),
                BorderStyle = BorderStyle.None
            };

            Panel accent = new Panel
            {
                BackColor = accentColor,
                Location = new Point(0, 0),
                Size = new Size(4, 35),
                Dock = DockStyle.Left
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(10, 3),
                AutoSize = true
            };

            Label lblCount = new Label
            {
                Text = count.ToString(),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(10, 15),
                AutoSize = true
            };

            Label lblSubtitle = new Label
            {
                Text = subtitle,
                Font = new Font("Segoe UI", 7F, FontStyle.Regular),
                ForeColor = Color.FromArgb(160, 174, 192),
                Location = new Point(count >= 100 ? 50 : 40, 18),
                AutoSize = true,
                MaximumSize = new Size(150, 20)
            };

            card.Controls.Add(accent);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblCount);
            card.Controls.Add(lblSubtitle);

            return card;
        }

        private void CalculateMonthlyIncome()
        {
            try
            {
                string currentMonthQuery = @"
            SELECT 
                COALESCE(SUM(CASE WHEN status = 'Paid' THEN amount ELSE 0 END), 0) AS total_paid,
                COALESCE(SUM(CASE WHEN status = 'Pending' THEN amount ELSE 0 END), 0) AS total_pending,
                COALESCE(SUM(CASE WHEN status = 'Partially Paid' THEN amount ELSE 0 END), 0) AS total_partial,
                COUNT(*) AS total_bills
            FROM Billing
            WHERE MONTH(bill_date) = MONTH(CURRENT_DATE())
            AND YEAR(bill_date) = YEAR(CURRENT_DATE())";

                DataTable currentMonth = DatabaseHelper.ExecuteQuery(currentMonthQuery);

                if (currentMonth.Rows.Count > 0)
                {
                    decimal totalPaid = Convert.ToDecimal(currentMonth.Rows[0]["total_paid"]);
                    decimal totalPending = Convert.ToDecimal(currentMonth.Rows[0]["total_pending"]);
                    decimal totalPartial = Convert.ToDecimal(currentMonth.Rows[0]["total_partial"]);
                    int totalBills = Convert.ToInt32(currentMonth.Rows[0]["total_bills"]);

                    UpdateIncomeSummaryPanel(totalPaid, totalPending, totalPartial, totalBills);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error calculating monthly income: {ex.Message}");
            }
        }

        private void UpdateIncomeSummaryPanel(decimal paid, decimal pending, decimal partial, int totalBills)
        {
            Panel existingPanel = tabBilling.Controls.Find("panelIncomeSummary", true).FirstOrDefault() as Panel;
            if (existingPanel != null)
            {
                tabBilling.Controls.Remove(existingPanel);
            }

            Panel summaryPanel = new Panel
            {
                Name = "panelIncomeSummary",
                BackColor = Color.White,
                Location = new Point(20, 100),
                Size = new Size(1165, 120),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = $"📊 Monthly Income Summary - {DateTime.Now:MMMM yyyy}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Panel cardPaid = CreateIncomeCard("💰 Total Paid", paid, Color.FromArgb(46, 204, 113), 20, 50);
            Panel cardPending = CreateIncomeCard("⏳ Pending", pending, Color.FromArgb(241, 196, 15), 310, 50);
            Panel cardPartial = CreateIncomeCard("📊 Partially Paid", partial, Color.FromArgb(52, 152, 219), 600, 50);
            Panel cardTotal = CreateIncomeCard($"📋 Total Bills", totalBills, Color.FromArgb(149, 165, 166), 890, 50, true);

            summaryPanel.Controls.Add(lblTitle);
            summaryPanel.Controls.Add(cardPaid);
            summaryPanel.Controls.Add(cardPending);
            summaryPanel.Controls.Add(cardPartial);
            summaryPanel.Controls.Add(cardTotal);

            tabBilling.Controls.Add(summaryPanel);
            summaryPanel.BringToFront();

            if (dgvBilling.Parent == tabBilling)
            {
                dgvBilling.Location = new Point(20, 230);
                dgvBilling.Height = tabBilling.Height - 250;
            }
        }

        private Panel CreateIncomeCard(string title, decimal amount, Color accentColor, int x, int y, bool isCount = false)
        {
            Panel card = new Panel
            {
                BackColor = Color.FromArgb(247, 250, 252),
                Location = new Point(x, y),
                Size = new Size(270, 60),
                BorderStyle = BorderStyle.None
            };

            Panel accent = new Panel
            {
                BackColor = accentColor,
                Location = new Point(0, 0),
                Size = new Size(5, 60),
                Dock = DockStyle.Left
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(15, 10),
                AutoSize = true
            };

            Label lblAmount = new Label
            {
                Text = isCount ? amount.ToString("N0") : $"₱{amount:N2}",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(15, 28),
                AutoSize = true
            };

            card.Controls.Add(accent);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblAmount);

            return card;
        }

        private void BtnViewBillDetails_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = null;

            if (tabBillingControl.SelectedTab == tabActiveBills)
            {
                activeGrid = dgvBilling;
            }
            else if (tabBillingControl.SelectedTab == tabDischargedBills)
            {
                activeGrid = dgvDischargedBills;
            }

            if (activeGrid == null || activeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to view details.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var billIdCell = activeGrid.SelectedRows[0].Cells["Bill ID"];
            if (billIdCell?.Value == null || billIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid bill data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int billId = Convert.ToInt32(billIdCell.Value);

            BillDetailsViewForm detailsForm = new BillDetailsViewForm(billId);
            detailsForm.ShowDialog();
        }

        private void LoadUsersData()
        {
            try
            {
                string query = @"
                SELECT 
                unique_id AS 'User ID', 
                name AS 'Name', 
                role AS 'Role', 
                email AS 'Email Address', 
                DATE_FORMAT(created_date, '%Y-%m-%d %H:%i') AS 'Date Created',
                is_active
                FROM Users 
                WHERE role != 'Patient' 
                ORDER BY is_active DESC, created_date DESC";

                DataTable allUsers = DatabaseHelper.ExecuteQuery(query);

                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] Loaded {allUsers.Rows.Count} users (including inactive)");

                dgvUsers.DataSource = allUsers;

                this.Text = $"St. Joseph's Hospital - Admin Dashboard ({allUsers.Rows.Count} users)";

                LoadRoleSpecificGrids(allUsers);
                HideStatusColumnAndHighlight(dgvUsers);
                HideStatusColumnAndHighlight(dgvAdmins);
                HideStatusColumnAndHighlight(dgvDoctors);
                HideStatusColumnAndHighlight(dgvStaff);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] LoadUsersData error: {ex.Message}");
            }
        }

        private void HideStatusColumnAndHighlight(DataGridView dgv)
        {
            if (dgv == null || dgv.Rows.Count == 0) return;

            try
            {
                if (dgv.Columns.Contains("is_active"))
                {
                    dgv.Columns["is_active"].Visible = false;
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    bool isActive = true;
                    if (row.DataBoundItem != null)
                    {
                        DataRowView rowView = row.DataBoundItem as DataRowView;
                        if (rowView != null && rowView.Row.Table.Columns.Contains("is_active"))
                        {
                            isActive = Convert.ToBoolean(rowView["is_active"]);
                        }
                    }
                    else if (dgv.Columns.Contains("is_active") && row.Cells["is_active"].Value != null)
                    {
                        isActive = Convert.ToBoolean(row.Cells["is_active"].Value);
                    }

                    if (!isActive)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(197, 48, 48);
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 200, 200);
                        row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(139, 0, 0);
                        row.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Italic);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error highlighting deactivated users: {ex.Message}");
            }
        }

        private void LoadRoleSpecificGrids(DataTable allUsers)
        {
            try
            {
                DataTable admins = allUsers.Clone();
                DataTable doctors = allUsers.Clone();
                DataTable staff = allUsers.Clone();

                foreach (DataRow row in allUsers.Rows)
                {
                    string role = row["Role"].ToString();

                    if (role == "Admin" || role == "Headadmin")
                    {
                        admins.ImportRow(row);
                    }
                    else if (role == "Doctor")
                    {
                        doctors.ImportRow(row);
                    }
                    else if (role == "Receptionist" || role == "Pharmacist")
                    {
                        staff.ImportRow(row);
                    }
                }

                dgvAdmins.DataSource = admins;
                dgvDoctors.DataSource = doctors;
                dgvStaff.DataSource = staff;

                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] Split users - Admins: {admins.Rows.Count}, Doctors: {doctors.Rows.Count}, Staff: {staff.Rows.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading role-specific grids: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[AdminDashboard] LoadRoleSpecificGrids error: {ex.Message}");
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
            }
        }

        private void ShowUniversalSearchSuggestions(string searchText)
        {
            try
            {
                searchSuggestionsListBox.Items.Clear();
                int totalResults = 0;
                int activeTabIndex = tabControl.SelectedIndex;

                if (activeTabIndex == 0) 
                {
                    int activeUserSubTab = tabUsers.SelectedIndex;
                    string roleFilter = "";

                    switch (activeUserSubTab)
                    {
                        case 0:
                            roleFilter = "";
                            break;
                        case 1:
                            roleFilter = "AND (role = 'Admin' OR role = 'Headadmin')";
                            break;
                        case 2:
                            roleFilter = "AND role = 'Doctor'";
                            break;
                        case 3: 
                            roleFilter = "AND (role = 'Receptionist' OR role = 'Pharmacist')";
                            break;
                    }

                    string userQuery = $@"SELECT user_id, name, role, email, profile_image, 'Users' as source 
                    FROM Users 
                    WHERE role != 'Patient'
                    {roleFilter}
                    AND (name LIKE @search OR email LIKE @search OR role LIKE @search) 
                    ORDER BY 
                    CASE 
                    WHEN name LIKE @exactSearch THEN 1
                    WHEN name LIKE @startSearch THEN 2
                    ELSE 3
                    END,
                    name
                    LIMIT 10";

                    DataTable users = DatabaseHelper.ExecuteQuery(userQuery,
                        new MySqlParameter("@search", $"%{searchText}%"),
                        new MySqlParameter("@exactSearch", searchText),
                        new MySqlParameter("@startSearch", $"{searchText}%"));

                    foreach (DataRow row in users.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["user_id"]),
                            DisplayText = $"{row["name"]} - {row["role"]} ({row["email"]})",
                            Source = "Users",
                            Data = row
                        });
                        totalResults++;
                    }
                }
                else if (activeTabIndex == 1) 
                {
                    string patientQuery = @"
                    SELECT p.patient_id, u.name AS patient_name, p.blood_type, 
                    u.age, u.gender, 'Patients' as source,
                    u.profile_image AS patient_image
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE (u.name LIKE @search OR p.blood_type LIKE @search OR p.phone_number LIKE @search)
                    ORDER BY u.name
                    LIMIT 10";

                    DataTable patients = DatabaseHelper.ExecuteQuery(patientQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in patients.Rows)
                    {
                        string displayText = $"{row["patient_name"]} - Age: {row["age"]}, Blood: {row["blood_type"]}";
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["patient_id"]),
                            DisplayText = displayText,
                            Source = "Patients",
                            Data = row
                        });
                        totalResults++;
                    }
                }
                else if (activeTabIndex == 2) 
                {
                    int activeBillingSubTab = tabBillingControl.SelectedIndex;
                    string billingFilter = "";

                    switch (activeBillingSubTab)
                    {
                        case 0:
                            billingFilter = @"LEFT JOIN patientqueue pq ON b.queue_id = pq.queue_id
                                     WHERE (pq.status IS NULL OR pq.status != 'Discharged')
                                     AND";
                            break;
                        case 1:
                            billingFilter = @"INNER JOIN patientqueue pq ON b.queue_id = pq.queue_id AND pq.status = 'Discharged'
                                     WHERE";
                            break;
                    }

                    string billQuery = $@"
                    SELECT b.bill_id, u.name AS patient_name, b.amount, b.status, 
                           b.description, 'Billing' as source, u.profile_image AS patient_image
                    FROM Billing b
                    INNER JOIN Patients p ON b.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    {billingFilter} (u.name LIKE @search OR b.description LIKE @search OR b.status LIKE @search)
                    ORDER BY b.bill_date DESC
                    LIMIT 10";

                    DataTable billing = DatabaseHelper.ExecuteQuery(billQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in billing.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["bill_id"]),
                            DisplayText = $"{row["patient_name"]} - ₱{row["amount"]:N2} - {row["status"]}",
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
                    dynamic refs = searchSuggestionsListBox.Tag;
                    Panel container = refs.Container;
                    Panel shadow = refs.Shadow;

                    Point searchPanelLocation = this.PointToClient(panelUniversalSearch.Parent.PointToScreen(panelUniversalSearch.Location));
                    int searchPanelBottom = searchPanelLocation.Y + panelUniversalSearch.Height;

                    int width = panelUniversalSearch.Width;
                    int itemCount = searchSuggestionsListBox.Items.Count;
                    int maxVisibleItems = 6;

                    int statusHeight = 35;
                    int listHeight = Math.Min(itemCount, maxVisibleItems) * searchSuggestionsListBox.ItemHeight;
                    int totalHeight = statusHeight + listHeight + 2;

                    container.Location = new Point(searchPanelLocation.X, searchPanelBottom);
                    container.Size = new Size(width, totalHeight);
                    container.BackColor = Color.White;
                    container.Padding = new Padding(0);

                    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                    int radius = 12;

                    path.AddLine(0, 0, width, 0);
                    path.AddLine(width, 0, width, totalHeight - radius);
                    path.AddArc(width - radius, totalHeight - radius, radius, radius, 0, 90);
                    path.AddLine(width - radius, totalHeight, radius, totalHeight);
                    path.AddArc(0, totalHeight - radius, radius, radius, 90, 90);
                    path.AddLine(0, totalHeight - radius, 0, 0);
                    path.CloseFigure();

                    container.Region = new Region(path);

                    lblSearchStatus.Parent = container;
                    lblSearchStatus.Location = new Point(20, 8);
                    lblSearchStatus.AutoSize = true;
                    lblSearchStatus.BringToFront();

                    searchSuggestionsListBox.Parent = container;
                    searchSuggestionsListBox.Location = new Point(1, statusHeight);
                    searchSuggestionsListBox.Size = new Size(width - 2, listHeight);
                    searchSuggestionsListBox.BorderStyle = BorderStyle.FixedSingle;
                    searchSuggestionsListBox.Region = null;

                    shadow.Location = new Point(searchPanelLocation.X + 2, searchPanelBottom + 2);
                    shadow.Size = new Size(width, totalHeight);
                    shadow.Region = new Region(path.Clone() as System.Drawing.Drawing2D.GraphicsPath);

                    shadow.Visible = true;
                    container.Visible = true;
                    lblSearchStatus.Visible = true;

                    container.BringToFront();
                    shadow.SendToBack();
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
                    case "Users":
                        SwitchToTab(0);
                        DataRow userRow = selectedItem.Data;
                        string role = userRow["role"].ToString();
                        int userId = Convert.ToInt32(userRow["user_id"]);
                        FocusOnUser(userId, role);
                        break;

                    case "Patients":
                        SwitchToTab(1);
                        FocusOnPatient(selectedItem.Id);
                        break;

                    case "Billing":
                        SwitchToTab(2);
                        FocusOnBill(selectedItem.Id);
                        break;
                }
            }
        }

        private void FocusOnUser(int userId, string role)
        {
            DataGridView targetGrid = dgvUsers;
            if (role == "Admin" || role == "Headadmin")
            {
                tabUsers.SelectedTab = tabAdmins;
                targetGrid = dgvAdmins;
            }
            else if (role == "Doctor")
            {
                tabUsers.SelectedTab = tabDoctors;
                targetGrid = dgvDoctors;
            }
            else if (role == "Receptionist" || role == "Pharmacist")
            {
                tabUsers.SelectedTab = tabStaff;
                targetGrid = dgvStaff;
            }

            string getUniqueIdQuery = "SELECT unique_id FROM Users WHERE user_id = @userId";
            object uniqueIdResult = DatabaseHelper.ExecuteScalar(getUniqueIdQuery,
                new MySqlParameter("@userId", userId));

            if (uniqueIdResult == null || uniqueIdResult == DBNull.Value)
                return;

            string uniqueId = uniqueIdResult.ToString();

            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Cells["User ID"].Value != null &&
                    row.Cells["User ID"].Value.ToString() == uniqueId)
                {
                    row.Selected = true;
                    targetGrid.FirstDisplayedScrollingRowIndex = row.Index;
                    targetGrid.Focus();
                    break;
                }
            }
        }

        private void FocusOnPatient(int patientId)
        {
            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                if (row.Cells["Patient ID"].Value != null &&
                    Convert.ToInt32(row.Cells["Patient ID"].Value) == patientId)
                {
                    row.Selected = true;
                    dgvPatients.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvPatients.Focus();
                    break;
                }
            }
        }

        private void FocusOnBill(int billId)
        {
            foreach (DataGridViewRow row in dgvBilling.Rows)
            {
                if (row.Cells["Bill ID"].Value != null &&
                    Convert.ToInt32(row.Cells["Bill ID"].Value) == billId)
                {
                    row.Selected = true;
                    dgvBilling.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvBilling.Focus();
                    break;
                }
            }
        }

        private void BtnUniversalSearch_Click(object sender, EventArgs e)
        {
            if (searchSuggestionsListBox.Visible && searchSuggestionsListBox.Items.Count > 0)
            {
                searchSuggestionsListBox.SelectedIndex = 0;
                SelectFromUniversalSearch();
            }
        }

        private void BtnClearUniversalSearch_Click(object sender, EventArgs e)
        {
            txtUniversalSearch.Clear();
            HideSearchSuggestions();
        }

        private DataGridView GetActiveUserGrid()
        {
            if (tabUsers.SelectedTab == tabAllUsers)
                return dgvUsers;
            else if (tabUsers.SelectedTab == tabAdmins)
                return dgvAdmins;
            else if (tabUsers.SelectedTab == tabDoctors)
                return dgvDoctors;
            else if (tabUsers.SelectedTab == tabStaff)
                return dgvStaff;
            return dgvUsers;
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            RegisterForm userForm = new RegisterForm(currentUser.UserId, currentUser.Role);
            userForm.FormClosed += (s, args) => LoadData();
            userForm.ShowDialog();
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = GetActiveUserGrid();
            if (activeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userIdCell = activeGrid.SelectedRows[0].Cells["User ID"];
            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string uniqueId = userIdCell.Value.ToString();
            string getUserIdQuery = "SELECT user_id FROM Users WHERE unique_id = @uniqueId";
            object result = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                new MySqlParameter("@uniqueId", uniqueId));

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show("Cannot find user record.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(result);
            RegisterForm editForm = new RegisterForm(userId);
            editForm.FormClosed += (s, args) =>
            {
                LoadData();
                if (userId == currentUser.UserId)
                {
                    RefreshUserData();
                }
            };
            editForm.ShowDialog();
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = GetActiveUserGrid();
            if (activeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userIdCell = activeGrid.SelectedRows[0].Cells["User ID"];
            var nameCell = activeGrid.SelectedRows[0].Cells["Name"];
            var emailCell = activeGrid.SelectedRows[0].Cells["Email Address"];

            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string uniqueId = userIdCell.Value.ToString();
            string userName = nameCell?.Value?.ToString() ?? "Unknown";
            string userEmail = emailCell?.Value?.ToString() ?? "";

            if (userEmail == "Headadmin@hospital.com" ||
                userEmail == "Admin@hospital.com" ||
                userEmail == "Receptionist@hospital.com" ||
                userEmail == "Pharmacist@hospital.com" ||
                userEmail == "Doctor@hospital.com")
            {
                MessageBox.Show("Cannot delete default system accounts.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string getUserIdQuery = "SELECT user_id FROM Users WHERE unique_id = @uniqueId";
            object result = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                new MySqlParameter("@uniqueId", uniqueId));

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show("Cannot find user record.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(result);

            if (userId == currentUser.UserId)
            {
                MessageBox.Show("You cannot delete your own account.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult deleteChoice = MessageBox.Show(
                $"How do you want to remove {userName}?\n\n" +
                "YES = Permanently Delete (cannot be undone)\n" +
                "NO = Deactivate (can be reactivated later)\n" +
                "CANCEL = Cancel operation",
                "Delete or Deactivate?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (deleteChoice == DialogResult.Cancel)
                return;

            try
            {
                if (deleteChoice == DialogResult.Yes)
                {
                    string query = "DELETE FROM Users WHERE user_id = @userId";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@userId", userId));
                    MessageBox.Show("User permanently deleted.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = "UPDATE Users SET is_active = 0 WHERE user_id = @userId";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@userId", userId));
                    MessageBox.Show("User deactivated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Data refreshed successfully!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnViewPatientRecord_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view records.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var patientIdCell = dgvPatients.SelectedRows[0].Cells["Patient ID"];
            if (patientIdCell?.Value == null || patientIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid patient data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int patientId = Convert.ToInt32(patientIdCell.Value);

            string query = @"
            SELECT u.name, 
                   COUNT(DISTINCT mr.record_id) as record_count,
                   COUNT(DISTINCT pq.queue_id) as visit_count
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            LEFT JOIN medicalrecords mr ON p.patient_id = mr.patient_id
            LEFT JOIN patientqueue pq ON p.patient_id = pq.patient_id
            WHERE p.patient_id = @patientId
            GROUP BY u.name";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@patientId", patientId));

            if (dt.Rows.Count > 0)
            {
                string patientName = dt.Rows[0]["name"].ToString();
                int recordCount = Convert.ToInt32(dt.Rows[0]["record_count"]);
                int visitCount = Convert.ToInt32(dt.Rows[0]["visit_count"]);

                ShowDetailedMedicalHistoryForm historyForm = new ShowDetailedMedicalHistoryForm(
                    patientId,
                    patientName,
                    recordCount,
                    visitCount,
                    currentUser.UserId,
                    currentUser.Role
                );
                historyForm.ShowDialog();
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            RegisterForm patientForm = RegisterForm.CreatePatientMode(currentUser.UserId, currentUser.Role);
            patientForm.FormClosed += (s, args) => LoadData();
            patientForm.ShowDialog();
        }

        private void btnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var patientIdCell = dgvPatients.SelectedRows[0].Cells["Patient ID"];
            if (patientIdCell?.Value == null || patientIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid patient data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int patientId = Convert.ToInt32(patientIdCell.Value);
            string getUserIdQuery = "SELECT user_id FROM Patients WHERE patient_id = @patientId";
            object userIdResult = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                new MySqlParameter("@patientId", patientId));

            if (userIdResult == null || userIdResult == DBNull.Value)
            {
                MessageBox.Show("Cannot find user record for this patient.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(userIdResult);

            RegisterForm editForm = new RegisterForm(userId);
            editForm.FormClosed += (s, args) => LoadData();
            editForm.ShowDialog();
        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var patientIdCell = dgvPatients.SelectedRows[0].Cells["Patient ID"];
            var nameCell = dgvPatients.SelectedRows[0].Cells["Patient Name"];

            if (patientIdCell?.Value == null || patientIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid patient data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int patientId = Convert.ToInt32(patientIdCell.Value);
            string patientName = nameCell?.Value?.ToString() ?? "Unknown";

            DialogResult deleteChoice = MessageBox.Show(
                $"How do you want to remove {patientName}?\n\n" +
                "YES = Permanently Delete (cannot be undone)\n" +
                "NO = Deactivate (can be reactivated later)\n" +
                "CANCEL = Cancel operation",
                "Delete or Deactivate Patient?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (deleteChoice == DialogResult.Cancel)
                return;

            try
            {
                if (deleteChoice == DialogResult.Yes)
                {
                    string getUserIdQuery = "SELECT user_id FROM Patients WHERE patient_id = @patientId";
                    object userIdResult = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                        new MySqlParameter("@patientId", patientId));

                    if (userIdResult != null && userIdResult != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdResult);

                        string deleteQuery = "DELETE FROM Users WHERE user_id = @userId";
                        DatabaseHelper.ExecuteNonQuery(deleteQuery, new MySqlParameter("@userId", userId));

                        MessageBox.Show("Patient permanently deleted.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string getUserIdQuery = "SELECT user_id FROM Patients WHERE patient_id = @patientId";
                    object userIdResult = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                        new MySqlParameter("@patientId", patientId));

                    if (userIdResult != null && userIdResult != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdResult);

                        string deactivateQuery = "UPDATE Users SET is_active = 0 WHERE user_id = @userId";
                        DatabaseHelper.ExecuteNonQuery(deactivateQuery, new MySqlParameter("@userId", userId));

                        MessageBox.Show("Patient deactivated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewUserProfile_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = GetActiveUserGrid();
            if (activeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to view their profile.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userIdCell = activeGrid.SelectedRows[0].Cells["User ID"];
            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string uniqueId = userIdCell.Value.ToString();
            string getUserIdQuery = "SELECT user_id FROM Users WHERE unique_id = @uniqueId";
            object result = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                new MySqlParameter("@uniqueId", uniqueId));

            if (result == null || result == DBNull.Value)
            {
                MessageBox.Show("Cannot find user record.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(result);

            using (RegisterForm viewForm = RegisterForm.CreateViewMode(userId))
            {
                viewForm.ShowDialog();
            }
        }

        private void BtnViewPatientProfile_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view their profile.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["Patient ID"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["Patient Name"].Value.ToString();

            string getUserIdQuery = "SELECT user_id FROM Patients WHERE patient_id = @patientId";
            object userIdResult = DatabaseHelper.ExecuteScalar(getUserIdQuery,
                new MySqlParameter("@patientId", patientId));

            if (userIdResult == null || userIdResult == DBNull.Value)
            {
                MessageBox.Show("Cannot find user record for this patient.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(userIdResult);

            using (RegisterForm viewForm = RegisterForm.CreateViewMode(userId))
            {
                viewForm.ShowDialog();
            }
        }

        private void btnToggleAccountStatus_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = GetActiveUserGrid();
            if (activeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to change account status.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userIdCell = activeGrid.SelectedRows[0].Cells["User ID"];
            var nameCell = activeGrid.SelectedRows[0].Cells["Name"];
            var emailCell = activeGrid.SelectedRows[0].Cells["Email Address"];
            var roleCell = activeGrid.SelectedRows[0].Cells["Role"];

            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string uniqueId = userIdCell.Value.ToString();
            string userName = nameCell?.Value?.ToString() ?? "Unknown";
            string userEmail = emailCell?.Value?.ToString() ?? "";
            string userRole = roleCell?.Value?.ToString() ?? "";

            string getUserQuery = @"SELECT user_id, is_active, failed_login_attempts FROM Users WHERE unique_id = @uniqueId";
            DataTable dt = DatabaseHelper.ExecuteQuery(getUserQuery,
                new MySqlParameter("@uniqueId", uniqueId));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Cannot find user record.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);
            bool isActive = Convert.ToBoolean(dt.Rows[0]["is_active"]);
            int failedAttempts = dt.Rows[0]["failed_login_attempts"] != DBNull.Value
                ? Convert.ToInt32(dt.Rows[0]["failed_login_attempts"])
                : 0;

            if (userId == currentUser.UserId)
            {
                if (isActive)
                {
                    MessageBox.Show(
                        "🚫 CANNOT DEACTIVATE YOUR OWN ACCOUNT\n\n" +
                        "You cannot deactivate your own account for security reasons.\n\n" +
                        "If you need to deactivate this account, ask another administrator to do it.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "✅ REACTIVATING YOUR ACCOUNT\n\n" +
                        "You are reactivating your own account.\n" +
                        "This is allowed for recovery purposes.",
                        "Self-Reactivation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            if (userRole == "Headadmin" && isActive)
            {
                MessageBox.Show(
                    "🔒 CANNOT DEACTIVATE HEAD ADMINISTRATOR\n\n" +
                    "The Head Administrator account cannot be deactivated.\n\n" +
                    "This is a critical system account and must remain active for security and administrative purposes.",
                    "Protected Account",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (isActive)
            {
                string message = $"🔒 DEACTIVATE ACCOUNT\n\n" +
                      $"User: {userName}\n" +
                      $"Email: {userEmail}\n" +
                      $"Role: {userRole}\n\n" +
                      "This will:\n" +
                      "• Prevent user from logging in\n" +
                      "• Require administrator to reactivate\n" +
                      "• Preserve all user data\n\n" +
                      "Are you sure you want to deactivate this account?";

                DialogResult confirm = MessageBox.Show(message, "Confirm DEACTIVATE",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    string updateQuery = @"UPDATE Users 
                                  SET is_active = 0
                                  WHERE user_id = @userId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@userId", userId));

                    string successMsg = $"🔒 ACCOUNT DEACTIVATED\n\n" +
                          $"User: {userName}\n\n" +
                          "• Account is now deactivated\n" +
                          "• User cannot login\n" +
                          "• Administrator can reactivate";

                    MessageBox.Show(successMsg, "Account Deactivated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deactivating account: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = $"🔓 ACTIVATE ACCOUNT\n\n" +
                      $"User: {userName}\n" +
                      $"Email: {userEmail}\n" +
                      $"Role: {userRole}\n" +
                      $"Failed Login Attempts: {failedAttempts}\n\n" +
                      "This will:\n" +
                      "• Allow user to login again\n" +
                      "• Reset failed login attempts to 0\n" +
                      "• Clear any account locks\n\n" +
                      "Are you sure you want to activate this account?";

                DialogResult confirm = MessageBox.Show(message, "Confirm ACTIVATE",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    string updateQuery = @"UPDATE Users 
                                  SET is_active = 1,
                                      failed_login_attempts = 0,
                                      last_failed_attempt = NULL,
                                      locked_until = NULL
                                  WHERE user_id = @userId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@userId", userId));

                    string successMsg = $"✅ ACCOUNT ACTIVATED\n\n" +
                          $"User: {userName}\n\n" +
                          "• Account is now active\n" +
                          "• Failed login attempts reset\n" +
                          "• User can now login";

                    MessageBox.Show(successMsg, "Account Activated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error activating account: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenerateIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeReportForm reportForm = new IncomeReportForm();
            reportForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void BtnUsersMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(0);
        }

        private void BtnMedicalRecordsMenu_Click(object sender, EventArgs e)
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

            btnUsersMenu.BackColor = Color.Transparent;
            btnMedicalRecordsMenu.BackColor = Color.Transparent;
            btnBillingMenu.BackColor = Color.Transparent;

            btnUsersMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnMedicalRecordsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnBillingMenu.ForeColor = Color.FromArgb(226, 232, 240);

            Button activeBtn = index == 0 ? btnUsersMenu :
                               index == 1 ? btnMedicalRecordsMenu : btnBillingMenu;
            activeBtn.BackColor = Color.FromArgb(66, 153, 225);
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