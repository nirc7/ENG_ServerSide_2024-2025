using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDBDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
            SqlConnection con  = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("INSERT Into TBUsers(Name, Family) VALUES('netanela','levi')",con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            if (res==1)
            {
                MessageBox.Show("successed:)");
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(
                " SELECT *  " +
                " FROM  TBUsers ", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                lblTable.Text += reader["Family"].ToString() + "\n";
            }

            con.Close();
        }
    }
}
