using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySqlConnector;
using Timer = System.Windows.Forms.Timer;
using System.Data;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class LoginForm : Form
    {
        private Timer animationTimer;
        private float currentOpacity = 0f;

        private static bool enableAdmin = true;
        private static bool enableReceptionist = true;
        private static bool enableDoctor = true;
        private static bool enablePharmacist = false;
        private static bool createDefaultHeadadmin = true;
        private static bool createDefaultAdmin = true;
        private static bool createDefaultReceptionist = true;
        private static bool createDefaultPharmacist = false;
        private static bool createDefaultDoctor = false;
        private static bool createDefaultPatient = false;

        public LoginForm()
        {
            InitializeComponent();
            LoadDebugSettings();
            InitializeAnimations();
            SetupModernStyle();
        }

        private void LoadDebugSettings()
        {
            bool loadedFromDatabase = false;

            try
            {
                string query = "SELECT setting_key, setting_value FROM DebugSettings";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("[LoginForm] Loading settings from DATABASE");

                    foreach (DataRow row in dt.Rows)
                    {
                        string key = row["setting_key"].ToString();
                        bool value = row["setting_value"].ToString() == "1";

                        switch (key)
                        {
                            case "EnableAdmin":
                                enableAdmin = value;
                                break;
                            case "EnableReceptionist":
                                enableReceptionist = value;
                                break;
                            case "EnableDoctor":
                                enableDoctor = value;
                                break;
                            case "EnablePharmacist":
                                enablePharmacist = value;
                                break;
                            case "CreateDefaultHeadadmin":
                                createDefaultHeadadmin = value;
                                break;
                            case "CreateDefaultAdmin":
                                createDefaultAdmin = value;
                                break;
                            case "CreateDefaultReceptionist":
                                createDefaultReceptionist = value;
                                break;
                            case "CreateDefaultPharmacist":
                                createDefaultPharmacist = value;
                                break;
                            case "CreateDefaultDoctor":
                                createDefaultDoctor = value;
                                break;
                            case "CreateDefaultPatient":
                                createDefaultPatient = value;
                                break;
                        }
                    }
                    loadedFromDatabase = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[LoginForm] Failed to load from database: {ex.Message}");
            }

            if (!loadedFromDatabase)
            {
                if (DebugConfig.JsonConfigExists())
                {
                    System.Diagnostics.Debug.WriteLine("[LoginForm] Loading settings from JSON FILE (database unavailable/empty)");
                    LoadFromJsonConfig();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("[LoginForm] Using HARDCODED DEFAULTS (no database, no JSON)");
                }
            }
        }

        private void LoadFromJsonConfig()
        {
            try
            {
                DebugConfig config = DebugConfig.LoadFromJson();

                enableAdmin = config.EnableAdmin;
                enableReceptionist = config.EnableReceptionist;
                enableDoctor = config.EnableDoctor;
                enablePharmacist = config.EnablePharmacist;
                createDefaultHeadadmin = config.CreateDefaultHeadadmin;
                createDefaultAdmin = config.CreateDefaultAdmin;
                createDefaultReceptionist = config.CreateDefaultReceptionist;
                createDefaultPharmacist = config.CreateDefaultPharmacist;
                createDefaultDoctor = config.CreateDefaultDoctor;
                createDefaultPatient = config.CreateDefaultPatient;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[LoginForm] Failed to load JSON config: {ex.Message}");
            }
        }

        private void SaveDebugSettings()
        {
            try
            {
                string deleteQuery = "DELETE FROM DebugSettings";
                DatabaseHelper.ExecuteNonQuery(deleteQuery);

                string insertQuery = @"INSERT INTO DebugSettings (setting_key, setting_value) VALUES 
                ('EnableAdmin', @admin),
                ('EnableReceptionist', @receptionist),
                ('EnableDoctor', @doctor),
                ('EnablePharmacist', @pharmacist),
                ('CreateDefaultHeadadmin', @createHeadadmin),
                ('CreateDefaultAdmin', @createAdmin),
                ('CreateDefaultReceptionist', @createReceptionist),
                ('CreateDefaultPharmacist', @createPharmacist),
                ('CreateDefaultDoctor', @createDoctor),
                ('CreateDefaultPatient', @createPatient)";

                DatabaseHelper.ExecuteNonQuery(insertQuery,
                    new MySqlParameter("@admin", enableAdmin ? "1" : "0"),
                    new MySqlParameter("@receptionist", enableReceptionist ? "1" : "0"),
                    new MySqlParameter("@doctor", enableDoctor ? "1" : "0"),
                    new MySqlParameter("@pharmacist", enablePharmacist ? "1" : "0"),
                    new MySqlParameter("@createHeadadmin", createDefaultHeadadmin ? "1" : "0"),
                    new MySqlParameter("@createAdmin", createDefaultAdmin ? "1" : "0"),
                    new MySqlParameter("@createReceptionist", createDefaultReceptionist ? "1" : "0"),
                    new MySqlParameter("@createPharmacist", createDefaultPharmacist ? "1" : "0"),
                    new MySqlParameter("@createDoctor", createDefaultDoctor ? "1" : "0"),
                    new MySqlParameter("@createPatient", createDefaultPatient ? "1" : "0")
                );

                System.Diagnostics.Debug.WriteLine("[LoginForm] Settings saved to DATABASE");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save to database: {ex.Message}\n\nSettings will be saved to JSON only.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                DebugConfig config = new DebugConfig
                {
                    EnableAdmin = enableAdmin,
                    EnableReceptionist = enableReceptionist,
                    EnableDoctor = enableDoctor,
                    EnablePharmacist = enablePharmacist,
                    CreateDefaultHeadadmin = createDefaultHeadadmin,
                    CreateDefaultAdmin = createDefaultAdmin,
                    CreateDefaultReceptionist = createDefaultReceptionist,
                    CreateDefaultPharmacist = createDefaultPharmacist,
                    CreateDefaultDoctor = createDefaultDoctor,
                    CreateDefaultPatient = createDefaultPatient
                };

                config.SaveToJson();
                System.Diagnostics.Debug.WriteLine("[LoginForm] Settings saved to JSON FILE");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save JSON backup: {ex.Message}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeAnimations()
        {
            this.Opacity = 0;

            animationTimer = new Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentOpacity < 1.0f)
            {
                currentOpacity += 0.05f;
                this.Opacity = Math.Min(currentOpacity, 1.0f);

                if (currentOpacity >= 1.0f)
                {
                    animationTimer.Stop();
                }
            }
        }

        private void SetupModernStyle()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();

            SetRoundedCorners(panelEmailContainer, 8);
            SetRoundedCorners(panelPasswordContainer, 8);
            SetRoundedCorners(btnLogin, 8);

            txtEmail.Enter += (s, e) => AnimateInputFocus(panelEmailBorder, true);
            txtEmail.Leave += (s, e) => AnimateInputFocus(panelEmailBorder, false);
            txtPassword.Enter += (s, e) => AnimateInputFocus(panelPasswordBorder, true);
            txtPassword.Leave += (s, e) => AnimateInputFocus(panelPasswordBorder, false);

            btnLogin.MouseEnter += (s, e) => AnimateButton(btnLogin, true);
            btnLogin.MouseLeave += (s, e) => AnimateButton(btnLogin, false);

            txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        private void SetRoundedCorners(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AnimateInputFocus(Panel borderPanel, bool isFocused)
        {
            Timer t = new Timer { Interval = 10 };
            int steps = 0;
            Color startColor = borderPanel.BackColor;
            Color targetColor = isFocused ? Color.FromArgb(66, 153, 225) : Color.FromArgb(226, 232, 240);

            t.Tick += (s, e) =>
            {
                steps++;
                float progress = steps / 15f;

                if (progress >= 1f)
                {
                    borderPanel.BackColor = targetColor;
                    t.Stop();
                    t.Dispose();
                }
                else
                {
                    int r = (int)(startColor.R + (targetColor.R - startColor.R) * progress);
                    int g = (int)(startColor.G + (targetColor.G - startColor.G) * progress);
                    int b = (int)(startColor.B + (targetColor.B - startColor.B) * progress);
                    borderPanel.BackColor = Color.FromArgb(r, g, b);
                }
            };
            t.Start();
        }

        private void AnimateButton(Button button, bool isHover)
        {
            Timer t = new Timer { Interval = 10 };
            int steps = 0;
            Color startColor = button.BackColor;
            Color targetColor = isHover ? Color.FromArgb(56, 131, 186) : Color.FromArgb(66, 153, 225);

            t.Tick += (s, e) =>
            {
                steps++;
                float progress = steps / 10f;

                if (progress >= 1f)
                {
                    button.BackColor = targetColor;
                    t.Stop();
                    t.Dispose();
                }
                else
                {
                    int r = (int)(startColor.R + (targetColor.R - startColor.R) * progress);
                    int g = (int)(startColor.G + (targetColor.G - startColor.G) * progress);
                    int b = (int)(startColor.B + (targetColor.B - startColor.B) * progress);
                    button.BackColor = Color.FromArgb(r, g, b);
                }
            };
            t.Start();
        }

        private void ShowDebugMenu()
        {
            Form passwordForm = new Form
            {
                Text = "Debug Access - Head Admin Authentication",
                Size = new Size(450, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(247, 250, 252)
            };

            Label lblPasswordPrompt = new Label
            {
                Text = "🔒 Enter Head Admin Password:",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(26, 32, 44),
                Location = new Point(30, 30),
                Size = new Size(380, 30)
            };

            TextBox txtAdminPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11F),
                Location = new Point(30, 70),
                Size = new Size(380, 30),
                PasswordChar = '●',
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnVerify = new Button
            {
                Text = "✓ Verify",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(66, 153, 225),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(30, 115),
                Size = new Size(180, 40),
                Cursor = Cursors.Hand
            };
            btnVerify.FlatAppearance.BorderSize = 0;

            Button btnCancelPassword = new Button
            {
                Text = "✕ Cancel",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(230, 115),
                Size = new Size(180, 40),
                Cursor = Cursors.Hand
            };
            btnCancelPassword.FlatAppearance.BorderSize = 0;

            btnVerify.Click += (s, e) =>
            {
                string query = "SELECT password FROM Users WHERE email = 'Headadmin@hospital.com'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    string correctPassword = dt.Rows[0]["password"].ToString();

                    if (txtAdminPassword.Text == correctPassword)
                    {
                        passwordForm.DialogResult = DialogResult.OK;
                        passwordForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("❌ Incorrect password. Access denied.", "Authentication Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAdminPassword.Clear();
                        txtAdminPassword.Focus();
                    }
                }
            };

            btnCancelPassword.Click += (s, e) =>
            {
                passwordForm.DialogResult = DialogResult.Cancel;
                passwordForm.Close();
            };

            txtAdminPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnVerify.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            passwordForm.Controls.AddRange(new Control[] { lblPasswordPrompt, txtAdminPassword, btnVerify, btnCancelPassword });

            if (passwordForm.ShowDialog(this) != DialogResult.OK)
                return;

            Form debugForm = new Form
            {
                Text = "Debug Dashboard Settings",
                Size = new Size(500, 550),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(247, 250, 252)
            };

            TabControl tabControl = new TabControl
            {
                Location = new Point(10, 10),
                Size = new Size(470, 450),
                Font = new Font("Segoe UI", 9F)
            };

            TabPage tabDashboard = new TabPage("Dashboard Access");
            tabDashboard.BackColor = Color.FromArgb(247, 250, 252);

            Label lblDashboardTitle = new Label
            {
                Text = "Enable/Disable Dashboard Access",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(26, 32, 44),
                Location = new Point(15, 15),
                Size = new Size(430, 25)
            };

            CheckBox chkAdmin = new CheckBox
            {
                Text = "Admin Dashboard",
                Checked = enableAdmin,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 55),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            CheckBox chkReceptionist = new CheckBox
            {
                Text = "Receptionist Dashboard",
                Checked = enableReceptionist,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 95),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            CheckBox chkDoctor = new CheckBox
            {
                Text = "Doctor Dashboard",
                Checked = enableDoctor,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 135),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            CheckBox chkPharmacist = new CheckBox
            {
                Text = "Pharmacist Dashboard",
                Checked = enablePharmacist,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 175),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            Label lblDashboardNote = new Label
            {
                Text = "Head Admin access is always enabled",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(20, 215),
                Size = new Size(420, 20)
            };

            tabDashboard.Controls.AddRange(new Control[] {
                lblDashboardTitle, chkAdmin, chkReceptionist, chkDoctor, chkPharmacist, lblDashboardNote
            });

            TabPage tabDefaultUsers = new TabPage("Default Users");
            tabDefaultUsers.BackColor = Color.FromArgb(247, 250, 252);

            Label lblDefaultUsersTitle = new Label
            {
                Text = "Auto-Create Default Users on Startup",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(26, 32, 44),
                Location = new Point(15, 15),
                Size = new Size(430, 25)
            };

            Label lblDefaultUsersInfo = new Label
            {
                Text = "These users will be automatically created when the database is initialized",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(15, 45),
                Size = new Size(430, 20)
            };

            Label lblHeadadminTitle = new Label
            {
                Text = "🔒 Head Admin (Always Created - System Required)",
                Enabled = false,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(20, 80),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(220, 53, 69)
            };

            Label lblHeadadminDetails = new Label
            {
                Text = "Email: Headadmin@hospital.com | Password: admin123",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(40, 108),
                Size = new Size(400, 15)
            };

            CheckBox chkCreateAdmin = new CheckBox
            {
                Text = "Create Default Admin",
                Checked = createDefaultAdmin,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 135),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            Label lblAdminDetails = new Label
            {
                Text = "Email: Admin@hospital.com | Password: admin123",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(40, 163),
                Size = new Size(400, 15)
            };

            CheckBox chkCreateReceptionist = new CheckBox
            {
                Text = "Create Default Receptionist",
                Checked = createDefaultReceptionist,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 190),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            Label lblReceptionistDetails = new Label
            {
                Text = "Email: Receptionist@hospital.com | Password: receptionist123",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(40, 218),
                Size = new Size(400, 15)
            };

            CheckBox chkCreatePharmacist = new CheckBox
            {
                Text = "Create Default Pharmacist",
                Checked = createDefaultPharmacist,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 245),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            Label lblPharmacistDetails = new Label
            {
                Text = "Email: Pharmacist@hospital.com | Password: pharmacist123",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(40, 273),
                Size = new Size(400, 15)
            };

            CheckBox chkCreateDoctor = new CheckBox
            {
                Text = "Create Default Doctor",
                Checked = createDefaultDoctor,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 300),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            Label lblDoctorDetails = new Label
            {
                Text = "Email: Doctor@hospital.com | Password: doctor123",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(40, 328),
                Size = new Size(400, 15)
            };

            CheckBox chkCreatePatient = new CheckBox
            {
                Text = "Create Default Patient",
                Checked = createDefaultPatient,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 355),
                Size = new Size(420, 30),
                ForeColor = Color.FromArgb(26, 32, 44)
            };

            Label lblPatientDetails = new Label
            {
                Text = "Email: Patient@hospital.com | Sample test patient",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(113, 128, 150),
                Location = new Point(40, 383),
                Size = new Size(400, 15)
            };

            Label lblDefaultUsersWarning = new Label
            {
                Text = "⚠️ Changes take effect after database re-initialization",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 53, 69),
                Location = new Point(20, 408),
                Size = new Size(420, 20)
            };

            tabDefaultUsers.Controls.AddRange(new Control[] {
                lblDefaultUsersTitle, lblDefaultUsersInfo,
                lblHeadadminTitle, lblHeadadminDetails,
                chkCreateAdmin, lblAdminDetails,
                chkCreateReceptionist, lblReceptionistDetails,
                chkCreatePharmacist, lblPharmacistDetails,
                chkCreateDoctor, lblDoctorDetails,
                chkCreatePatient, lblPatientDetails,
                lblDefaultUsersWarning
            });

            tabControl.TabPages.Add(tabDashboard);
            tabControl.TabPages.Add(tabDefaultUsers);

            Button btnSave = new Button
            {
                Text = "💾 Save All Settings",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(66, 153, 225),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(320, 475),
                Size = new Size(160, 40),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;

            Button btnReset = new Button
            {
                Text = "↺ Reset to Default",
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(203, 213, 224),
                ForeColor = Color.FromArgb(26, 32, 44),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(155, 475),
                Size = new Size(150, 40),
                Cursor = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderSize = 0;

            Button btnClose = new Button
            {
                Text = "✕ Close",
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 475),
                Size = new Size(130, 40),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;

            btnSave.Click += (s, e) =>
            {
                enableAdmin = chkAdmin.Checked;
                enableReceptionist = chkReceptionist.Checked;
                enableDoctor = chkDoctor.Checked;
                enablePharmacist = chkPharmacist.Checked;

                createDefaultHeadadmin = true;
                createDefaultAdmin = chkCreateAdmin.Checked;
                createDefaultReceptionist = chkCreateReceptionist.Checked;
                createDefaultPharmacist = chkCreatePharmacist.Checked;
                createDefaultDoctor = chkCreateDoctor.Checked;
                createDefaultPatient = chkCreatePatient.Checked;

                SaveDebugSettings();

                MessageBox.Show("✓ Debug settings saved successfully!\n\n" +
                               "Settings saved to:\n" +
                               "• Database (DebugSettings table)\n" +
                               "• JSON file (Config/debug_settings.json)\n\n" +
                               "Dashboard access changes take effect immediately.\n" +
                               "Default user creation settings will apply on next database initialization.\n\n" +
                               "Note: Head Admin is always created (system requirement).",
                    "Debug Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                debugForm.Close();
            };

            btnReset.Click += (s, e) =>
            {
                var result = MessageBox.Show("Reset all settings to default values?\n\n" +
                                            "Dashboard Access: All enabled except Pharmacist\n" +
                                            "Default Users: Head Admin (always), Admin, and Receptionist",
                    "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    chkAdmin.Checked = true;
                    chkReceptionist.Checked = true;
                    chkDoctor.Checked = true;
                    chkPharmacist.Checked = false;
                    chkCreateAdmin.Checked = true;
                    chkCreateReceptionist.Checked = true;
                    chkCreatePharmacist.Checked = false;
                    chkCreateDoctor.Checked = false;
                    chkCreatePatient.Checked = false;
                }
            };

            btnClose.Click += (s, e) => debugForm.Close();

            debugForm.Controls.AddRange(new Control[] { tabControl, btnSave, btnReset, btnClose });

            debugForm.ShowDialog(this);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "--debug" && txtPassword.Text.Trim() == "--debug")
            {
                ShowDebugMenu();
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowError("Please enter both email and password.");
                return;
            }

            User user = User.Authenticate(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {
                bool roleEnabled = true;
                switch (user.Role)
                {
                    case "Headadmin":
                        roleEnabled = true;
                        break;
                    case "Admin":
                        roleEnabled = enableAdmin;
                        break;
                    case "Receptionist":
                        roleEnabled = enableReceptionist;
                        break;
                    case "Doctor":
                        roleEnabled = enableDoctor;
                        break;
                    case "Pharmacist":
                        roleEnabled = enablePharmacist;
                        break;
                    default:
                        roleEnabled = false;
                        break;
                }

                if (!roleEnabled)
                {
                    ShowError($"{user.Role} dashboard is currently disabled in debug mode.");
                    return;
                }

                if (user.Role != "Headadmin" &&
                    user.Role != "Admin" &&
                    user.Role != "Receptionist" &&
                    user.Role != "Doctor" &&
                    user.Role != "Pharmacist")
                {
                    ShowError("Invalid role for login. Patients cannot login here.");
                    return;
                }

                AnimateSuccessfulLogin(user);
            }
            else
            {
                ShowError("Invalid email or password.");
                ClearPasswordField();
            }
        }

        private void AnimateSuccessfulLogin(User user)
        {
            btnLogin.Enabled = false;
            txtEmail.Enabled = false;
            txtPassword.Enabled = false;

            Timer fadeTimer = new Timer { Interval = 20 };
            fadeTimer.Tick += (s, e) =>
            {
                this.Opacity -= 0.05;
                if (this.Opacity <= 0)
                {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                    OpenDashboard(user);
                }
            };
            fadeTimer.Start();
        }

        private void OpenDashboard(User user)
        {
            Form dashboard = null;
            switch (user.Role)
            {
                case "Headadmin":
                    dashboard = new AdminDashboard(user);
                    break;
                case "Admin":
                    dashboard = new AdminDashboard(user);
                    break;
                case "Receptionist":
                    dashboard = new ReceptionistDashboard(user);
                    break;
                case "Doctor":
                    dashboard = new DoctorDashboard(user);
                    break;
                case "Pharmacist":
                    dashboard = new PharmacyStaffDashboard(user);
                    break;
            }

            if (dashboard != null)
            {
                this.Hide();
                dashboard.FormClosed += (s, args) => this.Close();
                dashboard.Opacity = 0;
                dashboard.Show();

                Timer fadeIn = new Timer { Interval = 20 };
                fadeIn.Tick += (s, e) =>
                {
                    dashboard.Opacity += 0.05;
                    if (dashboard.Opacity >= 1)
                    {
                        fadeIn.Stop();
                        fadeIn.Dispose();
                    }
                };
                fadeIn.Start();
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;

            Timer hideTimer = new Timer { Interval = 3000 };
            hideTimer.Tick += (s, e) =>
            {
                lblError.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }

        private void ClearPasswordField()
        {
            txtPassword.Clear();
            txtPassword.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (animationTimer != null)
            {
                animationTimer.Stop();
                animationTimer.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}