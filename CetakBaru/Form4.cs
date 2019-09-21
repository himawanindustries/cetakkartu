using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using System.Deployment.Application;

namespace CetakBaru
{
    public partial class Form4 : Form
    {
        public delegate void ClickButton();
        public event ClickButton ButtonWasClicked;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dbpath = textBox1.Text;
            DataSet1 ds = new DataSet1();
            Form1 FMain = new Form1();
            openFileDialog1.Title = "Pilih database";
            openFileDialog1.DefaultExt = "mdb";
            openFileDialog1.Filter = "Access Files (*.mdb)|*.mdb|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                dbpath = textBox1.Text;
                MessageBox.Show("Database Terkoneksi");
            }

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbpath);
            ButtonWasClicked();
        }
    }
}
