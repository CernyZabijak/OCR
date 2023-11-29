namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            button2 = new Button();
            textBox5 = new TextBox();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            log = new Label();
            listBox2 = new ListBox();
            button1 = new Button();
            button3 = new Button();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 9);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 2;
            label2.Text = "Up Time";
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(5, 531);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(95, 177);
            button2.TabIndex = 14;
            button2.Text = "START";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            textBox5.BackColor = Color.Silver;
            textBox5.Location = new Point(106, 531);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.RightToLeft = RightToLeft.No;
            textBox5.Size = new Size(758, 177);
            textBox5.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(106, 12);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1195, 511);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // label1
            // 
            label1.BackColor = Color.Gray;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(14, 29);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 1;
            label1.Text = "0";
            // 
            // log
            // 
            log.Location = new Point(870, 527);
            log.Name = "log";
            log.Size = new Size(40, 34);
            log.TabIndex = 17;
            log.Text = "Logs";
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox2.BackColor = Color.Silver;
            listBox2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 18;
            listBox2.Location = new Point(870, 544);
            listBox2.Name = "listBox2";
            listBox2.RightToLeft = RightToLeft.No;
            listBox2.Size = new Size(431, 148);
            listBox2.TabIndex = 19;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.Location = new Point(5, 211);
            button1.Name = "button1";
            button1.Size = new Size(97, 58);
            button1.TabIndex = 20;
            button1.Text = "Point 1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gray;
            button3.Location = new Point(5, 310);
            button3.Name = "button3";
            button3.Size = new Size(97, 58);
            button3.TabIndex = 21;
            button3.Text = "Point 2";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Silver;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(5, 173);
            label3.Name = "label3";
            label3.Size = new Size(97, 35);
            label3.TabIndex = 22;
            label3.Text = "0;0";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Silver;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(5, 272);
            label4.Name = "label4";
            label4.Size = new Size(97, 35);
            label4.TabIndex = 23;
            label4.Text = "0;0";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "OCR ONLY", "OCR+GPT", "GPT ONLY" });
            comboBox1.Location = new Point(5, 374);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(95, 28);
            comboBox1.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1313, 713);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(listBox2);
            Controls.Add(log);
            Controls.Add(pictureBox1);
            Controls.Add(textBox5);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            Text = "v1.2";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private Button button2;
        private TextBox textBox5;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private Label log;
        private ListBox listBox2;
        private Button button1;
        private Button button3;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
    }
}