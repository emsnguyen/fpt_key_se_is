using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        bool onLockMode = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "SE05583";
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.Color = txtColor.BackColor;
            cd.ShowHelp = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                txtColor.BackColor = cd.Color;
            }
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!onLockMode)
            {
                onLockMode = true;
            }
            else
            {
                onLockMode = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Text = txtLabel?.Text;
            b.BackColor = txtColor.BackColor;
            b.Location = p;
            panel.Controls.Add(b);

        }
        Point p;
        private void panel_Click(object sender, EventArgs e)
        {
            if (onLockMode)
            {
                Point point = panel.PointToClient(Cursor.Position);
                txtX.Text = point.X.ToString();
                txtY.Text = point.Y.ToString();
                p = new Point(point.X, point.Y);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel_Click(sender, e);
        }
    }
}
