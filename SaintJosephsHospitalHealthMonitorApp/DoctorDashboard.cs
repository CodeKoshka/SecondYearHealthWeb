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
using MySqlConnector;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class DoctorDashboard : Form
    {
        private User currentUser;
        private int doctorId;
        private byte[] currentUserProfileImage;
        private ListBox searchSuggestionsListBox;
        private System.Threading.Timer searchDebounceTimer;
        private const int SEARCH_DEBOUNCE_MS = 300;
        private Label lblSearchStatus;
        private Panel panelSearchCategories;
        private CheckBox chkSearchAppointments;
        private CheckBox chkSearchPatients;
        private CheckBox chkSearchRecords;

        public DoctorDashboard(User user)
        {
            currentUser = user;
            GetDoctorId();
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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();

            Color sidebarBg = Color.FromArgb(26, 32, 44);
            Color accentColor = Color.FromArgb(26, 188, 156);

            panelSidebar.BackColor = sidebarBg;

            panelHeader.BackColor = accentColor;
            panelHeader.Height = 70;

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

            UpdateMenuButton(btnAppointmentsMenu, 290, "📅", "My Appointments");
            UpdateMenuButton(btnPatientsMenu, 345, "👥", "My Patients");
            UpdateMenuButton(btnRecordsMenu, 400, "📋", "Medical Records");

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
            lblHospitalName.Text = $"Dr. {currentUser.Name} - Doctor Portal";
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
            if (dgvMedicalRecords != null) ConfigureDataGridView(dgvMedicalRecords);
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

            chkSearchAppointments = new CheckBox();
            chkSearchAppointments.Text = "📅 Appointments";
            chkSearchAppointments.Checked = true;
            chkSearchAppointments.Font = new Font("Segoe UI", 9F);
            chkSearchAppointments.Location = new Point(15, 10);
            chkSearchAppointments.AutoSize = true;
            chkSearchAppointments.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchPatients = new CheckBox();
            chkSearchPatients.Text = "👥 Patients";
            chkSearchPatients.Checked = true;
            chkSearchPatients.Font = new Font("Segoe UI", 9F);
            chkSearchPatients.Location = new Point(160, 10);
            chkSearchPatients.AutoSize = true;
            chkSearchPatients.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchRecords = new CheckBox();
            chkSearchRecords.Text = "📋 Records";
            chkSearchRecords.Checked = true;
            chkSearchRecords.Font = new Font("Segoe UI", 9F);
            chkSearchRecords.Location = new Point(280, 10);
            chkSearchRecords.AutoSize = true;
            chkSearchRecords.CheckedChanged += (s, e) => RefreshSearchResults();

            panelSearchCategories.Controls.AddRange(new Control[] {
                chkSearchAppointments, chkSearchPatients, chkSearchRecords
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

                    string searchTerm = txtUniversalSearch.Text.Trim();
                    string displayText = item.DisplayText;

                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(26, 32, 44)))
                    using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(26, 188, 156)))
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
                case "Appointments": return Color.FromArgb(72, 187, 120);
                case "Patients": return Color.FromArgb(66, 153, 225);
                case "Records": return Color.FromArgb(237, 137, 54);
                default: return Color.FromArgb(113, 128, 150);
            }
        }

        private string GetCategoryIcon(string source)
        {
            switch (source)
            {
                case "Appointments": return "📅";
                case "Patients": return "👤";
                case "Records": return "📋";
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
                string queryAppointments = @"
                    SELECT a.appointment_id, u.name AS Patient, u.age, u.gender,
                           a.appointment_date, a.status, a.notes
                    FROM Appointments a
                    INNER JOIN Patients p ON a.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE a.doctor_id = @doctorId
                    ORDER BY a.appointment_date DESC";
                dgvAppointments.DataSource = DatabaseHelper.ExecuteQuery(queryAppointments,
                    new MySqlParameter("@doctorId", doctorId));

                string queryPatients = @"
                    SELECT DISTINCT u.user_id, u.name, u.age, u.gender, 
                           p.blood_type, p.allergies, u.email
                    FROM Appointments a
                    INNER JOIN Patients p ON a.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE a.doctor_id = @doctorId";
                dgvPatients.DataSource = DatabaseHelper.ExecuteQuery(queryPatients,
                    new MySqlParameter("@doctorId", doctorId));

                string queryRecords = @"
                    SELECT m.record_id, u.name AS Patient, m.diagnosis, 
                           m.prescription, m.lab_tests, m.record_date
                    FROM MedicalRecords m
                    INNER JOIN Patients p ON m.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE m.doctor_id = @doctorId
                    ORDER BY m.record_date DESC";
                dgvMedicalRecords.DataSource = DatabaseHelper.ExecuteQuery(queryRecords,
                    new MySqlParameter("@doctorId", doctorId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
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

                if (chkSearchAppointments.Checked)
                {
                    string apptQuery = @"
                        SELECT a.appointment_id, u.name AS patient_name, 
                               a.appointment_date, a.status, a.notes, 'Appointments' as source
                        FROM Appointments a
                        INNER JOIN Patients p ON a.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE a.doctor_id = @doctorId
                        AND (u.name LIKE @search OR a.status LIKE @search OR a.notes LIKE @search)
                        ORDER BY a.appointment_date DESC
                        LIMIT 5";

                    DataTable appointments = DatabaseHelper.ExecuteQuery(apptQuery,
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in appointments.Rows)
                    {
                        DateTime apptDate = Convert.ToDateTime(row["appointment_date"]);
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["appointment_id"]),
                            DisplayText = $"{row["patient_name"]} - {apptDate:MMM dd, yyyy} - {row["status"]}",
                            Source = "Appointments",
                            Data = row
                        });
                        totalResults++;
                    }
                }

                if (chkSearchPatients.Checked)
                {
                    string patientQuery = @"
                        SELECT DISTINCT u.user_id, u.name, u.email, u.age, u.gender,
                               p.blood_type, 'Patients' as source
                        FROM Appointments a
                        INNER JOIN Patients p ON a.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE a.doctor_id = @doctorId
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
                            Id = Convert.ToInt32(row["user_id"]),
                            DisplayText = $"{row["name"]} - {row["age"]} yrs, {row["gender"]} - {row["blood_type"]}",
                            Source = "Patients",
                            Data = row
                        });
                        totalResults++;
                    }
                }

                if (chkSearchRecords.Checked)
                {
                    string recordQuery = @"
                        SELECT m.record_id, u.name AS patient_name, m.diagnosis, 
                               m.prescription, m.record_date, 'Records' as source
                        FROM MedicalRecords m
                        INNER JOIN Patients p ON m.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE m.doctor_id = @doctorId
                        AND (u.name LIKE @search OR m.diagnosis LIKE @search OR m.prescription LIKE @search)
                        ORDER BY m.record_date DESC
                        LIMIT 5";

                    DataTable records = DatabaseHelper.ExecuteQuery(recordQuery,
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in records.Rows)
                    {
                        DateTime recordDate = Convert.ToDateTime(row["record_date"]);
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["record_id"]),
                            DisplayText = $"{row["patient_name"]} - {row["diagnosis"]} - {recordDate:MMM dd, yyyy}",
                            Source = "Records",
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
                    case "Appointments":
                        SwitchToTab(0);
                        FocusOnAppointment(selectedItem.Id);
                        break;

                    case "Patients":
                        SwitchToTab(1);
                        FocusOnPatient(selectedItem.Id);
                        break;

                    case "Records":
                        SwitchToTab(2);
                        FocusOnRecord(selectedItem.Id);
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

        private void FocusOnPatient(int userId)
        {
            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                if (row.Cells["user_id"].Value != null &&
                    Convert.ToInt32(row.Cells["user_id"].Value) == userId)
                {
                    row.Selected = true;
                    dgvPatients.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvPatients.Focus();
                    break;
                }
            }
        }

        private void FocusOnRecord(int recordId)
        {
            foreach (DataGridViewRow row in dgvMedicalRecords.Rows)
            {
                if (row.Cells["record_id"].Value != null &&
                    Convert.ToInt32(row.Cells["record_id"].Value) == recordId)
                {
                    row.Selected = true;
                    dgvMedicalRecords.FirstDisplayedScrollingRowIndex = row.Index;
                    dgvMedicalRecords.Focus();
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
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string patientName = dgvAppointments.SelectedRows[0].Cells["Patient"].Value.ToString();
            string age = dgvAppointments.SelectedRows[0].Cells["age"].Value.ToString();
            string gender = dgvAppointments.SelectedRows[0].Cells["gender"].Value.ToString();
            string apptDate = dgvAppointments.SelectedRows[0].Cells["appointment_date"].Value.ToString();
            string notes = dgvAppointments.SelectedRows[0].Cells["notes"].Value?.ToString() ?? "None";

            string message = $"Patient: {patientName}\nAge: {age}\nGender: {gender}\n" +
                           $"Appointment: {apptDate}\nNotes: {notes}";

            MessageBox.Show(message, "Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCompleteAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int apptId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);

            try
            {
                string query = "UPDATE Appointments SET status = 'Completed' WHERE appointment_id = @id";
                DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", apptId));
                MessageBox.Show("Appointment marked as completed!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["user_id"].Value);

            string getPatientId = "SELECT patient_id FROM Patients WHERE user_id = @userId";
            int patientId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(getPatientId,
                new MySqlParameter("@userId", userId)));

            string query = @"
                SELECT m.record_date, u.name AS Doctor, m.diagnosis, 
                       m.prescription, m.lab_tests
                FROM MedicalRecords m
                INNER JOIN Doctors d ON m.doctor_id = d.doctor_id
                INNER JOIN Users u ON d.user_id = u.user_id
                WHERE m.patient_id = @patientId
                ORDER BY m.record_date DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@patientId", patientId));

            Form historyForm = new Form();
            historyForm.Text = "Patient Medical History";
            historyForm.Size = new Size(900, 500);
            historyForm.StartPosition = FormStartPosition.CenterParent;

            DataGridView dgvHistory = new DataGridView();
            dgvHistory.Location = new Point(10, 10);
            dgvHistory.Size = new Size(860, 430);
            dgvHistory.ReadOnly = true;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.DataSource = dt;
            historyForm.Controls.Add(dgvHistory);
            historyForm.ShowDialog();
        }

        private void BtnAddMedicalRecord_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["user_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

            string getPatientId = "SELECT patient_id FROM Patients WHERE user_id = @userId";
            int patientId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(getPatientId,
                new MySqlParameter("@userId", userId)));

            MedicalRecordForm recordForm = new MedicalRecordForm(patientId, doctorId, patientName);
            recordForm.FormClosed += (s, args) => LoadData();
            recordForm.ShowDialog();
        }

        private void BtnEditRecord_Click(object sender, EventArgs e)
        {
            if (dgvMedicalRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int recordId = Convert.ToInt32(dgvMedicalRecords.SelectedRows[0].Cells["record_id"].Value);
            string diagnosis = dgvMedicalRecords.SelectedRows[0].Cells["diagnosis"].Value?.ToString() ?? "";
            string prescription = dgvMedicalRecords.SelectedRows[0].Cells["prescription"].Value?.ToString() ?? "";
            string labTests = dgvMedicalRecords.SelectedRows[0].Cells["lab_tests"].Value?.ToString() ?? "";

            EditMedicalRecordForm editForm = new EditMedicalRecordForm(recordId, diagnosis, prescription, labTests);
            editForm.FormClosed += (s, args) => LoadData();
            editForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnAppointmentsMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(0);
        }

        private void BtnPatientsMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(1);
        }

        private void BtnRecordsMenu_Click(object sender, EventArgs e)
        {
            SwitchToTab(2);
        }

        private void SwitchToTab(int index)
        {
            tabControl.SelectedIndex = index;

            btnAppointmentsMenu.BackColor = Color.Transparent;
            btnPatientsMenu.BackColor = Color.Transparent;
            btnRecordsMenu.BackColor = Color.Transparent;

            btnAppointmentsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnPatientsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnRecordsMenu.ForeColor = Color.FromArgb(226, 232, 240);

            Button activeBtn = index == 0 ? btnAppointmentsMenu :
                               index == 1 ? btnPatientsMenu : btnRecordsMenu;
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