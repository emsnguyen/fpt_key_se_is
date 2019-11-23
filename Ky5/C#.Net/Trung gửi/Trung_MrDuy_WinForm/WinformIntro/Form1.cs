using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinformIntro
{
    public partial class Form1 : Form
    {
        private string[] files;
        private int index;
        Thread t = null;
        private void  Log(string message)
        {
            File.WriteAllText("log.txt", String.Empty);
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(message);
            sw.Close();
        }
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Activated += Form1_Activated;
            this.Deactivate += Form1_Deactivate;
            this.FormClosing += Form1_FormClosing;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log("Form Closed");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("Form Closing");
            if (t != null)
                t.Abort();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Log("Form Deactivated");
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Log("From Activated");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log("Form Load");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Jpeg Images (*.jpeg)|*.jpeg;*.jpg|"+ 
                "Bitmap Images (*.bmp)|*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.FileNames;
                index = 0;
                if (files != null)
                {
                    pictureBox1.Image = Image.FromFile(files[0]);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (t == null && files != null)
            {
                t = new Thread(new ThreadStart(Run));
                t.Start();
            }
        }

        private void ShowPicture(string imgPath)
        {
            Image image = Image.FromFile(imgPath);
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Image img = (Image)new Bitmap(image, new Size(width, height));
            pictureBox1.Image = img;
        } 
        //thread schedule
        private void Run()
        {
            while (true)
            {
                string fileName = files[index++];
                if (index >= files.Length)
                    index = 0;
                ShowPicture(fileName);
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
