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
    public partial class FormKaryawan : Form
    {     
        DataSet1 ds = new DataSet1();
        String FotoPath;
        string BgKartu;

        public FormKaryawan()
        {
            
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox1.Image = null;
            crystalReportViewer1.ReportSource = null;
            ds.Clear();
            button7.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ds.Tables["karyawan"].Clear();
            String Title=comboBox1.Text;
            String Nama=textBox5.Text;
            String NIP=textBox6.Text;
            String Title2 = textBox1.Text;
            KartuKaryawan ObjKartuKaryawan = new KartuKaryawan();
            try
            {
                DataRow dr = ds.Tables["karyawan"].NewRow();
                dr["Title"] = Title;
                dr["Nama"] = Nama;
                dr["NIP"] = NIP;
                dr["Foto"] = FotoPath;
                dr["BgKartu"] = BgKartu;
                ds.Tables["karyawan"].Rows.Add(dr);
            }
            catch (Exception)
            {

                throw;
            }
            crystalReportViewer1.Refresh();
            ObjKartuKaryawan.Load();
            ObjKartuKaryawan.SetDataSource(ds);
            crystalReportViewer1.ReportSource = ObjKartuKaryawan;
            button7.Enabled = true;
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = ".jpg";
            openFileDialog1.Filter = "Image File (*.jpg)|*.jpg|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FotoPath = openFileDialog1.FileName;
            }
            pictureBox1.ImageLocation = FotoPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.ClientSize = new Size(100, 100);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ds.Tables["karyawan"].Clear();
            String Title = comboBox1.Text;
            String Nama = textBox5.Text;
            String NIP = textBox6.Text;
            String Title2 = textBox1.Text;
            KartuKaryawanBelakang ObjKartuKaryawanBelakang = new KartuKaryawanBelakang();
            try
            {
                DataRow dr = ds.Tables["karyawan"].NewRow();
                dr["Title"] = Title;
                dr["Nama"] = Nama;
                dr["NIP"] = NIP;
                dr["Foto"] = FotoPath;
                ds.Tables["karyawan"].Rows.Add(dr);
            }
            catch (Exception)
            {

                throw;
            }
            crystalReportViewer1.Refresh();
            ObjKartuKaryawanBelakang.Load();
            ObjKartuKaryawanBelakang.SetDataSource(ds);
            crystalReportViewer1.ReportSource = ObjKartuKaryawanBelakang;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="SECURITY")
            {
                textBox1.Enabled = true;    
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                textBox1.Enabled = true;
            }
        }

        private void gambarLatarKartuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "";
            openFileDialog2.FileName = "";
            openFileDialog2.DefaultExt = ".jpg";
            openFileDialog2.Filter = "Image File (*.jpg)|*.jpg|All files (*.*)|*.*";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                BgKartu = openFileDialog2.FileName;
                MessageBox.Show("Later terpilih, pastikan ukuran gambar CR-80");
            }           
        }
    }
}
