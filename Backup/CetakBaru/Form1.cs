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

namespace CetakBaru
{
    public partial class Form1 : Form 
    {
        String path = "";
        CrystalReport1 ObjKartuDepan = new CrystalReport1();
        CrystalReport2 ObjKartuBelakang = new CrystalReport2();
        DataSet1 ds = new DataSet1();

        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Refresh();
            textBox1.Text = openFileDialog1.FileName;
            path = textBox1.Text;
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path);
                con.Open();
                textBox3.Text = "Connected";
                String GetStudent = "Select * from student";
                
                OleDbDataAdapter adapter = new OleDbDataAdapter(GetStudent, con);
                adapter.Fill(ds, "student");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found", "Cetak Baru");
                    return;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Failed");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
            try
            {
                ObjKartuDepan.Load();
                ObjKartuDepan.SetDataSource(ds);
                crystalReportViewer1.ReportSource = ObjKartuDepan;
            }
            catch (Exception)
            {
                MessageBox.Show("Load Report Failed");
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string photopath;
            folderBrowserDialog1.ShowDialog();
            photopath=folderBrowserDialog1.SelectedPath;
            textBox2.Text = photopath;
            folderBrowserDialog1.ShowNewFolderButton = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
            try
            {
                ObjKartuBelakang.Load();
                ObjKartuBelakang.SetDataSource(ds);
                crystalReportViewer1.ReportSource = ObjKartuBelakang;
            }
            catch (Exception)
            {
                MessageBox.Show("Load Report Failed");
                throw;
            }       
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
