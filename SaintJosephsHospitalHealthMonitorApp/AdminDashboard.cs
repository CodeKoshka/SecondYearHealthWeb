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

        public AdminDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            EnsureDataGridViewsExist();
            ApplyStyle();
            UpdateUserDisplay();
            ConfigureAllDataGridViews();
            InitializeSearchSuggestions();
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
            UpdateMenuButton(btnBillingMenu, 400, "💰", "Billing & Payments");

            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);

            btnToggleSidebar.Visible = false;

            panelHeaderRight.BackColor = Color.Transparent;
            panelHeaderRight.Dock = DockStyle.Right;
            panelHeaderRight.Width = 280;
            pictureBoxHeaderProfile.BorderStyle = BorderStyle.None;

            Panel profileHeaderBg = new Panel();
            profileHeaderBg.Size = new Size(49, 49);
            profileHeaderBg.Location = new Point(220, 10);
            profileHeaderBg.BackColor = Color.FromArgb(237, 242, 247);
            panelHeaderRight.Controls.Add(profileHeaderBg);
            profileHeaderBg.SendToBack();

            lblHeaderUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHeaderUser.ForeColor = Color.White;
            lblHeaderUser.AutoSize = true;
            lblHeaderUser.TextAlign = ContentAlignment.TopRight;
            lblHeaderUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHeaderUser.Location = new Point(20, 17);

            lblHeaderRole.Font = new Font("Segoe UI", 9F);
            lblHeaderRole.ForeColor = Color.FromArgb(224, 224, 224);
            lblHeaderRole.AutoSize = true;
            lblHeaderRole.TextAlign = ContentAlignment.TopRight;
            lblHeaderRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHeaderRole.Location = new Point(20, 38);

            pictureBoxHeaderProfile.Location = new Point(220, 12);

            lblHeaderUser.Left = pictureBoxHeaderProfile.Left - lblHeaderUser.Width - 5;
            lblHeaderRole.Left = pictureBoxHeaderProfile.Left - lblHeaderRole.Width - 5;

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
            lblHeaderUser.Text = currentUser.Name;
            lblHeaderRole.Text = currentUser.Role;
            lblHeaderUser.Left = pictureBoxHeaderProfile.Left - lblHeaderUser.Width - 5;
            lblHeaderRole.Left = pictureBoxHeaderProfile.Left - lblHeaderRole.Width - 5;
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

        private void InitializeSearchSuggestions()
        {
            searchSuggestionsListBox = new ListBox();
            searchSuggestionsListBox.Font = new Font("Segoe UI", 10F);
            searchSuggestionsListBox.Visible = false;
            searchSuggestionsListBox.BorderStyle = BorderStyle.FixedSingle;
            searchSuggestionsListBox.BackColor = Color.White;
            searchSuggestionsListBox.ForeColor = Color.Black;
            searchSuggestionsListBox.IntegralHeight = false;
            searchSuggestionsListBox.Click += SearchSuggestionsListBox_Click;
            searchSuggestionsListBox.KeyDown += SearchSuggestionsListBox_KeyDown;
            this.Controls.Add(searchSuggestionsListBox);
            searchSuggestionsListBox.BringToFront();
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
                        pictureBoxHeaderProfile.Image = Image.FromStream(ms);
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
            pictureBoxHeaderProfile.Image = (Image)placeholder.Clone();
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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                searchSuggestionsListBox.Visible = false;
                LoadUsersData();
                return;
            }

            ShowSearchSuggestions(searchText);
        }

        private void TxtSearchAppointments_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchAppointments.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            try
            {
                string query = @"
                    SELECT a.appointment_id, u1.name AS Patient, u2.name AS Doctor, 
                           a.appointment_date, a.status, a.notes
                    FROM Appointments a
                    INNER JOIN Patients p ON a.patient_id = p.patient_id
                    INNER JOIN Users u1 ON p.user_id = u1.user_id
                    INNER JOIN Doctors d ON a.doctor_id = d.doctor_id
                    INNER JOIN Users u2 ON d.user_id = u2.user_id
                    WHERE u1.name LIKE @search OR u2.name LIKE @search OR a.status LIKE @search
                    ORDER BY a.appointment_date DESC";
                dgvAppointments.DataSource = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@search", $"%{searchText}%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching appointments: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearchBilling_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBilling.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            try
            {
                string query = @"
                    SELECT b.bill_id, u.name AS Patient, b.amount, b.status, 
                           b.description, b.bill_date
                    FROM Billing b
                    INNER JOIN Patients p ON b.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE u.name LIKE @search OR b.description LIKE @search OR b.status LIKE @search
                    ORDER BY b.bill_date DESC";
                dgvBilling.DataSource = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@search", $"%{searchText}%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching billing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSearchSuggestions(string searchText)
        {
            try
            {
                string query = "SELECT user_id, name, role, email FROM Users WHERE is_active = 1 AND name LIKE @search ORDER BY name LIMIT 10";
                DataTable results = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@search", $"%{searchText}%"));

                searchSuggestionsListBox.Items.Clear();

                if (results.Rows.Count > 0)
                {
                    foreach (DataRow row in results.Rows)
                    {
                        string displayText = $"{row["name"]} - {row["role"]} ({row["email"]})";
                        searchSuggestionsListBox.Items.Add(new SearchSuggestionItem
                        {
                            UserId = Convert.ToInt32(row["user_id"]),
                            Name = row["name"].ToString(),
                            Role = row["role"].ToString(),
                            Email = row["email"].ToString(),
                            DisplayText = displayText
                        });
                    }
                    Point formPoint = panelSearch.PointToScreen(new Point(txtSearch.Left, txtSearch.Bottom + 2));
                    formPoint = this.PointToClient(formPoint);
                    searchSuggestionsListBox.Location = formPoint;
                    searchSuggestionsListBox.Width = Math.Min(txtSearch.Width + 200, this.ClientSize.Width - formPoint.X - 20);
                    int itemCount = searchSuggestionsListBox.Items.Count;
                    int maxVisibleItems = 6;
                    int itemHeight = searchSuggestionsListBox.ItemHeight;
                    searchSuggestionsListBox.Height = Math.Min(itemCount, maxVisibleItems) * itemHeight + 4;
                    searchSuggestionsListBox.Visible = true;
                    searchSuggestionsListBox.BringToFront();
                }
                else
                {
                    searchSuggestionsListBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing suggestions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchSuggestionsListBox_Click(object sender, EventArgs e)
        {
            if (searchSuggestionsListBox.SelectedItem != null)
            {
                SelectUserFromSuggestion();
            }
        }

        private void SearchSuggestionsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectUserFromSuggestion();
                e.Handled = true;
            }
        }

        private void SelectUserFromSuggestion()
        {
            if (searchSuggestionsListBox.SelectedItem is SearchSuggestionItem selectedItem)
            {
                searchSuggestionsListBox.Visible = false;
                txtSearch.Text = selectedItem.Name;

                FocusOnUser(selectedItem.UserId, selectedItem.Role);
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (searchSuggestionsListBox.Visible && searchSuggestionsListBox.Items.Count > 0)
            {
                searchSuggestionsListBox.SelectedIndex = 0;
                SelectUserFromSuggestion();
            }
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            searchSuggestionsListBox.Visible = false;
            LoadUsersData();
            tabUsers.SelectedTab = tabAllUsers;
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
            BillingForm billForm = new BillingForm();
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

        public class SearchSuggestionItem
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}