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
    public partial class Form1 : Form 
    {
        String dbpath = "";
        String photopath = "";
        String status = "";
        CrystalReport1 ObjKartuDepan = new CrystalReport1();
        CrystalReport2 ObjKartuBelakang = new CrystalReport2();
        DataSet1 ds = new DataSet1();     
                
        public Form1()
        {
            InitializeComponent();
            textBox3.Text = status;
        }
        
        //Pilih database
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Pilih database";
            openFileDialog1.DefaultExt = "mdb";
            openFileDialog1.Filter = "Access Files (*.mdb)|*.mdb|All files (*.*)|*.*";
            DialogResult result=openFileDialog1.ShowDialog();
            if (result==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                dbpath = textBox1.Text;
            }

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbpath);
            try
            {
                String qrygrade = "Select DISTINCT grade from Msiswa";
                ds.student.Clear();
                con.Open();
                OleDbDataAdapter adapter1 = new OleDbDataAdapter(qrygrade, con);
                adapter1.Fill(ds,"student");
                int numberofgrade = ds.student.Rows.Count;
                for (int i = 0; i < numberofgrade; i++)
                {
                    comboBox1.Items.Add(ds.student.Rows[i]["GRADE"]);
                }
                textBox3.Text = "DB Con. OK\n";
                con.Close();
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch (Exception)
            {
                textBox3.Text = "DB Con. NOK\n";
            }

        }

        //CetakDepan
        private void button2_Click(object sender, EventArgs e)
        {
            dbpath = textBox1.Text;
            photopath = textBox2.Text;
            String grade = comboBox1.Text;
            String QryStd;
            crystalReportViewer1.Refresh();
            
            try
            {
                //Fill Data dari Access ke Dataset
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbpath);
                con.Open();
                ds.student.Clear();
                if (grade=="Semua")
                {
                   QryStd= "Select * from MSiswa";

                }
                else
                {
                    QryStd = "Select * from MSiswa where grade="+'"'+grade+'"';
                }
                 
                OleDbDataAdapter adapter1 = new OleDbDataAdapter(QryStd, con);
                adapter1.Fill(ds, "student");
                con.Close();

                if (ds.Tables[0].Rows.Count == 0)
                {
                    textBox3.Text = "No data\n";
                    return;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            button4.Enabled = true;

            //Load Crystalreport
            try
            {
                ObjKartuDepan.Load();
                ObjKartuDepan.SetDataSource(ds);
                crystalReportViewer1.ReportSource = ObjKartuDepan;
                textBox3.Text = "Loaded\n";
            }
            catch (Exception)
            {
                textBox3.Text = "Load Failed\n"; ;
                throw;
            }
        }
        
        //Pilih lokasi foto
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result==DialogResult.OK)
            {
                photopath = folderBrowserDialog1.SelectedPath;
                textBox2.Text = photopath;
                OleDbConnection Con1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbpath);
                try
                {
                    //Update Lokasi foto di database
                    Con1.Open();
                    String QryUpdFoto = "UPDATE MSiswa SET [PHOTO] ='" + photopath + "'";
                    OleDbCommand cmd = new OleDbCommand(QryUpdFoto, Con1);
                    cmd.ExecuteNonQuery();
                    Con1.Close();
                    textBox3.Text ="Foto Uploaded\n"; ;
                }
                catch (Exception)
                {
                    throw;
                }     
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
            try
            {
                ObjKartuBelakang.Load();
                ObjKartuBelakang.SetDataSource(ds);
                crystalReportViewer1.ReportSource = ObjKartuBelakang;
                textBox3.Text = "Loaded\n"; ;
            }
            catch (Exception)
            {
                textBox3.Text = "Load Failed\n"; 
                throw;
            }       
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    String version="";
        //    if (ApplicationDeployment.IsNetworkDeployed)
        //    {
        //        version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
        //    }
        //    MessageBox.Show("IT SBM @2018\nVersion "+version,"About");
        //}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String version = "";
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            }
            MessageBox.Show("IT SBM @2018\nVersion " + version, "About");
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 FManual = new Form2();
            FManual.Show();
        }

        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKaryawan FKaryawan = new FormKaryawan();    
            FKaryawan.Show();
        }

        private void koneksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 FKoneksi = new Form4();
            FKoneksi.Show();
        }

    }
}
