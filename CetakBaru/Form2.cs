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
    public partial class Form2 : Form
    {
        String PhotoPath;
        DataSet1 ds = new DataSet1();
        CrystalReport2 cr2 = new CrystalReport2();
        CrystalReport3 cr3 = new CrystalReport3();

        public Form2()
        {
            InitializeComponent();
        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.DefaultExt = ".jpg";
            openFileDialog1.Filter = "Image File (*.jpg)|*.jpg|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                PhotoPath = openFileDialog1.FileName;
            }
            pictureBox1.ImageLocation = PhotoPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ds.Tables["student"].Clear();
            String Nama = textBox4.Text;
            String ID = textBox5.Text;
            String NISN = textBox2.Text;
            String Gender = comboBox1.Text;
            String BirthCity = textBox6.Text;
            String DOB = textBox7.Text;
            String Address = textBox3.Text;
            String City = textBox9.Text;          
            String Address1 = textBox3.Text;
            String Phone = textBox1.Text;


            try
            {
                DataRow dr = ds.Tables["student"].NewRow();
                dr["STID"] = ID;
                dr["IDNO"] = NISN;
                dr["GIVNAME"] = Nama;
                dr["SEXID"] = Gender;
                dr["BIRTHCITY"] = BirthCity;
                dr["BIRTHDAY"] = DOB;
                dr["Address1"] = Address1;
                dr["Address2"] = City;
                dr["Phone"] = Phone;
                dr["Photo"] = PhotoPath;
                ds.Tables["student"].Rows.Add(dr);
            }
            catch (Exception)
            {
                throw;
            }
            crystalReportViewer1.Refresh();
            cr3.Load();
            cr3.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr3;
            button7.Enabled=true;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
            cr2.Load();
            cr2.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = -1;
            pictureBox1.Image = null;
            ds.Clear();
            crystalReportViewer1.ReportSource = null;
        }
    }
}
