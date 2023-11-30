using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using Tesseract;
using Whetstone.ChatGPT;
using Whetstone.ChatGPT.Models;

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
    [DllImport("user32.dll")]

        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const int HWND_TOPMOST = -1;


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
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


        private async void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0) //ONLY OCR
            {
                textBox5.Text = "";
                textBox5.Text = ToText();
            sendLog("Performed successful OCR scan");

            } else if (comboBox1.SelectedIndex == 1) { //OCR + GPT
                textBox5.Text = "";
                var gptRequest = new ChatGPTCompletionRequest
                    {
                        Model = ChatGPT35Models.Davinci003,
                        Prompt = $"napis velmi kratkou odpoved {ToText()}"
                    };

                try
                {
                    using IChatGPTClient client = new ChatGPTClient("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");

                    var response = await client.CreateCompletionAsync(gptRequest);
                    textBox5.Text = response?.GetCompletionText();
                    sendLog("Performed successful GPT promt");

                }
                catch (Exception ex)
                {
                    sendLog(ex.ToString());
                    Clipboard.SetText(ex.ToString());
                }
            } else if(comboBox1.SelectedIndex == 2) //GPT ONLY
            {
                var gptRequest = new ChatGPTCompletionRequest
                {
                    Model = ChatGPT35Models.Davinci003,
                    Prompt = $"napis velmi kratkou odpoved {textBox5.Text}"
                };

                try
                {
                    using IChatGPTClient client = new ChatGPTClient("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");

                    var response = await client.CreateCompletionAsync(gptRequest);
                    textBox5.Text = response?.GetCompletionText();
                    sendLog("Performed successful GPT promt");
                }
                catch (Exception ex)
                {
                    sendLog(ex.ToString());
                    Clipboard.SetText(ex.ToString());
                }
            } 
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
