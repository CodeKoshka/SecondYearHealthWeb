using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ImageCropperForm : Form
    {
        private Image originalImage;
        private Rectangle cropRectangle;
        private Point startPoint;
        private Point startCropLocation;
        private Size startCropSize;
        private bool isMoving = false;
        private bool isResizing = false;
        private ResizeCorner resizeCorner = ResizeCorner.None;
        private const int MIN_CROP_SIZE = 50;
        private const int HANDLE_SIZE = 20;
        private const int HANDLE_HIT_AREA = 30;

        public Image CroppedImage { get; private set; }

        private enum ResizeCorner
        {
            None,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }

        public ImageCropperForm(Image image)
        {
            originalImage = image;
            InitializeComponent();

            int minDimension = Math.Min(originalImage.Width, originalImage.Height);

            if (minDimension <= 300)
            {
                cropRectangle = new Rectangle(0, 0, originalImage.Width, originalImage.Height);
            }
            else
            {
                int size = minDimension / 2;
                int x = (originalImage.Width - size) / 2;
                int y = (originalImage.Height - size) / 2;
                cropRectangle = new Rectangle(x, y, size, size);
            }

            pictureBoxCrop.Image = originalImage;
            pictureBoxCrop.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void PictureBoxCrop_Paint(object sender, PaintEventArgs e)
        {
            if (originalImage == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle displayCrop = ConvertToDisplayCoordinates(cropRectangle);

            using (SolidBrush dimBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)))
            {
                Region region = new Region(pictureBoxCrop.ClientRectangle);
                region.Exclude(displayCrop);
                e.Graphics.FillRegion(dimBrush, region);
            }

            using (Pen pen = new Pen(Color.White, 2))
            {
                e.Graphics.DrawRectangle(pen, displayCrop);
            }

            using (Pen gridPen = new Pen(Color.FromArgb(100, 255, 255, 255), 1))
            {
                int third = displayCrop.Width / 3;
                e.Graphics.DrawLine(gridPen, displayCrop.X + third, displayCrop.Y,
                    displayCrop.X + third, displayCrop.Bottom);
                e.Graphics.DrawLine(gridPen, displayCrop.X + third * 2, displayCrop.Y,
                    displayCrop.X + third * 2, displayCrop.Bottom);

                third = displayCrop.Height / 3;
                e.Graphics.DrawLine(gridPen, displayCrop.X, displayCrop.Y + third,
                    displayCrop.Right, displayCrop.Y + third);
                e.Graphics.DrawLine(gridPen, displayCrop.X, displayCrop.Y + third * 2,
                    displayCrop.Right, displayCrop.Y + third * 2);
            }

            DrawHandle(e.Graphics, displayCrop.Left, displayCrop.Top);
            DrawHandle(e.Graphics, displayCrop.Right, displayCrop.Top);
            DrawHandle(e.Graphics, displayCrop.Left, displayCrop.Bottom);
            DrawHandle(e.Graphics, displayCrop.Right, displayCrop.Bottom);
        }

        private void DrawHandle(Graphics g, int x, int y)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
            {
                Rectangle handle = new Rectangle(x - HANDLE_SIZE / 2, y - HANDLE_SIZE / 2, HANDLE_SIZE, HANDLE_SIZE);
                g.FillRectangle(brush, handle);

                using (Pen pen = new Pen(Color.FromArgb(0, 102, 204), 2))
                {
                    g.DrawRectangle(pen, handle);
                }
            }
        }
        private Rectangle GetImageBounds()
        {
            if (pictureBoxCrop.Image == null) return Rectangle.Empty;

            int containerWidth = pictureBoxCrop.Width;
            int containerHeight = pictureBoxCrop.Height;
            int imageWidth = pictureBoxCrop.Image.Width;
            int imageHeight = pictureBoxCrop.Image.Height;

            float imageRatio = (float)imageWidth / imageHeight;
            float containerRatio = (float)containerWidth / containerHeight;

            int displayWidth, displayHeight, x, y;

            if (imageRatio > containerRatio)
            {
                displayWidth = containerWidth;
                displayHeight = (int)(containerWidth / imageRatio);
                x = 0;
                y = (containerHeight - displayHeight) / 2;
            }
            else
            {
                displayHeight = containerHeight;
                displayWidth = (int)(containerHeight * imageRatio);
                x = (containerWidth - displayWidth) / 2;
                y = 0;
            }

            return new Rectangle(x, y, displayWidth, displayHeight);
        }

        private Rectangle ConvertToDisplayCoordinates(Rectangle imageRect)
        {
            Rectangle bounds = GetImageBounds();
            if (bounds.Width == 0 || bounds.Height == 0) return Rectangle.Empty;

            float scaleX = (float)bounds.Width / originalImage.Width;
            float scaleY = (float)bounds.Height / originalImage.Height;

            return new Rectangle(
                bounds.X + (int)(imageRect.X * scaleX),
                bounds.Y + (int)(imageRect.Y * scaleY),
                (int)(imageRect.Width * scaleX),
                (int)(imageRect.Height * scaleY)
            );
        }

        private ResizeCorner GetCornerAtPoint(Point p, Rectangle displayCrop)
        {
            int tolerance = HANDLE_HIT_AREA;

            if (IsNearPoint(p, new Point(displayCrop.Left, displayCrop.Top), tolerance))
                return ResizeCorner.TopLeft;
            if (IsNearPoint(p, new Point(displayCrop.Right, displayCrop.Top), tolerance))
                return ResizeCorner.TopRight;
            if (IsNearPoint(p, new Point(displayCrop.Left, displayCrop.Bottom), tolerance))
                return ResizeCorner.BottomLeft;
            if (IsNearPoint(p, new Point(displayCrop.Right, displayCrop.Bottom), tolerance))
                return ResizeCorner.BottomRight;

            return ResizeCorner.None;
        }

        private bool IsNearPoint(Point p1, Point p2, int tolerance)
        {
            return Math.Abs(p1.X - p2.X) <= tolerance && Math.Abs(p1.Y - p2.Y) <= tolerance;
        }

        private void PictureBoxCrop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Rectangle displayCrop = ConvertToDisplayCoordinates(cropRectangle);
            resizeCorner = GetCornerAtPoint(e.Location, displayCrop);

            if (resizeCorner != ResizeCorner.None)
            {
                isResizing = true;
                startPoint = e.Location;
                startCropLocation = cropRectangle.Location;
                startCropSize = cropRectangle.Size;
            }
            else if (displayCrop.Contains(e.Location))
            {
                isMoving = true;
                startPoint = e.Location;
                startCropLocation = cropRectangle.Location;
            }
        }

        private void PictureBoxCrop_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle displayCrop = ConvertToDisplayCoordinates(cropRectangle);
            Rectangle bounds = GetImageBounds();

            if (!isMoving && !isResizing)
            {
                ResizeCorner corner = GetCornerAtPoint(e.Location, displayCrop);

                if (corner == ResizeCorner.TopLeft || corner == ResizeCorner.BottomRight)
                    pictureBoxCrop.Cursor = Cursors.SizeNWSE;
                else if (corner == ResizeCorner.TopRight || corner == ResizeCorner.BottomLeft)
                    pictureBoxCrop.Cursor = Cursors.SizeNESW;
                else if (displayCrop.Contains(e.Location))
                    pictureBoxCrop.Cursor = Cursors.SizeAll;
                else
                    pictureBoxCrop.Cursor = Cursors.Default;

                return;
            }

            if (isMoving)
            {
                int deltaX = e.X - startPoint.X;
                int deltaY = e.Y - startPoint.Y;

                float scaleX = (float)originalImage.Width / bounds.Width;
                float scaleY = (float)originalImage.Height / bounds.Height;

                int imageDeltaX = (int)(deltaX * scaleX);
                int imageDeltaY = (int)(deltaY * scaleY);

                int newX = startCropLocation.X + imageDeltaX;
                int newY = startCropLocation.Y + imageDeltaY;

                newX = Math.Max(0, Math.Min(newX, originalImage.Width - cropRectangle.Width));
                newY = Math.Max(0, Math.Min(newY, originalImage.Height - cropRectangle.Height));

                cropRectangle.X = newX;
                cropRectangle.Y = newY;
                pictureBoxCrop.Invalidate();
            }
            else if (isResizing)
            {
                float scale = (float)originalImage.Width / bounds.Width;

                int deltaX = (int)((e.X - startPoint.X) * scale);
                int deltaY = (int)((e.Y - startPoint.Y) * scale);

                int newX = startCropLocation.X;
                int newY = startCropLocation.Y;
                int newSize = startCropSize.Width;

                switch (resizeCorner)
                {
                    case ResizeCorner.TopLeft:
                        newX = startCropLocation.X + deltaX;
                        newY = startCropLocation.Y + deltaY;
                        newSize = startCropSize.Width - Math.Max(deltaX, deltaY);
                        break;

                    case ResizeCorner.TopRight:
                        newY = startCropLocation.Y + deltaY;
                        newSize = startCropSize.Width + Math.Max(deltaX, -deltaY);
                        break;

                    case ResizeCorner.BottomLeft:
                        newX = startCropLocation.X + deltaX;
                        newSize = startCropSize.Width + Math.Max(-deltaX, deltaY);
                        break;

                    case ResizeCorner.BottomRight:
                        newSize = startCropSize.Width + Math.Max(deltaX, deltaY);
                        break;
                }

                if (newSize < MIN_CROP_SIZE)
                {
                    newSize = MIN_CROP_SIZE;

                    switch (resizeCorner)
                    {
                        case ResizeCorner.TopLeft:
                            newX = startCropLocation.X + (startCropSize.Width - MIN_CROP_SIZE);
                            newY = startCropLocation.Y + (startCropSize.Height - MIN_CROP_SIZE);
                            break;
                        case ResizeCorner.TopRight:
                            newY = startCropLocation.Y + (startCropSize.Height - MIN_CROP_SIZE);
                            break;
                        case ResizeCorner.BottomLeft:
                            newX = startCropLocation.X + (startCropSize.Width - MIN_CROP_SIZE);
                            break;
                    }
                }

                newSize = Math.Min(newSize, originalImage.Width);
                newSize = Math.Min(newSize, originalImage.Height);

                newX = Math.Max(0, Math.Min(newX, originalImage.Width - newSize));
                newY = Math.Max(0, Math.Min(newY, originalImage.Height - newSize));

                cropRectangle = new Rectangle(newX, newY, newSize, newSize);
                pictureBoxCrop.Invalidate();
            }
        }

        private void PictureBoxCrop_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
            isResizing = false;
            resizeCorner = ResizeCorner.None;
            pictureBoxCrop.Cursor = Cursors.Default;
        }
        private void BtnCrop_Click(object sender, EventArgs e)
        {
            try
            {
                if (cropRectangle.Width < MIN_CROP_SIZE || cropRectangle.Height < MIN_CROP_SIZE)
                {
                    MessageBox.Show("Please select a larger area to crop.", "Invalid Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int targetSize = 300;

                if (originalImage.Width == targetSize && originalImage.Height == targetSize)
                {
                    CroppedImage = new Bitmap(originalImage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                cropRectangle.X = Math.Max(0, Math.Min(cropRectangle.X, originalImage.Width - cropRectangle.Width));
                cropRectangle.Y = Math.Max(0, Math.Min(cropRectangle.Y, originalImage.Height - cropRectangle.Height));
                cropRectangle.Width = Math.Min(cropRectangle.Width, originalImage.Width - cropRectangle.X);
                cropRectangle.Height = Math.Min(cropRectangle.Height, originalImage.Height - cropRectangle.Y);
                if (cropRectangle.Width == originalImage.Width && cropRectangle.Height == originalImage.Height)
                {
                    CroppedImage = new Bitmap(originalImage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                using (Bitmap croppedBitmap = new Bitmap(cropRectangle.Width, cropRectangle.Height))
                {
                    using (Graphics g = Graphics.FromImage(croppedBitmap))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(originalImage,
                            new Rectangle(0, 0, cropRectangle.Width, cropRectangle.Height),
                            cropRectangle,
                            GraphicsUnit.Pixel);
                    }

                    if (croppedBitmap.Width == targetSize && croppedBitmap.Height == targetSize)
                    {
                        CroppedImage = new Bitmap(croppedBitmap);
                    }
                    else
                    {
                        CroppedImage = new Bitmap(targetSize, targetSize);
                        using (Graphics g = Graphics.FromImage(CroppedImage))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.DrawImage(croppedBitmap, 0, 0, targetSize, targetSize);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cropping image: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}