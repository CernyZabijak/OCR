using System.Drawing.Imaging;
using System.IO;
using System.Text.Json;
using Tesseract;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int Size;
        int Cost;
        int CostPerMeter;
        string Owner = "";
        double pH;
        int count = 0;
        const string filePath = "C:\\Users\\it-krystofstudnicka\\source\\repos\\WinFormsApp1\\WinFormsApp1\\Fields.json";

        List<Field> Fields = new List<Field>();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = count++.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { //cost per meter 
                try
                {
                    Size = Convert.ToInt32(textBox1.Text);
                    CostPerMeter = Convert.ToInt32(textBox2.Text);
                    Owner = textBox3.Text;
                    pH = Convert.ToDouble(textBox4.Text);
                    Cost = CostPerMeter * Size;
                }
                catch (Exception)
                {
                    throw;
                }
                Field field = new Field(Owner, Size, CostPerMeter, pH);
                Fields.Add(field);
                foreach (Field field2 in Fields)
                {
                    File.WriteAllText(filePath, ToString(field2));
                }
            }
        }
        public string ToString(Field field)
        {
            return $"{field.Size};{field.Cost};{field.CostPerMeter};{field.Owner};{field.pH}";
        }

        string ToText()
        {
            using (var engine = new TesseractEngine(@"./tessdata", "ces+eng", EngineMode.Default))
            {
                Bitmap capturedImage = CaptureScreenRegion(new Rectangle(100, 100, 200, 200));
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
        }
    }

}
