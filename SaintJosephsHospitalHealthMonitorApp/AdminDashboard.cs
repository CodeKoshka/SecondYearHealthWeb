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
        private Panel panelSearchCategories;
        private CheckBox chkSearchUsers;
        private CheckBox chkSearchAppointments;
        private CheckBox chkSearchBilling;

        public AdminDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            EnsureDataGridViewsExist();
            ApplyStyle();
            UpdateUserDisplay();
            ConfigureAllDataGridViews();
            InitializeUniversalSearch();
            LoadData();
            LoadUserProfile();
        }

        private void EnsureDataGridViewsExist()
        {
            if (dgvUsers == null)
            {
                dgvUsers = CreateStyledDataGridView();
                dgvUsers.Name = "dgvUsers";
                tabAllUsers.Controls.Add(dgvUsers);
            }

            if (dgvAdmins == null)
            {
                dgvAdmins = CreateStyledDataGridView();
                dgvAdmins.Name = "dgvAdmins";
                tabAdmins.Controls.Add(dgvAdmins);
            }

            if (dgvDoctors == null)
            {
                dgvDoctors = CreateStyledDataGridView();
                dgvDoctors.Name = "dgvDoctors";
                tabDoctors.Controls.Add(dgvDoctors);
            }

            if (dgvPatients == null)
            {
                dgvPatients = CreateStyledDataGridView();
                dgvPatients.Name = "dgvPatients";
                tabPatients.Controls.Add(dgvPatients);
            }

            if (dgvStaff == null)
            {
                dgvStaff = CreateStyledDataGridView();
                dgvStaff.Name = "dgvStaff";
                tabStaff.Controls.Add(dgvStaff);
            }

            if (dgvAppointments == null)
            {
                dgvAppointments = CreateStyledDataGridView();
                dgvAppointments.Name = "dgvAppointments";
                tabAppointments.Controls.Add(dgvAppointments);
                dgvAppointments.BringToFront();
            }

            if (dgvBilling == null)
            {
                dgvBilling = CreateStyledDataGridView();
                dgvBilling.Name = "dgvBilling";
                tabBilling.Controls.Add(dgvBilling);
                dgvBilling.BringToFront();
            }
        }

        private void ApplyStyle()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();
            Color sidebarBg = Color.FromArgb(26, 32, 44);
            Color sidebarHover = Color.FromArgb(45, 55, 72);
            Color accentColor = Color.FromArgb(66, 153, 225);

            panelSidebar.BackColor = sidebarBg;

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
            UpdateMenuButton(btnAppointmentsMenu, 345, "📅", "Appointments");
            UpdateMenuButton(btnBillingMenu, 400, "💰", "Billing And Payments");

            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);

            panelHeaderRight.Visible = false;

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
            if (dgvUsers != null) ConfigureDataGridView(dgvUsers);
            if (dgvAdmins != null) ConfigureDataGridView(dgvAdmins);
            if (dgvDoctors != null) ConfigureDataGridView(dgvDoctors);
            if (dgvPatients != null) ConfigureDataGridView(dgvPatients);
            if (dgvStaff != null) ConfigureDataGridView(dgvStaff);
            if (dgvAppointments != null) ConfigureDataGridView(dgvAppointments);
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

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }

        private void InitializeUniversalSearch()
        {
            panelSearchCategories = new Panel();
            panelSearchCategories.BackColor = Color.White;
            panelSearchCategories.Height = 40;
            panelSearchCategories.Visible = false;
            panelSearchCategories.Name = "panelSearchCategories";

            chkSearchUsers = new CheckBox();
            chkSearchUsers.Text = "👥 Users";
            chkSearchUsers.Checked = true;
            chkSearchUsers.Font = new Font("Segoe UI", 9F);
            chkSearchUsers.Location = new Point(15, 10);
            chkSearchUsers.AutoSize = true;
            chkSearchUsers.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchAppointments = new CheckBox();
            chkSearchAppointments.Text = "📅 Appointments";
            chkSearchAppointments.Checked = true;
            chkSearchAppointments.Font = new Font("Segoe UI", 9F);
            chkSearchAppointments.Location = new Point(120, 10);
            chkSearchAppointments.AutoSize = true;
            chkSearchAppointments.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchBilling = new CheckBox();
            chkSearchBilling.Text = "💰 Billing";
            chkSearchBilling.Checked = true;
            chkSearchBilling.Font = new Font("Segoe UI", 9F);
            chkSearchBilling.Location = new Point(280, 10);
            chkSearchBilling.AutoSize = true;
            chkSearchBilling.CheckedChanged += (s, e) => RefreshSearchResults();

            panelSearchCategories.Controls.AddRange(new Control[] {
        chkSearchUsers, chkSearchAppointments, chkSearchBilling
    });
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
                        else if ((item.Source == "Appointments" || item.Source == "Billing") &&
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
            this.Controls.Add(panelSearchCategories);
            this.Controls.Add(suggestionsShadow);
            this.Controls.Add(suggestionsContainer);
            suggestionsContainer.Controls.Add(searchSuggestionsListBox);

            suggestionsShadow.SendToBack();
            suggestionsContainer.BringToFront();
            panelSearchCategories.BringToFront();

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
                case "Appointments": return Color.FromArgb(72, 187, 120);
                case "Billing": return Color.FromArgb(237, 137, 54);
                default: return Color.FromArgb(113, 128, 150);
            }
        }

        private string GetCategoryIcon(string source)
        {
            switch (source)
            {
                case "Users": return "👤";
                case "Appointments": return "📅";
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

                string queryAppointments = @"
                    SELECT a.appointment_id, u1.name AS Patient, u2.name AS Doctor, 
                           a.appointment_date, a.status, a.notes
                    FROM Appointments a
                    INNER JOIN Patients p ON a.patient_id = p.patient_id
                    INNER JOIN Users u1 ON p.user_id = u1.user_id
                    INNER JOIN Doctors d ON a.doctor_id = d.doctor_id
                    INNER JOIN Users u2 ON d.user_id = u2.user_id
                    ORDER BY a.appointment_date DESC";
                dgvAppointments.DataSource = DatabaseHelper.ExecuteQuery(queryAppointments);

                string queryBilling = @"
                    SELECT b.bill_id, u.name AS Patient, b.amount, b.status, 
                           b.description, b.bill_date
                    FROM Billing b
                    INNER JOIN Patients p ON b.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    ORDER BY b.bill_date DESC";
                dgvBilling.DataSource = DatabaseHelper.ExecuteQuery(queryBilling);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsersData()
        {
            try
            {
                string query = "SELECT user_id, name, role, email, created_date FROM Users WHERE is_active = 1 ORDER BY created_date DESC";
                DataTable allUsers = DatabaseHelper.ExecuteQuery(query);

                dgvUsers.DataSource = allUsers;
                this.Text = $"St. Joseph's Hospital - Admin Dashboard ({allUsers.Rows.Count} users)";

                LoadRoleSpecificGrids(allUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoleSpecificGrids(DataTable allUsers)
        {
            try
            {
                DataTable admins = allUsers.Clone();
                DataTable doctors = allUsers.Clone();
                DataTable patients = allUsers.Clone();
                DataTable staff = allUsers.Clone();

                foreach (DataRow row in allUsers.Rows)
                {
                    string role = row["role"].ToString();
                    if (role == "Admin" || role == "Headadmin")
                        admins.ImportRow(row);
                    else if (role == "Doctor")
                        doctors.ImportRow(row);
                    else if (role == "Patient")
                        patients.ImportRow(row);
                    else if (role == "Receptionist" || role == "Pharmacist")
                        staff.ImportRow(row);
                }

                dgvAdmins.DataSource = admins;
                dgvDoctors.DataSource = doctors;
                dgvPatients.DataSource = patients;
                dgvStaff.DataSource = staff;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading role-specific grids: {ex.Message}", "Error",
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

                if (chkSearchUsers.Checked)
                {
                    string userQuery = @"SELECT user_id, name, role, email, profile_image, 'Users' as source 
                FROM Users 
                WHERE is_active = 1 
                AND (name LIKE @search OR email LIKE @search OR role LIKE @search) 
                ORDER BY 
                    CASE 
                        WHEN name LIKE @exactSearch THEN 1
                        WHEN name LIKE @startSearch THEN 2
                        ELSE 3
                    END,
                    name
                LIMIT 5";

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

                if (chkSearchAppointments.Checked)
                {
                    string apptQuery = @"
                SELECT a.appointment_id, u1.name AS patient_name, u2.name AS doctor_name, 
                       a.appointment_date, a.status, 'Appointments' as source,
                       u1.profile_image AS patient_image
                FROM Appointments a
                INNER JOIN Patients p ON a.patient_id = p.patient_id
                INNER JOIN Users u1 ON p.user_id = u1.user_id
                INNER JOIN Doctors d ON a.doctor_id = d.doctor_id
                INNER JOIN Users u2 ON d.user_id = u2.user_id
                WHERE u1.name LIKE @search OR u2.name LIKE @search OR a.status LIKE @search
                ORDER BY a.appointment_date DESC
                LIMIT 5";

                    DataTable appointments = DatabaseHelper.ExecuteQuery(apptQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in appointments.Rows)
                    {
                        DateTime apptDate = Convert.ToDateTime(row["appointment_date"]);
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["appointment_id"]),
                            DisplayText = $"{row["patient_name"]} with Dr. {row["doctor_name"]} - {apptDate:MMM dd, yyyy} - {row["status"]}",
                            Source = "Appointments",
                            Data = row
                        });
                        totalResults++;
                    }
                }

                if (chkSearchBilling.Checked)
                {
                    string billQuery = @"
                SELECT b.bill_id, u.name AS patient_name, b.amount, b.status, 
                       b.description, 'Billing' as source, u.profile_image AS patient_image
                FROM Billing b
                INNER JOIN Patients p ON b.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.name LIKE @search OR b.description LIKE @search OR b.status LIKE @search
                ORDER BY b.bill_date DESC
                LIMIT 5";

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
                    int filterHeight = 40;
                    int listHeight = Math.Min(itemCount, maxVisibleItems) * searchSuggestionsListBox.ItemHeight;
                    int totalHeight = statusHeight + filterHeight + listHeight + 2;

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

                    panelSearchCategories.Parent = container;
                    panelSearchCategories.Location = new Point(0, statusHeight);
                    panelSearchCategories.Size = new Size(width, filterHeight);
                    panelSearchCategories.BackColor = Color.FromArgb(249, 250, 251);
                    panelSearchCategories.Visible = true;
                    panelSearchCategories.BorderStyle = BorderStyle.None;

                    Panel filterTopBorder = panelSearchCategories.Controls.Find("filterTopBorder", false).FirstOrDefault() as Panel;
                    if (filterTopBorder == null)
                    {
                        filterTopBorder = new Panel();
                        filterTopBorder.Name = "filterTopBorder";
                        filterTopBorder.Dock = DockStyle.Top;
                        filterTopBorder.Height = 1;
                        filterTopBorder.BackColor = Color.FromArgb(226, 232, 240);
                        panelSearchCategories.Controls.Add(filterTopBorder);
                        filterTopBorder.BringToFront();
                    }

                    searchSuggestionsListBox.Parent = container;

                    searchSuggestionsListBox.Location = new Point(1, statusHeight + filterHeight);
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

                    case "Appointments":
                        SwitchToTab(1);
                        FocusOnAppointment(selectedItem.Id);
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
            else if (role == "Patient")
            {
                tabUsers.SelectedTab = tabPatients;
                targetGrid = dgvPatients;
            }
            else if (role == "Receptionist" || role == "Pharmacist")
            {
                tabUsers.SelectedTab = tabStaff;
                targetGrid = dgvStaff;
            }

            foreach (DataGridViewRow row in targetGrid.Rows)
            {
                if (row.Cells["user_id"].Value != null &&
                    Convert.ToInt32(row.Cells["user_id"].Value) == userId)
                {
                    row.Selected = true;
                    targetGrid.FirstDisplayedScrollingRowIndex = row.Index;
                    targetGrid.Focus();
                    break;
                }
            }
        }

        private void FocusOnAppointment(int appointmentId)
        {
            foreach (DataGridViewRow row in dgvAppointments.Rows)
            {
                if (row.Cells["appointment_id"].Value != null &&
                    Convert.ToInt32(row.Cells["appointment_id"].Value) == appointmentId)
                {
                    row.Selected = true;
                    dgvAppointments.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvAppointments.Focus();
                    break;
                }
            }
        }

        private void FocusOnBill(int billId)
        {
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
            else if (tabUsers.SelectedTab == tabPatients)
                return dgvPatients;
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

            var userIdCell = activeGrid.SelectedRows[0].Cells["user_id"];
            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(userIdCell.Value);
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

            var userIdCell = activeGrid.SelectedRows[0].Cells["user_id"];
            var nameCell = activeGrid.SelectedRows[0].Cells["name"];
            var emailCell = activeGrid.SelectedRows[0].Cells["email"];

            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(userIdCell.Value);
            string userName = nameCell?.Value?.ToString() ?? "Unknown";
            string userEmail = emailCell?.Value?.ToString() ?? "";

            if (userEmail == "Headadmin@hospital.com" ||
                userEmail == "receptionist@hospital.com" ||
                userEmail == "pharmacist@hospital.com")
            {
                MessageBox.Show("Cannot delete default system accounts.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm apptForm = new AppointmentForm();
            apptForm.FormClosed += (s, args) => LoadData();
            apptForm.ShowDialog();
        }

        private void BtnEditAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var apptIdCell = dgvAppointments.SelectedRows[0].Cells["appointment_id"];
            if (apptIdCell?.Value == null || apptIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid appointment data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int apptId = Convert.ToInt32(apptIdCell.Value);

            AppointmentForm apptForm = new AppointmentForm(apptId);
            apptForm.FormClosed += (s, args) => LoadData();
            apptForm.ShowDialog();
        }

        private void BtnDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Cancel this appointment?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var apptIdCell = dgvAppointments.SelectedRows[0].Cells["appointment_id"];
                    if (apptIdCell?.Value == null || apptIdCell.Value == DBNull.Value)
                    {
                        MessageBox.Show("Invalid appointment data selected.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int apptId = Convert.ToInt32(apptIdCell.Value);
                    string query = "DELETE FROM Appointments WHERE appointment_id = @id";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", apptId));
                    MessageBox.Show("Appointment cancelled.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void BtnAddBill_Click(object sender, EventArgs e)
        {
            int? selectedPatientId = null;
            BillingForm billForm = new BillingForm(currentUser.UserId, selectedPatientId);
            billForm.FormClosed += (s, args) => LoadData();
            billForm.ShowDialog();
        }

        private void BtnUpdateBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var billIdCell = dgvBilling.SelectedRows[0].Cells["bill_id"];
            if (billIdCell?.Value == null || billIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid bill data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int billId = Convert.ToInt32(billIdCell.Value);

            string query = "SELECT * FROM Billing WHERE bill_id = @id";
            DataTable billData = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@id", billId));

            if (billData.Rows.Count == 0)
            {
                MessageBox.Show("Bill not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BillingForm billForm = new BillingForm(billId);
            billForm.FormClosed += (s, args) => LoadData();
            billForm.ShowDialog();
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

        private void BtnAppointmentsMenu_Click(object sender, EventArgs e)
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
            btnAppointmentsMenu.BackColor = Color.Transparent;
            btnBillingMenu.BackColor = Color.Transparent;

            btnUsersMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnAppointmentsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnBillingMenu.ForeColor = Color.FromArgb(226, 232, 240);

            Button activeBtn = index == 0 ? btnUsersMenu :
                               index == 1 ? btnAppointmentsMenu : btnBillingMenu;
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