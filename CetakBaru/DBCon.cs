using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CetakBaru
{
    public class DBCon
    {
        public string Qry = "";
        public string dbpath = "";
        public void Connection (String Qry, String dbpath)
        {
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.Oledb.4.0;Datasource="+dbpath);
            try
            {
                Con.Open();
                System.Windows.Forms.MessageBox.Show("Db "+dbpath+" Connected");
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Connection Failed");
                throw;
            }
        }

    }
}
