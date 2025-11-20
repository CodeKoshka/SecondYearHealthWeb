using System;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using System.Data;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class DebugForm : Form
    {
        private bool enableAdmin = true;
        private bool enableReceptionist = true;
        private bool enableDoctor = true;
        private bool enablePharmacist = false;
        private bool createDefaultHeadadmin = true;
        private bool createDefaultAdmin = true;
        private bool createDefaultReceptionist = true;
        private bool createDefaultPharmacist = false;
        private bool createDefaultDoctor = false;
        private bool createDefaultPatient = false;

        public bool EnableAdmin => enableAdmin;
        public bool EnableReceptionist => enableReceptionist;
        public bool EnableDoctor => enableDoctor;
        public bool EnablePharmacist => enablePharmacist;

        public DebugForm()
        {
            InitializeComponent();
            LoadDebugSettings();
        }

        private void LoadDebugSettings()
        {
            if (DebugConfig.JsonConfigExists())
            {
                System.Diagnostics.Debug.WriteLine("[DebugForm] Loading settings from JSON FILE");
                LoadFromJsonConfig();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DebugForm] JSON not found - Using HARDCODED DEFAULTS");
            }

            UpdateUIFromSettings();
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
                System.Diagnostics.Debug.WriteLine($"[DebugForm] Failed to load JSON config: {ex.Message}");
                MessageBox.Show($"Failed to load settings from JSON. Using defaults.\n\nError: {ex.Message}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateUIFromSettings()
        {
            chkAdmin.Checked = enableAdmin;
            chkReceptionist.Checked = enableReceptionist;
            chkDoctor.Checked = enableDoctor;
            chkPharmacist.Checked = enablePharmacist;
            chkCreateAdmin.Checked = createDefaultAdmin;
            chkCreateReceptionist.Checked = createDefaultReceptionist;
            chkCreatePharmacist.Checked = createDefaultPharmacist;
            chkCreateDoctor.Checked = createDefaultDoctor;
            chkCreatePatient.Checked = createDefaultPatient;
        }

        private void SaveDebugSettings()
        {
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
                System.Diagnostics.Debug.WriteLine("[DebugForm] Settings saved to JSON FILE");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings to JSON file.\n\nError: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                           $"Settings saved to:\n• JSON file ({DebugConfig.GetConfigFilePath()})\n\n" +
                           "Dashboard access changes take effect immediately.\n" +
                           "Default user creation settings will apply on next database initialization.\n\n" +
                           "Note: Head Admin is always created (system requirement).",
                "Debug Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static DialogResult ShowDebugDialog(IWin32Window owner)
        {
            using (Form passwordForm = new Form())
            {
                passwordForm.Text = "Debug Access - Head Admin Authentication";
                passwordForm.Size = new Size(450, 200);
                passwordForm.StartPosition = FormStartPosition.CenterParent;
                passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                passwordForm.MaximizeBox = false;
                passwordForm.MinimizeBox = false;
                passwordForm.BackColor = Color.FromArgb(247, 250, 252);

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

                if (passwordForm.ShowDialog(owner) != DialogResult.OK)
                    return DialogResult.Cancel;
            }

            using (DebugForm debugForm = new DebugForm())
            {
                return debugForm.ShowDialog(owner);
            }
        }
    }
}