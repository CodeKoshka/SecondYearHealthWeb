
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySqlConnector;
using Timer = System.Windows.Forms.Timer;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class LoginForm : Form
    {
        private Timer animationTimer;
        private float currentOpacity = 0f;
        private bool isShaking = false;
        private int shakeOffset = 0;
        private int shakeCount = 0;
        private Point originalLocation;

        public LoginForm()
        {
            InitializeComponent();
            InitializeAnimations();
            SetupModernStyle();
        }

        private void InitializeAnimations()
        {
            this.Opacity = 0;
            originalLocation = this.Location;

            animationTimer = new Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isShaking)
            {
                PerformShakeAnimation();
            }
            else if (currentOpacity < 1.0f)
            {
                currentOpacity += 0.05f;
                this.Opacity = Math.Min(currentOpacity, 1.0f);

                if (currentOpacity >= 1.0f)
                {
                    animationTimer.Stop();
                }
            }
        }

        private void PerformShakeAnimation()
        {
            shakeCount++;
            int[] shakePattern = { -10, 10, -8, 8, -5, 5, -3, 3, 0 };

            if (shakeCount < shakePattern.Length)
            {
                shakeOffset = shakePattern[shakeCount];
                this.Location = new Point(originalLocation.X + shakeOffset, originalLocation.Y);
            }
            else
            {
                isShaking = false;
                shakeCount = 0;
                this.Location = originalLocation;
                animationTimer.Stop();
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowError("Please enter both email and password.");
                TriggerShakeAnimation();
                return;
            }

            User user = User.Authenticate(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {
                if (user.Role != "Headadmin" &&
                    user.Role != "Admin" &&
                    user.Role != "Receptionist" &&
                    user.Role != "Doctor" &&
                    user.Role != "Pharmacist")
                {
                    ShowError("Invalid role for login. Patients cannot login here.");
                    TriggerShakeAnimation();
                    return;
                }

                AnimateSuccessfulLogin(user);
            }
            else
            {
                ShowError("Invalid email or password.");
                TriggerShakeAnimation();
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

        private void TriggerShakeAnimation()
        {
            originalLocation = this.Location;
            isShaking = true;
            shakeCount = 0;
            animationTimer.Start();
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