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

        private bool allowCreateAdmin = true;
        private bool allowCreateReceptionist = true;
        private bool allowCreateDoctor = true;
        private bool allowCreatePharmacist = false;
        private bool allowCreatePatient = true;

        public bool EnableAdmin => enableAdmin;
        public bool EnableReceptionist => enableReceptionist;
        public bool EnableDoctor => enableDoctor;
        public bool EnablePharmacist => enablePharmacist;

        public bool AllowCreateAdmin => allowCreateAdmin;
        public bool AllowCreateReceptionist => allowCreateReceptionist;
        public bool AllowCreateDoctor => allowCreateDoctor;
        public bool AllowCreatePharmacist => allowCreatePharmacist;
        public bool AllowCreatePatient => allowCreatePatient;

        public DebugForm()
        {
            InitializeComponent();
            LoadDebugSettings();
        }

        private void ChkCreateRole_CheckedChanged(object sender, EventArgs e)
        {
            createDefaultAdmin = chkCreateAdmin.Enabled && chkCreateAdmin.Checked;
            createDefaultReceptionist = chkCreateReceptionist.Enabled && chkCreateReceptionist.Checked;
            createDefaultDoctor = chkCreateDoctor.Enabled && chkCreateDoctor.Checked;
            createDefaultPharmacist = chkCreatePharmacist.Enabled && chkCreatePharmacist.Checked;
            createDefaultPatient = chkCreatePatient.Checked;
        }

        private void ChkAllowRole_CheckedChanged(object sender, EventArgs e)
        {
            allowCreateAdmin = chkAllowAdmin.Enabled && chkAllowAdmin.Checked;
            allowCreateReceptionist = chkAllowReceptionist.Enabled && chkAllowReceptionist.Checked;
            allowCreateDoctor = chkAllowDoctor.Enabled && chkAllowDoctor.Checked;
            allowCreatePharmacist = chkAllowPharmacist.Enabled && chkAllowPharmacist.Checked;
            allowCreatePatient = chkAllowPatient.Checked;
        }

        private void LoadDebugSettings()
        {
            chkAdmin.CheckedChanged -= ChkDashboardRole_CheckedChanged;
            chkReceptionist.CheckedChanged -= ChkDashboardRole_CheckedChanged;
            chkDoctor.CheckedChanged -= ChkDashboardRole_CheckedChanged;
            chkPharmacist.CheckedChanged -= ChkDashboardRole_CheckedChanged;

            chkCreateAdmin.CheckedChanged -= ChkCreateRole_CheckedChanged;
            chkCreateReceptionist.CheckedChanged -= ChkCreateRole_CheckedChanged;
            chkCreateDoctor.CheckedChanged -= ChkCreateRole_CheckedChanged;
            chkCreatePharmacist.CheckedChanged -= ChkCreateRole_CheckedChanged;
            chkCreatePatient.CheckedChanged -= ChkCreateRole_CheckedChanged;

            chkAllowAdmin.CheckedChanged -= ChkAllowRole_CheckedChanged;
            chkAllowReceptionist.CheckedChanged -= ChkAllowRole_CheckedChanged;
            chkAllowDoctor.CheckedChanged -= ChkAllowRole_CheckedChanged;
            chkAllowPharmacist.CheckedChanged -= ChkAllowRole_CheckedChanged;
            chkAllowPatient.CheckedChanged -= ChkAllowRole_CheckedChanged;

            try
            {
                if (DebugConfig.JsonConfigExists())
                {
                    LoadFromJsonConfig();
                }

                enableAdmin = true;

                UpdateUIFromSettings();
            }
            finally
            {
                chkAdmin.CheckedChanged += ChkDashboardRole_CheckedChanged;
                chkReceptionist.CheckedChanged += ChkDashboardRole_CheckedChanged;
                chkDoctor.CheckedChanged += ChkDashboardRole_CheckedChanged;
                chkPharmacist.CheckedChanged += ChkDashboardRole_CheckedChanged;

                chkCreateAdmin.CheckedChanged += ChkCreateRole_CheckedChanged;
                chkCreateReceptionist.CheckedChanged += ChkCreateRole_CheckedChanged;
                chkCreateDoctor.CheckedChanged += ChkCreateRole_CheckedChanged;
                chkCreatePharmacist.CheckedChanged += ChkCreateRole_CheckedChanged;
                chkCreatePatient.CheckedChanged += ChkCreateRole_CheckedChanged;

                chkAllowAdmin.CheckedChanged += ChkAllowRole_CheckedChanged;
                chkAllowReceptionist.CheckedChanged += ChkAllowRole_CheckedChanged;
                chkAllowDoctor.CheckedChanged += ChkAllowRole_CheckedChanged;
                chkAllowPharmacist.CheckedChanged += ChkAllowRole_CheckedChanged;
                chkAllowPatient.CheckedChanged += ChkAllowRole_CheckedChanged;
            }
        }

        private void LoadFromJsonConfig()
        {
            try
            {
                DebugConfig config = DebugConfig.LoadFromJson();

                enableAdmin = true;
                enableReceptionist = config.EnableReceptionist;
                enableDoctor = config.EnableDoctor;
                enablePharmacist = config.EnablePharmacist;

                createDefaultHeadadmin = config.CreateDefaultHeadadmin;
                createDefaultAdmin = config.CreateDefaultAdmin;
                createDefaultReceptionist = config.CreateDefaultReceptionist;
                createDefaultPharmacist = config.CreateDefaultPharmacist;
                createDefaultDoctor = config.CreateDefaultDoctor;
                createDefaultPatient = config.CreateDefaultPatient;

                allowCreateAdmin = config.AllowCreateAdmin;
                allowCreateReceptionist = config.AllowCreateReceptionist;
                allowCreateDoctor = config.AllowCreateDoctor;
                allowCreatePharmacist = config.AllowCreatePharmacist;
                allowCreatePatient = config.AllowCreatePatient;
            }
            catch (Exception ex)
            {
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

            chkAllowAdmin.Checked = allowCreateAdmin;
            chkAllowReceptionist.Checked = allowCreateReceptionist;
            chkAllowDoctor.Checked = allowCreateDoctor;
            chkAllowPharmacist.Checked = allowCreatePharmacist;
            chkAllowPatient.Checked = allowCreatePatient;

            SyncRoleCreationWithDashboard();
        }

        private void SyncRoleCreationWithDashboard()
        {
            chkAllowAdmin.Checked = true;
            chkAllowAdmin.Enabled = false;  
            allowCreateAdmin = true;        

            chkCreateAdmin.Enabled = true;
            createDefaultAdmin = chkCreateAdmin.Checked;

            if (!enableReceptionist)
            {
                chkAllowReceptionist.Checked = false;
                chkAllowReceptionist.Enabled = false;
                allowCreateReceptionist = false;

                chkCreateReceptionist.Checked = false;
                chkCreateReceptionist.Enabled = false;
                createDefaultReceptionist = false;
            }
            else
            {
                chkAllowReceptionist.Enabled = true;
                chkCreateReceptionist.Enabled = true;
                allowCreateReceptionist = chkAllowReceptionist.Checked;
                createDefaultReceptionist = chkCreateReceptionist.Checked;
            }

            if (!enableDoctor)
            {
                chkAllowDoctor.Checked = false;
                chkAllowDoctor.Enabled = false;
                allowCreateDoctor = false;

                chkCreateDoctor.Checked = false;
                chkCreateDoctor.Enabled = false;
                createDefaultDoctor = false;
            }
            else
            {
                chkAllowDoctor.Enabled = true;
                chkCreateDoctor.Enabled = true;
                allowCreateDoctor = chkAllowDoctor.Checked;
                createDefaultDoctor = chkCreateDoctor.Checked;
            }

            if (!enablePharmacist)
            {
                chkAllowPharmacist.Checked = false;
                chkAllowPharmacist.Enabled = false;
                allowCreatePharmacist = false;

                chkCreatePharmacist.Checked = false;
                chkCreatePharmacist.Enabled = false;
                createDefaultPharmacist = false;
            }
            else
            {
                chkAllowPharmacist.Enabled = true;
                chkCreatePharmacist.Enabled = true;
                allowCreatePharmacist = chkAllowPharmacist.Checked;
                createDefaultPharmacist = chkCreatePharmacist.Checked;
            }

            chkCreatePatient.Enabled = true;
            chkAllowPatient.Enabled = true;
            createDefaultPatient = chkCreatePatient.Checked;
            allowCreatePatient = chkAllowPatient.Checked;
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
                    CreateDefaultPatient = createDefaultPatient,

                    AllowCreateAdmin = allowCreateAdmin,
                    AllowCreateReceptionist = allowCreateReceptionist,
                    AllowCreateDoctor = allowCreateDoctor,
                    AllowCreatePharmacist = allowCreatePharmacist,
                    AllowCreatePatient = allowCreatePatient
                };

                config.SaveToJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings to JSON file.\n\nError: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void ChkDashboardRole_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == chkAdmin && !chkAdmin.Checked)
            {
                chkAdmin.Checked = true;
                MessageBox.Show("Admin Dashboard cannot be disabled.\n\n" +
                               "The Admin role is required for core system functionality.",
                               "Admin Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            enableAdmin = chkAdmin.Checked;
            enableReceptionist = chkReceptionist.Checked;
            enableDoctor = chkDoctor.Checked;
            enablePharmacist = chkPharmacist.Checked;

            SyncRoleCreationWithDashboard();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!chkAdmin.Checked)
            {
                MessageBox.Show("Admin Dashboard cannot be disabled.\n\n" +
                               "The Admin role is required for system operation.",
                               "Admin Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            enableAdmin = true;
            enableReceptionist = chkReceptionist.Checked;
            enableDoctor = chkDoctor.Checked;
            enablePharmacist = chkPharmacist.Checked;

            SyncRoleCreationWithDashboard();

            createDefaultHeadadmin = true;
            createDefaultAdmin = chkCreateAdmin.Enabled && chkCreateAdmin.Checked;
            createDefaultReceptionist = chkCreateReceptionist.Enabled && chkCreateReceptionist.Checked;
            createDefaultPharmacist = chkCreatePharmacist.Enabled && chkCreatePharmacist.Checked;
            createDefaultDoctor = chkCreateDoctor.Enabled && chkCreateDoctor.Checked;
            createDefaultPatient = chkCreatePatient.Checked;

            allowCreateAdmin = chkAllowAdmin.Enabled && chkAllowAdmin.Checked;
            allowCreateReceptionist = chkAllowReceptionist.Enabled && chkAllowReceptionist.Checked;
            allowCreateDoctor = chkAllowDoctor.Enabled && chkAllowDoctor.Checked;
            allowCreatePharmacist = chkAllowPharmacist.Enabled && chkAllowPharmacist.Checked;
            allowCreatePatient = chkAllowPatient.Checked;

            SaveDebugSettings();

            MessageBox.Show("✓ Debug settings saved successfully!\n\n" +
                           $"Settings saved to:\n• JSON file ({DebugConfig.GetConfigFilePath()})\n\n" +
                           "Dashboard Access:\n" +
                           $"  • Admin: {(enableAdmin ? "✓ Enabled" : "✗ Disabled")}\n" +
                           $"  • Receptionist: {(enableReceptionist ? "✓ Enabled" : "✗ Disabled")}\n" +
                           $"  • Doctor: {(enableDoctor ? "✓ Enabled" : "✗ Disabled")}\n" +
                           $"  • Pharmacist: {(enablePharmacist ? "✓ Enabled" : "✗ Disabled")}\n\n" +
                           "• Dashboard access changes take effect immediately.\n" +
                           "• Default user creation settings will apply on next database initialization.\n" +
                           "• Role creation permissions will apply when creating new users.\n\n" +
                           "Note: Head Admin is always created (system requirement).",
                "Debug Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Reset all settings to default values?\n\n" +
                                        "Dashboard Access: All enabled except Pharmacist\n" +
                                        "Default Users: Head Admin (always), Admin, and Receptionist\n" +
                                        "Role Creation: All enabled except Pharmacist",
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

                chkAllowAdmin.Checked = true;
                chkAllowReceptionist.Checked = true;
                chkAllowDoctor.Checked = true;
                chkAllowPharmacist.Checked = false;
                chkAllowPatient.Checked = true;

                enableAdmin = true;
                enableReceptionist = true;
                enableDoctor = true;
                enablePharmacist = false;

                createDefaultHeadadmin = true;
                createDefaultAdmin = true;
                createDefaultReceptionist = true;
                createDefaultPharmacist = false;
                createDefaultDoctor = false;
                createDefaultPatient = false;

                allowCreateAdmin = true;
                allowCreateReceptionist = true;
                allowCreateDoctor = true;
                allowCreatePharmacist = false;
                allowCreatePatient = true;

                SyncRoleCreationWithDashboard();
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