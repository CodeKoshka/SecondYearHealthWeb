using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static iTextSharp.text.TabStop;

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

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1200, 700);
            this.MaximizeBox = false;
            this.MinimizeBox = true;

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
            UpdateMenuButton(btnBillingMenu, 400, "💰", "Billing And Discharge");

            lblQueueCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQueueCount.ForeColor = Color.White;
            lblQueueCount.AutoSize = true;
            lblQueueCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQueueCount.Location = new Point(
            panelHeader.Width - lblQueueCount.Width - 20,29);
            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);
            btnLogout.Size = new Size(250, 50);
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.Location = new Point(15, panelSidebar.Height - btnLogout.Height - 20);

            SwitchToTab(0);
            CenterSearchBar();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterSearchBar();
        }
        private void CenterSearchBar()
        {
            if (panelUniversalSearch != null && panelHeader != null)
            {
                panelUniversalSearch.Left = (panelHeader.Width - panelUniversalSearch.Width) / 2;
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

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            dgv.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    string originalName = column.DataPropertyName;
                    if (!string.IsNullOrWhiteSpace(originalName))
                    {
                        column.HeaderText = RenameColumns(originalName);
                    }

                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            };

            if (dgv.Name == "dgvQueue")
            {
                dgv.CellPainting -= DgvQueue_CellPainting;
                dgv.RowPostPaint -= DgvQueue_RowPostPaint;

                dgv.CellPainting += DgvQueue_CellPainting;
                dgv.RowPostPaint += DgvQueue_RowPostPaint;
            }
            else
            {
                dgv.RowPostPaint -= DgvUniversal_RowPostPaint;
                dgv.RowPostPaint += DgvUniversal_RowPostPaint;
            }
        }
        private void DgvQueue_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var dgv = sender as DataGridView;
                if (dgv == null || dgv.Name != "dgvQueue")
                {
                    e.Handled = false;
                    return;
                }

                var row = dgv.Rows[e.RowIndex];

                string priority = "Normal";
                if (row.Cells["priority"] != null &&
                    row.Cells["priority"].Value != null &&
                    row.Cells["priority"].Value != DBNull.Value)
                {
                    priority = row.Cells["priority"].Value.ToString();
                }

                Color priorityBgColor = GetPriorityBackgroundColor(priority);
                Color baseRowColor = (e.RowIndex % 2 == 0)
                    ? Color.White
                    : Color.FromArgb(249, 250, 251);

                Color finalColor = row.Selected
                    ? Color.FromArgb(255, 205, 210)
                    : BlendColors(priorityBgColor, baseRowColor);

                using (SolidBrush backBrush = new SolidBrush(finalColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                }

                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                var queueColumn = dgv.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c =>
                        string.Equals(c.DataPropertyName, "queue_number", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(c.HeaderText, "Queue", StringComparison.OrdinalIgnoreCase));

                if (queueColumn != null && e.ColumnIndex == queueColumn.Index)
                {
                    Rectangle cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int slabWidth = 10;
                    int offset = slabWidth + 4;

                    Rectangle textRect = new Rectangle(
                        cellRect.Left + offset,
                        cellRect.Top,
                        cellRect.Width - offset,
                        cellRect.Height
                    );

                    if (e.Value != null)
                    {
                        TextRenderer.DrawText(
                            e.Graphics,
                            e.Value.ToString(),
                            e.CellStyle.Font,
                            textRect,
                            Color.FromArgb(26, 32, 44),
                            TextFormatFlags.Left |
                            TextFormatFlags.VerticalCenter |
                            TextFormatFlags.EndEllipsis
                        );
                    }

                    e.Handled = true;
                    return;
                }

                Rectangle paintBounds = e.CellBounds;

                if (row.Selected && e.ColumnIndex == 0)
                {
                    paintBounds.X += 10;
                    paintBounds.Width -= 10;
                }

                if (e.Value != null)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        e.Value.ToString(),
                        e.CellStyle.Font,
                        paintBounds,
                        Color.FromArgb(26, 32, 44),
                        TextFormatFlags.Left |
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.EndEllipsis
                    );
                }

                e.Handled = true;
            }
            catch
            {
                e.Handled = false;
            }
        }

        private void DgvQueue_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvQueue.Rows.Count) return;

                DataGridViewRow row = dgvQueue.Rows[e.RowIndex];

                if (row.Selected)
                {
                    int slabWidth = 10;

                    using (SolidBrush slabBrush = new SolidBrush(Color.FromArgb(52, 152, 219)))
                    {
                        Rectangle slabRect = new Rectangle(
                            e.RowBounds.Left,
                            e.RowBounds.Top,
                            slabWidth,
                            e.RowBounds.Height
                        );

                        e.Graphics.FillRectangle(slabBrush, slabRect);
                    }
                }
            }
            catch { }
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
                    Color slabColor = Color.FromArgb(52, 152, 219);
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

        private Color GetPriorityColor(string priority)
        {
            switch (priority?.ToUpper())
            {
                case "EMERGENCY":
                    return Color.FromArgb(231, 76, 60);
                case "URGENT":
                    return Color.FromArgb(243, 156, 18);
                case "NORMAL":
                default:
                    return Color.FromArgb(46, 204, 113);
            }
        }

        private Color GetPriorityBackgroundColor(string priority)
        {
            switch (priority?.ToUpper())
            {
                case "EMERGENCY":
                    return Color.FromArgb(30, 231, 76, 60);
                case "URGENT":
                    return Color.FromArgb(30, 243, 156, 18);
                case "NORMAL":
                default:
                    return Color.FromArgb(30, 46, 204, 113);
            }
        }

        private Color BlendColors(Color foreground, Color background)
        {
            int alpha = foreground.A;
            int r = (foreground.R * alpha + background.R * (255 - alpha)) / 255;
            int g = (foreground.G * alpha + background.G * (255 - alpha)) / 255;
            int b = (foreground.B * alpha + background.B * (255 - alpha)) / 255;

            return Color.FromArgb(r, g, b);
        }

        private void InitializeUniversalSearch()
        {
            InitializeSearchComponents();
            SetupSearchSuggestionsList();
        }

        private void InitializeSearchComponents()
        {
            panelSearchCategories = new Panel();
            panelSearchCategories.BackColor = Color.White;
            panelSearchCategories.Height = 40;
            panelSearchCategories.Visible = false;
            panelSearchCategories.Name = "panelSearchCategories";

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

            Panel suggestionsShadow = new Panel();
            suggestionsShadow.BackColor = Color.FromArgb(40, 0, 0, 0);
            suggestionsShadow.Visible = false;
            suggestionsShadow.Name = "suggestionsShadow";

            this.Controls.Add(lblSearchStatus);
            this.Controls.Add(panelSearchCategories);
            this.Controls.Add(suggestionsShadow);
            this.Controls.Add(suggestionsContainer);

            suggestionsShadow.SendToBack();
            suggestionsContainer.BringToFront();
            panelSearchCategories.BringToFront();
        }

        private void SetupSearchSuggestionsList()
        {
            searchSuggestionsListBox = new ListBox();
            searchSuggestionsListBox.Font = new Font("Segoe UI", 10F);
            searchSuggestionsListBox.BorderStyle = BorderStyle.None;
            searchSuggestionsListBox.BackColor = Color.White;
            searchSuggestionsListBox.ForeColor = Color.FromArgb(26, 32, 44);
            searchSuggestionsListBox.IntegralHeight = false;
            searchSuggestionsListBox.DrawMode = DrawMode.OwnerDrawFixed;
            searchSuggestionsListBox.ItemHeight = 50;
            searchSuggestionsListBox.ScrollAlwaysVisible = false;
            searchSuggestionsListBox.Click += SearchSuggestionsListBox_Click;
            searchSuggestionsListBox.KeyDown += SearchSuggestionsListBox_KeyDown;
            searchSuggestionsListBox.MouseMove += SearchSuggestionsListBox_MouseMove;
            searchSuggestionsListBox.MouseWheel += SearchSuggestionsListBox_MouseWheel;

            searchSuggestionsListBox.DrawItem += SearchSuggestionsListBox_DrawItem;

            Panel suggestionsContainer = this.Controls.Find("suggestionsContainer", true).FirstOrDefault() as Panel;
            Panel suggestionsShadow = this.Controls.Find("suggestionsShadow", true).FirstOrDefault() as Panel;

            if (suggestionsContainer != null)
            {
                suggestionsContainer.Controls.Add(searchSuggestionsListBox);
            }

            searchSuggestionsListBox.Tag = new
            {
                Container = suggestionsContainer,
                Shadow = suggestionsShadow
            };
        }

        private void SearchSuggestionsListBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (searchSuggestionsListBox.Items.Count == 0)
                return;

            int currentIndex = searchSuggestionsListBox.TopIndex;
            int scrollAmount = e.Delta > 0 ? -1 : 1;

            int newIndex = Math.Max(0, Math.Min(currentIndex + scrollAmount,
                searchSuggestionsListBox.Items.Count - 1));

            if (newIndex != currentIndex)
            {
                searchSuggestionsListBox.TopIndex = newIndex;
            }
        }

        private void SearchSuggestionsListBox_DrawItem(object sender, DrawItemEventArgs e)
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
                using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(231, 76, 60)))
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
        }
        private void PositionSearchSuggestions()
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

            panelSearchCategories.Visible = false;

            searchSuggestionsListBox.Parent = container;
            searchSuggestionsListBox.Location = new Point(1, statusHeight);
            searchSuggestionsListBox.Size = new Size(width - 2, listHeight);
            searchSuggestionsListBox.BorderStyle = BorderStyle.FixedSingle;
            searchSuggestionsListBox.Region = null;

            if (searchSuggestionsListBox.Items.Count > 0)
            {
                searchSuggestionsListBox.TopIndex = 0;
            }

            shadow.Location = new Point(searchPanelLocation.X + 2, searchPanelBottom + 2);
            shadow.Size = new Size(width, totalHeight);
            shadow.Region = new Region(path.Clone() as System.Drawing.Drawing2D.GraphicsPath);

            shadow.Visible = true;
            container.Visible = true;
            lblSearchStatus.Visible = true;

            container.BringToFront();
            shadow.SendToBack();
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
                ReorderQueueNumbersByPriority();

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
            AND q.status NOT IN ('Completed', 'Discharged')
            ORDER BY 
            CASE q.priority 
            WHEN 'Emergency' THEN 1 
            WHEN 'Urgent' THEN 2 
            ELSE 3 
            END, 
            q.registered_time";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(queryQueue);
                dgvQueue.DataSource = dtQueue;

                if (dgvQueue.Columns["queue_id"] != null)
                {
                    dgvQueue.Columns["queue_id"].Visible = false;
                }
                if (dgvQueue.Columns["patient_id"] != null)
                {
                    dgvQueue.Columns["patient_id"].Visible = false;
                }

                int queueCount = dtQueue.Rows.Count;
                lblQueueCount.Text = $"Total in Queue: {queueCount}";

                lblQueueCount.Location = new Point(
                    panelHeader.Width - lblQueueCount.Width - 20,
                    29
                );

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
            WHEN q.status = 'Waiting' THEN 'Waiting in Queue'
            WHEN q.status = 'Called' THEN 'Called - In Progress'
            WHEN q.status = 'In Progress' THEN 'With Doctor'
            WHEN q.status = 'Completed' THEN 'Visit Completed'
            ELSE q.status
            END AS status,
            q.queue_number AS queue_number,
            (SELECT COUNT(*) FROM PatientQueue WHERE patient_id = p.patient_id) as total_visits
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            INNER JOIN PatientQueue q ON p.patient_id = q.patient_id
            WHERE u.is_active = 1
            AND q.queue_date = CURDATE()
            AND q.status NOT IN ('Discharged')
            ORDER BY q.queue_number";

                DataTable dtPatients = DatabaseHelper.ExecuteQuery(queryPatients);
                dgvPatients.DataSource = dtPatients;

                dgvPatients.DataBindingComplete += (s, ev) =>
                {
                    if (dgvPatients.Columns["patient_id"] != null)
                        dgvPatients.Columns["patient_id"].Visible = false;

                    if (dgvPatients.Columns["queue_number"] != null)
                    {
                        dgvPatients.Columns["queue_number"].Width = 60;
                        dgvPatients.Columns["queue_number"].DisplayIndex = 0;
                    }

                    if (dgvPatients.Columns["name"] != null)
                    {
                        dgvPatients.Columns["name"].Width = 150;
                    }

                    if (dgvPatients.Columns["age"] != null)
                    {
                        dgvPatients.Columns["age"].Width = 50;
                    }

                    if (dgvPatients.Columns["gender"] != null)
                    {
                        dgvPatients.Columns["gender"].Width = 70;
                    }

                    if (dgvPatients.Columns["blood_type"] != null)
                    {
                        dgvPatients.Columns["blood_type"].Width = 80;
                    }

                    if (dgvPatients.Columns["phone_number"] != null)
                    {
                        dgvPatients.Columns["phone_number"].Width = 110;
                    }

                    if (dgvPatients.Columns["email"] != null)
                    {
                        dgvPatients.Columns["email"].Width = 180;
                    }

                    if (dgvPatients.Columns["status"] != null)
                    {
                        dgvPatients.Columns["status"].Width = 150;
                    }

                    if (dgvPatients.Columns["total_visits"] != null)
                    {
                        dgvPatients.Columns["total_visits"].Width = 80;
                    }

                    dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                    dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                    dgvPatients.RowTemplate.Height = 38;

                    foreach (DataGridViewRow row in dgvPatients.Rows)
                    {
                        if (row.Cells["status"].Value != null)
                        {
                            string status = row.Cells["status"].Value.ToString();

                            if (status.Contains("Waiting"))
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(140, 100, 0);
                            }
                            else if (status.Contains("Called") || status.Contains("In Progress") || status.Contains("With Doctor"))
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(230, 245, 255);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 80, 140);
                            }
                            else if (status.Contains("Completed"))
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 100, 0);
                            }
                        }
                    }
                };

                LoadBillingData();

                if (dgvQueue.Rows.Count > 0)
                {
                    dgvQueue.ClearSelection();
                }

                if (dgvPatients.Rows.Count > 0)
                {
                    dgvPatients.ClearSelection();
                }

                if (dgvBilling.Rows.Count > 0)
                {
                    dgvBilling.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReorderQueueNumbersByPriority()
        {
            try
            {
                string selectQuery = @"
                SELECT queue_id, priority
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

                Dictionary<string, int> queueCounters = new Dictionary<string, int>
                {
                    { "Emergency", 1 },
                    { "Urgent", 1 },
                    { "Normal", 1 }
                };

                foreach (DataRow row in dt.Rows)
                {
                    int queueId = Convert.ToInt32(row["queue_id"]);
                    string priority = row["priority"].ToString();

                    int queueNumber = queueCounters[priority];

                    string updateQuery = @"
                    UPDATE patientqueue 
                    SET queue_number = @queueNumber 
                    WHERE queue_id = @queueId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@queueNumber", queueNumber),
                        new MySqlParameter("@queueId", queueId));

                    queueCounters[priority]++;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Queue reorder error: {ex.Message}");
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
                q.queue_id,
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
                FROM patientqueue q
                INNER JOIN Patients p ON q.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                LEFT JOIN Billing b ON b.queue_id = q.queue_id
                WHERE q.queue_date = CURDATE()
                AND q.status = 'Completed'
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
                {
                    dgvBilling.Columns["bill_id"].Visible = false;
                }
                if (dgvBilling.Columns["patient_id"] != null)
                {
                    dgvBilling.Columns["patient_id"].Visible = false;
                }
                if (dgvBilling.Columns["queue_id"] != null)
                {
                    dgvBilling.Columns["queue_id"].Visible = false;
                }
                if (dgvBilling.Columns["Total Amount"] != null)
                {
                    dgvBilling.Columns["Total Amount"].Visible = false;
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

                int activeTab = tabControl.SelectedIndex;

                if (activeTab == 0)
                {
                    string queueQuery = @"
            SELECT q.queue_id, q.patient_id, q.queue_number, u.name AS patient_name, 
            q.priority, q.status, 'Queue' as source
            FROM patientqueue q
            INNER JOIN Patients p ON q.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            WHERE q.queue_date = CURDATE()
            AND q.status != 'Completed'
            AND (u.name LIKE @search OR q.priority LIKE @search OR q.status LIKE @search OR q.queue_number LIKE @search)
            ORDER BY 
            CASE q.priority 
            WHEN 'Emergency' THEN 1 
            WHEN 'Urgent' THEN 2 
            ELSE 3 
            END, 
            q.queue_number
            LIMIT 10";

                    DataTable queue = DatabaseHelper.ExecuteQuery(queueQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in queue.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["queue_number"]),
                            DisplayText = $"Queue #{row["queue_number"]} - {row["patient_name"]} - {row["priority"]} - {row["status"]}",
                            Source = "Queue",
                            Data = row
                        });
                        totalResults++;
                    }
                }
                else if (activeTab == 1)
                {
                    string patientQuery = @"
            SELECT p.patient_id, u.user_id, u.name, u.email, u.age, u.gender,
            p.blood_type, q.queue_number, 'Patients' as source
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            INNER JOIN PatientQueue q ON p.patient_id = q.patient_id
            WHERE u.is_active = 1
            AND q.queue_date = CURDATE()
            AND q.status NOT IN ('Discharged')
            AND (u.name LIKE @search OR u.email LIKE @search OR p.blood_type LIKE @search OR q.queue_number LIKE @search)
            GROUP BY p.patient_id
            ORDER BY u.name
            LIMIT 10";

                    DataTable patients = DatabaseHelper.ExecuteQuery(patientQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in patients.Rows)
                    {
                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = Convert.ToInt32(row["patient_id"]),
                            DisplayText = $"{row["name"]} - Queue #{row["queue_number"]} - {row["age"]} yrs, {row["gender"]} - {row["blood_type"]}",
                            Source = "Patients",
                            Data = row
                        });
                        totalResults++;
                    }
                }
                else if (activeTab == 2)
                {
                    string billingQuery = @"
                    SELECT 
                    b.bill_id, 
                    q.patient_id, 
                    u.name AS patient_name,
                    IFNULL(b.amount, 0) AS amount, 
                    CASE 
                    WHEN b.bill_id IS NULL THEN 'Awaiting Bill'
                    ELSE b.status
                    END AS status,
                    'Billing' as source
                    FROM patientqueue q
                    INNER JOIN Patients p ON q.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    LEFT JOIN Billing b ON b.queue_id = q.queue_id
                    WHERE q.queue_date = CURDATE()
                    AND q.status = 'Completed'
                    AND (u.name LIKE @search OR 
                    (b.status IS NOT NULL AND b.status LIKE @search) OR
                    (b.bill_id IS NULL AND 'Awaiting Bill' LIKE @search))
                    ORDER BY 
                    CASE 
                    WHEN b.bill_id IS NULL THEN 1
                    WHEN b.status = 'Pending' THEN 2
                    WHEN b.status = 'Partially Paid' THEN 3
                    WHEN b.status = 'Paid' THEN 4
                    ELSE 5
                    END,
                    q.completed_time DESC
                    LIMIT 10";

                    DataTable billing = DatabaseHelper.ExecuteQuery(billingQuery,
                        new MySqlParameter("@search", $"%{searchText}%"));

                    foreach (DataRow row in billing.Rows)
                    {
                        string displayText;
                        if (row["status"].ToString() == "Awaiting Bill")
                        {
                            displayText = $"{row["patient_name"]} - Awaiting Bill";
                        }
                        else
                        {
                            displayText = $"{row["patient_name"]} - {row["status"]}";
                        }

                        int billId = row["bill_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["bill_id"]);

                        searchSuggestionsListBox.Items.Add(new UniversalSearchItem
                        {
                            Id = billId > 0 ? billId : Convert.ToInt32(row["patient_id"]),
                            DisplayText = displayText,
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

        private string RenameColumns(string columnName)
        {
            var columnMappings = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"queue_id", "Queue ID"},
                {"queue_number", "Queue"},
                {"Queue", "Queue"},
                {"patient_id", "Patient ID"},
                {"name", "Patient Name"},
                {"Patient", "Patient Name"},
                {"Doctor", "Doctor Name"},
                {"priority", "Priority Level"},
                {"status", "Status"},
                {"registered_time", "Registered Time"},
                {"age", "Age"},
                {"gender", "Gender"},
                {"blood_type", "BloodType"},
                {"phone_number", "Number"},
                {"Contact", "Number"},
                {"email", "Email"},
                {"total_visits", "Visits"},
                {"Visits", "Visits"},
                {"bill_id", "Bill ID"},
                {"bill_date", "Bill Date"},
                {"Date", "Bill Date"},
                {"amount", "Total Amount"},
                {"payment_method", "Payment Method"},
                {"Payment", "Payment Method"},
                {"discharged_time", "Discharged Date"},
                {"Discharge", "Discharge Status"}
            };

            if (columnMappings.ContainsKey(columnName))
                return columnMappings[columnName];

            return System.Globalization.CultureInfo.CurrentCulture.TextInfo
                .ToTitleCase(columnName.Replace("_", " ").ToLower());
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

        private void FocusOnQueue(int queueNumber)
        {
            foreach (DataGridViewRow row in dgvQueue.Rows)
            {
                if (row.Cells["queue_number"].Value != null &&
                    Convert.ToInt32(row.Cells["queue_number"].Value) == queueNumber)
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

        private void BtnViewBillDetails_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to view details.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var billIdCell = dgvBilling.SelectedRows[0].Cells["bill_id"];
            if (billIdCell?.Value == null || billIdCell.Value == DBNull.Value)
            {
                MessageBox.Show(
                    "❌ NO BILL FOUND\n\n" +
                    "This patient doesn't have a bill yet.\n" +
                    "Please create a bill first using 'Create Bill' button.",
                    "No Bill Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int billId = Convert.ToInt32(billIdCell.Value);

            BillDetailsViewForm detailsForm = new BillDetailsViewForm(billId);
            detailsForm.ShowDialog();
        }

        private void ShowEquipmentReportFromQueue(int patientId, string patientName)
        {
            try
            {
                string query = @"
                SELECT equipment_checklist, queue_id
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
                int queueId = Convert.ToInt32(dt.Rows[0]["queue_id"]);

                using (ServiceChecklistForm viewForm = ServiceChecklistForm.CreateViewMode(
                    queueId, patientId, patientName, equipmentReport))
                {
                    viewForm.ShowDialog();
                }
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

            if (status == "Paid")
            {
                MessageBox.Show(
                    "ℹ️ BILL ALREADY PAID\n\n" +
                    "This bill has already been paid in full.\n\n" +
                    "Use 'View Payment History' to see payment details.",
                    "Already Paid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (status == "Cancelled")
            {
                MessageBox.Show(
                    "⚠️ BILL CANCELLED\n\n" +
                    "This bill has been cancelled and cannot accept payments.\n\n" +
                    "Contact administration if this is an error.",
                    "Bill Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();
            decimal amount = Convert.ToDecimal(dgvBilling.SelectedRows[0].Cells["Total Amount"].Value);

            try
            {
                using (PaymentProcessingForm paymentForm = new PaymentProcessingForm(
                    billId, patientId, patientName, amount, status, currentUser.UserId))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();

                        MessageBox.Show(
                            "✅ Payment successfully recorded!\n\n" +
                            "The billing status has been updated.\n" +
                            "You can now proceed with patient discharge if fully paid.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening payment form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to cancel.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dgvBilling.SelectedRows[0];
            object billIdObj = selectedRow.Cells["bill_id"].Value;
            string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";
            string patientName = selectedRow.Cells["Patient Name"].Value?.ToString() ?? "Unknown";

            if (billIdObj == DBNull.Value || billIdObj == null)
            {
                MessageBox.Show(
                    "❌ NO BILL FOUND\n\n" +
                    "This patient doesn't have a bill yet.\n" +
                    "Please create a bill first using 'Create Bill' or 'Update Bill' button.",
                    "No Bill Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int billId = Convert.ToInt32(billIdObj);

            if (status == "Cancelled")
            {
                MessageBox.Show(
                    "ℹ️ ALREADY CANCELLED\n\n" +
                    "This bill has already been cancelled.",
                    "Bill Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (status == "Paid")
            {
                MessageBox.Show(
                    "❌ CANNOT CANCEL PAID BILL\n\n" +
                    "This bill has already been fully paid.\n\n" +
                    "Paid bills cannot be cancelled. If you need to issue a refund,\n" +
                    "please contact the finance department or administrator.",
                    "Payment Already Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (status == "Partially Paid")
            {
                decimal totalAmount = Convert.ToDecimal(selectedRow.Cells["Total Amount"].Value);

                try
                {
                    string checkPaymentsQuery = @"
                    SELECT COALESCE(SUM(amount_paid), 0) as total_paid
                    FROM PaymentTransactions
                    WHERE bill_id = @billId";

                    object result = DatabaseHelper.ExecuteScalar(checkPaymentsQuery,
                        new MySqlParameter("@billId", billId));

                    decimal amountPaid = Convert.ToDecimal(result);

                    DialogResult confirmPartial = MessageBox.Show(
                        $"⚠️ PARTIAL PAYMENT DETECTED\n\n" +
                        $"Patient: {patientName}\n" +
                        $"Total Bill: ₱{totalAmount:N2}\n" +
                        $"Amount Paid: ₱{amountPaid:N2}\n" +
                        $"Outstanding: ₱{(totalAmount - amountPaid):N2}\n\n" +
                        "This bill has partial payments recorded.\n\n" +
                        "Cancelling will:\n" +
                        "• Mark the bill as 'Cancelled'\n" +
                        "• Preserve payment transaction records\n" +
                        "• May require refund processing\n\n" +
                        "⚠️ Contact finance department about refund procedures.\n\n" +
                        "Continue with cancellation?",
                        "Partial Payment Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (confirmPartial != DialogResult.Yes)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking payment status: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult confirm = MessageBox.Show(
                $"🚫 CANCEL BILL CONFIRMATION\n\n" +
                $"Patient: {patientName}\n" +
                $"Bill ID: #{billId}\n" +
                $"Current Status: {status}\n\n" +
                "This will:\n" +
                "✓ Mark the bill as 'Cancelled'\n" +
                "✓ Preserve all bill records for audit purposes\n" +
                "✓ Allow patient discharge without payment\n" +
                "✗ Bill cannot be reactivated after cancellation\n\n" +
                "⚠️ Note: Payment records (if any) will be preserved.\n\n" +
                "Are you sure you want to cancel this bill?",
                "Confirm Bill Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string cancelQuery = @"
                UPDATE Billing 
                SET status = 'Cancelled',
                notes = CONCAT(IFNULL(notes, ''), 
                CHAR(10), CHAR(10),
                CANCELLED on ', NOW(), ' by user ID: ', @cancelledBy)
                WHERE bill_id = @billId";

                DatabaseHelper.ExecuteNonQuery(cancelQuery,
                    new MySqlParameter("@billId", billId),
                    new MySqlParameter("@cancelledBy", currentUser.UserId));

                MessageBox.Show(
                    "✅ BILL CANCELLED SUCCESSFULLY\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Bill ID: #{billId}\n\n" +
                    "Actions completed:\n" +
                    "✓ Bill marked as 'Cancelled'\n" +
                    "✓ All records preserved for audit\n" +
                    "✓ Patient can now be discharged\n\n" +
                    "Note: Any payment records have been preserved.\n" +
                    "Contact finance for refund processing if needed.",
                    "Bill Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ ERROR CANCELLING BILL\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    "The bill was not cancelled.\n" +
                    "Please try again or contact support.",
                    "Cancellation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";

            if (billId > 0 && !status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    $"A bill already exists for patient: {patientName}.\n\n" +
                    $"Current Status: {status}\n\n" +
                    "Use 'Update Bill' to edit the existing bill instead.",
                    "Bill Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (billId > 0 && status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                DialogResult confirm = MessageBox.Show(
                    $"🔄 CREATE NEW BILL TO REPLACE CANCELLED BILL\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Old Bill ID: #{billId} (Cancelled)\n\n" +
                    "This will:\n" +
                    "✓ Keep the old cancelled bill for audit purposes\n" +
                    "✓ Create a fresh new bill for this patient\n" +
                    "✓ Link the new bill to the current visit\n\n" +
                    "The cancelled bill will remain in the system as a record.\n\n" +
                    "Continue with creating a new bill?",
                    "Replace Cancelled Bill",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;
            }

            int userId = currentUser?.UserId ?? 1;
            using (BillingForm billingForm = new BillingForm(userId, patientId))
            {
                var result = billingForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadBillingData();

                    if (billId > 0 && status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(
                            "✅ NEW BILL CREATED SUCCESSFULLY\n\n" +
                            $"Patient: {patientName}\n\n" +
                            "A new bill has been created to replace the cancelled one.\n" +
                            "The old cancelled bill remains in the system for audit purposes.",
                            "Bill Replaced",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
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
                string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";
                string patientName = selectedRow.Cells["Patient Name"].Value?.ToString() ?? "Unknown";

                if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                {
                    string patientNameCancelled = selectedRow.Cells["Patient Name"].Value?.ToString() ?? "Unknown";

                    DialogResult result = MessageBox.Show(
                        "❌ BILL IS CANCELLED\n\n" +
                        $"Patient: {patientNameCancelled}\n" +
                        $"Bill ID: #{billIdObj}\n\n" +
                        "This bill has been cancelled and cannot be edited.\n\n" +
                        "Options:\n" +
                        "• YES - Create a new bill to replace this one\n" +
                        "• NO - Cancel this operation\n\n" +
                        "Would you like to create a new bill?",
                        "Cancelled Bill - Cannot Edit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        BtnCreateBill_Click(sender, e);
                    }
                    return;
                }

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

                if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase) ||
                    status.Equals("Partially Paid", StringComparison.OrdinalIgnoreCase))
                {
                    string checkPaymentsQuery = @"
                SELECT COALESCE(SUM(amount_paid), 0) as total_paid
                FROM PaymentTransactions
                WHERE bill_id = @billId";

                    decimal amountPaid = Convert.ToDecimal(DatabaseHelper.ExecuteScalar(checkPaymentsQuery,
                        new MySqlParameter("@billId", billId)));

                    if (amountPaid > 0)
                    {
                        DialogResult confirmRefund = MessageBox.Show(
                            $"⚠️ EDIT BILL WITH PAYMENTS\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Bill ID: #{billId}\n" +
                            $"Current Status: {status}\n" +
                            $"Amount Paid: ₱{amountPaid:N2}\n\n" +
                            "⚠️ IMPORTANT NOTICE:\n" +
                            "Editing this bill will:\n" +
                            "• REFUND all payments (₱" + amountPaid.ToString("N2") + ")\n" +
                            "• CLEAR all payment transactions\n" +
                            "• Reset bill status to 'Pending'\n" +
                            "• Reset bill amount to ₱0.00\n" +
                            "• Require re-processing payment after editing\n\n" +
                            "💡 Payment transactions will be archived in notes\n" +
                            "for audit purposes before being deleted.\n\n" +
                            "Continue with editing?",
                            "⚠️ Confirm Bill Edit & Refund",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

                        if (confirmRefund != DialogResult.Yes)
                        {
                            return;
                        }

                        try
                        {
                            string getTransactionsQuery = @"
                            SELECT 
                            transaction_id,
                            amount_paid,
                            payment_method,
                            reference_number,
                            payment_date,
                            u.name as processed_by_name
                            FROM PaymentTransactions pt
                            LEFT JOIN Users u ON pt.processed_by = u.user_id
                            WHERE bill_id = @billId
                            ORDER BY payment_date";

                            DataTable dtTransactions = DatabaseHelper.ExecuteQuery(getTransactionsQuery,
                                new MySqlParameter("@billId", billId));

                            System.Text.StringBuilder transactionNotes = new System.Text.StringBuilder();
                            transactionNotes.AppendLine("\n\n--- PAYMENT TRANSACTIONS ARCHIVED (REFUNDED) ---");
                            transactionNotes.AppendLine($"Refunded on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                            transactionNotes.AppendLine($"Total Refunded: ₱{amountPaid:N2}");
                            transactionNotes.AppendLine($"Refunded by user ID: {currentUser.UserId}");
                            transactionNotes.AppendLine("\nOriginal Transactions:");

                            foreach (DataRow row in dtTransactions.Rows)
                            {
                                transactionNotes.AppendLine($"  • Transaction #{row["transaction_id"]}");
                                transactionNotes.AppendLine($"    Amount: ₱{Convert.ToDecimal(row["amount_paid"]):N2}");
                                transactionNotes.AppendLine($"    Method: {row["payment_method"]}");
                                if (row["reference_number"] != DBNull.Value && !string.IsNullOrEmpty(row["reference_number"].ToString()))
                                {
                                    transactionNotes.AppendLine($"    Reference: {row["reference_number"]}");
                                }
                                transactionNotes.AppendLine($"    Date: {Convert.ToDateTime(row["payment_date"]):yyyy-MM-dd HH:mm:ss}");
                                transactionNotes.AppendLine($"    Processed By: {row["processed_by_name"]}");
                            }
                            transactionNotes.AppendLine("--- END OF ARCHIVED TRANSACTIONS ---");

                            string deleteTransactionsQuery = @"
                            DELETE FROM PaymentTransactions 
                            WHERE bill_id = @billId";

                            DatabaseHelper.ExecuteNonQuery(deleteTransactionsQuery,
                                new MySqlParameter("@billId", billId));

                            string refundQuery = @"
                            UPDATE Billing 
                            SET status = 'Pending',
                            payment_method = 'Pending Payment',
                            notes = CONCAT(IFNULL(notes, ''), @transactionNotes)
                            WHERE bill_id = @billId";

                            DatabaseHelper.ExecuteNonQuery(refundQuery,
                                new MySqlParameter("@billId", billId),
                                new MySqlParameter("@transactionNotes", transactionNotes.ToString()));

                            MessageBox.Show(
                                $"💰 PAYMENTS REFUNDED & CLEARED\n\n" +
                                $"Amount Refunded: ₱{amountPaid:N2}\n" +
                                $"Bill Status: Pending\n" +
                                $"Payment Transactions: Deleted\n\n" +
                                "✓ Payment records archived in bill notes for audit\n" +
                                "✓ Bill reset to ₱0.00\n" +
                                "✓ All payment data cleared\n\n" +
                                "You can now edit the bill.\n\n" +
                                "After editing, use 'Process Payment' to collect payment again.",
                                "Refund Complete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"❌ ERROR PROCESSING REFUND\n\n" +
                                $"Error: {ex.Message}\n\n" +
                                "The refund failed. Cannot edit bill.",
                                "Refund Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                int userId = currentUser?.UserId ?? 1;

                using (BillingForm billingForm = new BillingForm(userId, patientId, billId))
                {
                    var dialogResult = billingForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        LoadBillingData();

                        MessageBox.Show(
                            "✅ BILL UPDATED SUCCESSFULLY\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Bill ID: #{billId}\n\n" +
                            "The bill has been updated.\n" +
                            "Status: Pending\n" +
                            "Amount: Reset to new total\n\n" +
                            "💡 Use 'Process Payment' to collect payment for the updated bill.",
                            "Bill Updated",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
                    $"Current Status: {status}\n\n" +
                    "Please either:\n" +
                    "• Process payment to mark bill as 'Paid', OR\n" +
                    "• Cancel the bill if no payment is required",
                    "Discharge Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string dischargeWarning = status == "Cancelled"
                ? "⚠️ This patient has a CANCELLED bill.\n" +
                  "Discharging will proceed without payment collection.\n\n"
                : "";

            string confirmMessage = $"🏥 DISCHARGE PATIENT: {patientName}\n\n" +
                dischargeWarning +
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
                                string getQueueDataQuery = @"
                            SELECT queue_id, patient_id, queue_date, completed_time, doctor_id
                            FROM patientqueue
                            WHERE patient_id = @patientId 
                            AND status = 'Completed'
                            AND queue_date = CURDATE()";

                                int queueId = 0;
                                DateTime queueDate = DateTime.Now;
                                DateTime? completedTime = null;
                                int? doctorId = null;

                                using (var cmd = new MySqlCommand(getQueueDataQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            queueId = reader.GetInt32("queue_id");
                                            queueDate = reader.GetDateTime("queue_date");
                                            if (!reader.IsDBNull(reader.GetOrdinal("completed_time")))
                                                completedTime = reader.GetDateTime("completed_time");
                                            if (!reader.IsDBNull(reader.GetOrdinal("doctor_id")))
                                                doctorId = reader.GetInt32("doctor_id");
                                        }
                                    }
                                }

                                string archiveVisitQuery = @"
                            INSERT INTO CompletedVisits (queue_id, patient_id, queue_date, completed_time, archived_by, archived_date, notes)
                            VALUES (@queueId, @patientId, @queueDate, @completedTime, @archivedBy, NOW(), @notes)";

                                string billInfo = "";
                                if (billIdObj != DBNull.Value && billIdObj != null)
                                {
                                    int billId = Convert.ToInt32(billIdObj);
                                    billInfo = $"\nBill ID: {billId} - Status: {status}";
                                }

                                using (var cmd = new MySqlCommand(archiveVisitQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@queueId", queueId);
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    cmd.Parameters.AddWithValue("@queueDate", queueDate);
                                    cmd.Parameters.AddWithValue("@completedTime", (object)completedTime ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@archivedBy", currentUser.UserId);
                                    cmd.Parameters.AddWithValue("@notes", $"Discharged: {DateTime.Now:yyyy-MM-dd HH:mm:ss}{billInfo}");
                                    cmd.ExecuteNonQuery();
                                }

                                string markDischargedQuery = @"
                            UPDATE patientqueue
                            SET status = 'Discharged', 
                            discharged_time = NOW(),
                            equipment_checklist = NULL,
                            reason_for_visit = NULL
                            WHERE patient_id = @patientId
                            AND queue_date = CURDATE()";

                                using (var cmd = new MySqlCommand(markDischargedQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@patientId", patientId);
                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                string successMessage = $"✅ PATIENT DISCHARGED SUCCESSFULLY\n\n" +
                                    $"Patient: {patientName}\n\n" +
                                    "Actions completed:\n" +
                                    "✓ Visit archived to CompletedVisits\n" +
                                    "✓ Queue marked as Discharged\n" +
                                    "✓ Billing records preserved\n" +
                                    "✓ Equipment checklist cleared\n" +
                                    "✓ Intake data cleared\n\n" +
                                    "⚕️ Medical records preserved\n\n";

                                if (status == "Cancelled")
                                {
                                    successMessage += "📋 Note: Patient discharged with cancelled bill status.";
                                }

                                successMessage += "\n\nPatient can now be re-added to queue for future visits.";

                                MessageBox.Show(
                                    successMessage,
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
            using (AddToQueueForm addQueueForm = new AddToQueueForm(currentUser.UserId))
            {
                if (addQueueForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();

                    MessageBox.Show(
                        "✅ PATIENT ADDED TO QUEUE\n\n" +
                        "The patient has been successfully added to today's queue.\n\n" +
                        "Next steps:\n" +
                        "• Assign a doctor to the patient\n" +
                        "• Call the patient when ready\n" +
                        "• Doctor will complete the consultation",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

            using (AssignDoctorForm assignForm = new AssignDoctorForm(queueId, patientName))
            {
                if (assignForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
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
            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);

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
                string getDoctorQuery = "SELECT doctor_id FROM PatientQueue WHERE queue_id = @queueId";
                object doctorIdObj = DatabaseHelper.ExecuteScalar(getDoctorQuery,
                    new MySqlParameter("@queueId", queueId));

                if (doctorIdObj == null || doctorIdObj == DBNull.Value)
                {
                    MessageBox.Show(
                        "❌ NO DOCTOR ASSIGNED\n\n" +
                        "Please assign a doctor to this patient first.",
                        "Doctor Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int assignedDoctorId = Convert.ToInt32(doctorIdObj);

                string checkActivePatients = @"
                SELECT COUNT(*) 
                FROM patientqueue 
                WHERE doctor_id = @doctorId 
                AND queue_date = CURDATE()
                AND status IN ('Called', 'In Progress')";

                int activePatientCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkActivePatients,
                    new MySqlParameter("@doctorId", assignedDoctorId)));

                if (activePatientCount > 0)
                {
                    MessageBox.Show(
                        "❌ DOCTOR IS BUSY\n\n" +
                        $"Doctor: {doctorName}\n\n" +
                        "This doctor is currently busy with another patient.\n\n" +
                        "Please wait for them to complete their current consultation\n" +
                        "or assign a different doctor to this patient.",
                        "Doctor Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();
                int queueNumber = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_number"].Value);

                string updateQueueQuery = @"
            UPDATE PatientQueue 
            SET status = 'Called', called_time = NOW()
            WHERE queue_id = @queueId";

                DatabaseHelper.ExecuteNonQuery(updateQueueQuery,
                    new MySqlParameter("@queueId", queueId));

                string updateDoctorQuery = @"
            UPDATE Doctors 
            SET is_available = 0 
            WHERE doctor_id = @doctorId";

                DatabaseHelper.ExecuteNonQuery(updateDoctorQuery,
                    new MySqlParameter("@doctorId", assignedDoctorId));

                MessageBox.Show(
                    $"✅ PATIENT CALLED\n\n" +
                    $"Queue #{queueNumber} - {patientName}\n\n" +
                    $"Assigned to: {doctorName}\n\n" +
                    "The doctor's status is now 'Busy'.\n" +
                    "They will be available again after completing this consultation.",
                    "Patient Called",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calling patient: {ex.Message}", "Error",
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

        private void BtnEditIntake_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

            if (!HasPatientIntakeData(patientId))
            {
                MessageBox.Show(
                    "No intake data found for this patient.\n\n" +
                    "This patient has not been added to the queue yet.\n" +
                    "Please add them to the queue first to create intake data.",
                    "No Data Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string checkQueueQuery = @"
            SELECT COUNT(*) 
            FROM PatientQueue 
            WHERE patient_id = @patientId 
            AND queue_date = CURDATE()
            AND status != 'Discharged'";

            int queueCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQueueQuery,
                new MySqlParameter("@patientId", patientId)));

            if (queueCount == 0)
            {
                MessageBox.Show(
                    $"Patient: {patientName}\n\n" +
                    "This patient is not currently in today's queue.\n\n" +
                    "You can only edit intake information for patients\n" +
                    "who are currently in the queue.",
                    "Not in Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: false))
            {
                if (intakeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show(
                        "✓ Patient information updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void BtnViewProfile_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view their profile.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

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

        private void BtnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

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

            DialogResult confirm = MessageBox.Show(
                $"Edit patient record?\n\n" +
                $"Patient: {patientName}\n\n" +
                "You will be able to edit:\n" +
                "• Name\n" +
                "• Date of Birth\n" +
                "• Gender\n" +
                "• Email (optional)\n" +
                "• Profile Photo\n\n" +
                "⚠️ Note: Patient role cannot be changed.\n\n" +
                "Continue?",
                "Edit Patient",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (RegisterForm editForm = new RegisterForm(userId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(
                            $"✓ Patient record updated successfully!\n\n" +
                            $"Patient: {patientName}\n\n" +
                            "Changes have been saved to the database.",
                            "Update Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadData();
                    }
                }
            }
        }

        private void BtnRemoveAllFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.Rows.Count == 0)
            {
                MessageBox.Show(
                    "The queue is already empty.",
                    "No Patients in Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string countQuery = @"
        SELECT COUNT(*) 
        FROM patientqueue 
        WHERE queue_date = CURDATE() 
        AND status != 'Completed'";

            int activePatients = Convert.ToInt32(DatabaseHelper.ExecuteScalar(countQuery));

            if (activePatients == 0)
            {
                MessageBox.Show(
                    "⚠️ NO ACTIVE PATIENTS TO REMOVE\n\n" +
                    "All patients in today's queue have 'Completed' status.\n\n" +
                    "Completed patients should be processed through:\n" +
                    "1. Billing tab → Create/Process Bill\n" +
                    "2. Discharge Patient button\n\n" +
                    "This ensures proper workflow and billing records.",
                    "Use Discharge Process",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"⚠️ REMOVE ALL PATIENTS FROM QUEUE?\n\n" +
                $"Active patients to remove: {activePatients}\n\n" +
                "This will:\n" +
                "✓ Remove ALL non-completed patients from today's queue\n" +
                "✓ Clear their intake data and reason for visit\n" +
                "✓ Unassign doctors from these patients\n" +
                "✗ Completed patients will NOT be affected\n\n" +
                "⚠️ THIS ACTION CANNOT BE UNDONE!\n\n" +
                "Are you absolutely sure you want to proceed?",
                "⚠️ CRITICAL: Confirm Remove All",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            DialogResult doubleConfirm = MessageBox.Show(
                "⚠️ FINAL CONFIRMATION REQUIRED\n\n" +
                $"You are about to remove {activePatients} patient(s) from the queue.\n\n" +
                "This will clear all their queue data for today.\n\n" +
                "Click YES to proceed with removal.\n" +
                "Click NO to cancel.",
                "⚠️ Final Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (doubleConfirm != DialogResult.Yes)
            {
                MessageBox.Show(
                    "✓ Operation cancelled.\n\n" +
                    "No patients were removed from the queue.",
                    "Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string getPatientNames = @"
                        SELECT u.name 
                        FROM patientqueue q
                        INNER JOIN Patients p ON q.patient_id = p.patient_id
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE q.queue_date = CURDATE()
                        AND q.status != 'Completed'";

                            List<string> removedPatients = new List<string>();
                            using (MySqlCommand cmdGetNames = new MySqlCommand(getPatientNames, conn, transaction))
                            using (MySqlDataReader reader = cmdGetNames.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    removedPatients.Add(reader["name"].ToString());
                                }
                            }

                            string deleteQuery = @"
                        DELETE FROM patientqueue 
                        WHERE queue_date = CURDATE() 
                        AND status != 'Completed'";

                            using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn, transaction))
                            {
                                int rowsAffected = cmdDelete.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();

                                    string patientList = string.Join("\n• ", removedPatients);

                                    MessageBox.Show(
                                        $"✓ QUEUE CLEARED SUCCESSFULLY\n\n" +
                                        $"Removed {rowsAffected} patient(s):\n\n• {patientList}\n\n" +
                                        "Actions completed:\n" +
                                        "✓ All non-completed patients removed\n" +
                                        "✓ Queue numbers reset\n" +
                                        "✓ Intake data cleared\n" +
                                        "✓ Doctor assignments cleared\n\n" +
                                        "Completed patients remain in billing for discharge processing.",
                                        "Queue Cleared",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    LoadData();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show(
                                        "No patients were removed.\n\n" +
                                        "All patients may have already been processed.",
                                        "No Changes",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                }
                            }
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
                    $"❌ ERROR CLEARING QUEUE\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    "The operation was rolled back.\n" +
                    "No changes were made.\n\n" +
                    "Please try again or contact support.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
            RegisterForm patientForm = RegisterForm.CreatePatientMode(currentUser.UserId, currentUser.Role);
            patientForm.FormClosed += (s, args) => LoadData();
            patientForm.ShowDialog();
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
                    using (ShowDetailedMedicalHistoryForm historyForm = new ShowDetailedMedicalHistoryForm(
                        patientId,
                        patientName,
                        recordCount,
                        visitCount,
                        currentUser.UserId,
                        currentUser.Role))
                    {
                        historyForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking medical history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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