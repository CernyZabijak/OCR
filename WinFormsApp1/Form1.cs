using System.ComponentModel;
using System.Drawing.Imaging;
using Tesseract;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private bool capturing = false;
        private bool capturing2 = false;
        private Point capturedPosition;
        private int x;
        private int y;
        private int width = 1;
        private int height = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = count++.ToString();
        }
        string ToText()
        {
            using (var engine = new TesseractEngine(@"./tessdata", "ces+eng", EngineMode.Default))
            {
                Bitmap capturedImage = CaptureScreenRegion(new Rectangle(x, y, width, height));
                pictureBox1.Image = capturedImage;
                string extractedText = PerformOCR(engine, capturedImage);
                return extractedText;
            }
        }

        static string PerformOCR(TesseractEngine engine, Bitmap bitmap)
        {
            using (var page = engine.Process(bitmap))
            {
                return page.GetText();
            }
        }

        static Bitmap CaptureScreenRegion(Rectangle captureRect)
        {

            Bitmap capturedBitmap = new Bitmap(captureRect.Width, captureRect.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(capturedBitmap))
            {
                g.CopyFromScreen(captureRect.Left, captureRect.Top, 0, 0, captureRect.Size);
            }

            return capturedBitmap;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = ToText();
            sendLog("Performed successful OCR scan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (capturing2)
            {
                capturing2 = false;
                label4.BackColor = Color.White;
                backgroundWorker1.CancelAsync();
            }
            if (!capturing)
            {
                capturing = true;
                label3.BackColor = Color.LimeGreen;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                sendLog("Started capturing Point1 position");
            }
            else
            {
                capturing = false;
                label3.BackColor = Color.White;
                backgroundWorker1.CancelAsync();
                sendLog("Canceled capturing Point1 position");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (capturing)
            {
                capturing = false;
                label3.BackColor = Color.White;
                backgroundWorker1.CancelAsync();
            }
            if (!capturing2)
            {
                capturing2 = true;
                label4.BackColor = Color.LimeGreen;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                sendLog("Started capturing Point2 position");
            }
            else
            {
                capturing2 = false;
                label4.BackColor = Color.White;
                backgroundWorker1.CancelAsync();
                sendLog("Canceled capturing Point2 position");
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {
                if (MouseButtons == MouseButtons.Left)
                {
                    capturedPosition = Cursor.Position;
                    backgroundWorker1.ReportProgress(0);
                    backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
                    backgroundWorker1.CancelAsync();
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (capturing)
            {
                label3.Text = $"{capturedPosition.Y};{capturedPosition.X}";
                x = capturedPosition.X;
                y = capturedPosition.Y;
                sendLog("Captured Point1");
            }
            else if (capturing2)
            {
                label4.Text = $"{capturedPosition.Y};{capturedPosition.X}";
                width = capturedPosition.X - x;
                height = capturedPosition.Y - y;
                sendLog("Captured Point2");
            }

            if (width <= 0 || height < 0)
            {
                width = 1;
                height = 1;
                MessageBox.Show("Point 1 has to be TOP LEFT corner of area, and Point 2 BOTTOM RIGHT corner.");
                sendLog("Error when creating bitmap");
            }

            capturing = false;
            capturing2 = false;
            label3.BackColor = Color.White;
            label4.BackColor = Color.White;
        }
        private void sendLog(string message)
        {
            listBox2.Items.Insert(0, $"|{DateTime.UtcNow.ToString("HH:mm:ss")}| {message}");
        }
    }
}
