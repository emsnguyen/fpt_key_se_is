using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button b;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "SE05583";
            if (b != null)
            {
                Color c = b.BackColor;
                string msg = $"Label: {b.Text} \r\nColor:RGB({c.R},{c.G},{c.B})";
                MessageBox.Show(msg);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;//keeps user from selecting a custom color
            cd.ShowHelp = true;
            cd.Color = txtColor.ForeColor;
            //update the textbox color if user clicks OK
            if (cd.ShowDialog() == DialogResult.OK)
            {
                txtColor.BackColor = cd.Color;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            b = new Button();
            b.Text = txtLabel.Text;
            b.BackColor = txtColor.BackColor;
            panel.Controls.Add(b);
        }
    }
}
