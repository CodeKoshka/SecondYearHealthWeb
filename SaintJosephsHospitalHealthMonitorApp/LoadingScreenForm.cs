using MySqlConnector;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class LoadingScreenForm : Form
    {
        private Timer fadeInTimer;
        private Timer progressTimer;
        private Timer fadeOutTimer;
        private float currentOpacity = 0f;
        private int progressValue = 0;
        private int rotationAngle = 0;
        private Timer spinnerTimer;
        private string[] loadingMessages = new string[]
        {
            "Initializing system...",
            "Connecting to database...",
            "Verifying credentials...",
            "Loading modules...",
            "Finalizing setup..."
        };
        private int currentMessageIndex = 0;
        private bool initializationComplete = false;
        private bool hasError = false;
        private string errorMessage = "";

        public LoadingScreenForm()
        {
            InitializeComponent();
            InitializeLoadingAnimation();
        }

        private void InitializeLoadingAnimation()
        {
            this.Opacity = 0;

            // Fade in animation
            fadeInTimer = new Timer();
            fadeInTimer.Interval = 20;
            fadeInTimer.Tick += FadeInTimer_Tick;
            fadeInTimer.Start();

            // Progress animation
            progressTimer = new Timer();
            progressTimer.Interval = 50;
            progressTimer.Tick += ProgressTimer_Tick;
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (currentOpacity < 1.0f)
            {
                currentOpacity += 0.05f;
                this.Opacity = Math.Min(currentOpacity, 1.0f);

                if (currentOpacity >= 1.0f)
                {
                    fadeInTimer.Stop();
                    fadeInTimer.Dispose();
                    StartLoadingProcess();
                }
            }
        }

        private async void StartLoadingProcess()
        {
            progressTimer.Start();

            spinnerTimer = new Timer { Interval = 30 };
            spinnerTimer.Tick += (s, e) =>
            {
                rotationAngle = (rotationAngle + 10) % 360;
                panelSpinner.Invalidate();
            };
            spinnerTimer.Start();

            await Task.Run(() =>
            {
                try
                {
                    DatabaseHelper.InitializeDatabase();
                    initializationComplete = true;
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errorMessage = ex.Message;
                    initializationComplete = true;
                }
            });
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (!initializationComplete)
            {

                if (progressValue < 90)
                {
                    progressValue += 2;
                }
                else
                {
                    progressValue += 1;
                }
            }
            else
            {
                progressValue += 5;
            }

            if (progressValue <= 100)
            {
                progressBar.Value = Math.Min(progressValue, 100);
                lblProgress.Text = $"{Math.Min(progressValue, 100)}%";

                int newMessageIndex = Math.Min((progressValue / 20), loadingMessages.Length - 1);
                if (newMessageIndex != currentMessageIndex)
                {
                    currentMessageIndex = newMessageIndex;
                    lblStatus.Text = loadingMessages[currentMessageIndex];
                }
            }
            else
            {
                progressTimer.Stop();
                progressTimer.Dispose();

                if (spinnerTimer != null)
                {
                    spinnerTimer.Stop();
                    spinnerTimer.Dispose();
                }

                CompleteLoading();
            }
        }

        private void CompleteLoading()
        {
            if (hasError)
            {
                lblStatus.Text = "Initialization Failed";
                lblStatus.ForeColor = Color.FromArgb(229, 62, 62);
                lblProgress.Text = "Error";
                lblProgress.ForeColor = Color.FromArgb(229, 62, 62);

                MessageBox.Show("Database initialization error: " + errorMessage,
                    "Initialization Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }
            else
            {
                lblStatus.Text = "Ready!";
                lblProgress.Text = "100%";

                Timer waitTimer = new Timer { Interval = 500 };
                waitTimer.Tick += (s, e) =>
                {
                    waitTimer.Stop();
                    waitTimer.Dispose();
                    FadeOutAndOpenLogin();
                };
                waitTimer.Start();
            }
        }

        private void FadeOutAndOpenLogin()
        {
            fadeOutTimer = new Timer { Interval = 20 };
            fadeOutTimer.Tick += (s, e) =>
            {
                this.Opacity -= 0.05;
                if (this.Opacity <= 0)
                {
                    fadeOutTimer.Stop();
                    fadeOutTimer.Dispose();
                    OpenLoginForm();
                }
            };
            fadeOutTimer.Start();
        }

        private void OpenLoginForm()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => Application.Exit();
            loginForm.Show();
            this.Hide();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void DrawSpinner(Graphics g)
        {
            if (panelSpinner == null) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = panelSpinner.Width / 2;
            int centerY = panelSpinner.Height / 2;
            int radius = 30;

            using (Pen pen = new Pen(Color.FromArgb(66, 153, 225), 4))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                for (int i = 0; i < 8; i++)
                {
                    float angle = (rotationAngle + i * 45) * (float)Math.PI / 180;
                    int opacity = 255 - (i * 30);
                    pen.Color = Color.FromArgb(Math.Max(50, opacity), 66, 153, 225);

                    float x1 = centerX + (float)Math.Cos(angle) * (radius - 10);
                    float y1 = centerY + (float)Math.Sin(angle) * (radius - 10);
                    float x2 = centerX + (float)Math.Cos(angle) * radius;
                    float y2 = centerY + (float)Math.Sin(angle) * radius;

                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        private void PanelSpinner_Paint(object sender, PaintEventArgs e)
        {
            DrawSpinner(e.Graphics);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            fadeInTimer?.Dispose();
            progressTimer?.Dispose();
            fadeOutTimer?.Dispose();
            spinnerTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}