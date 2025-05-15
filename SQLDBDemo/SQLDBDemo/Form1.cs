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
        string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
        SqlConnection con;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conStr);
            cmd = new SqlCommand();
            cmd.Connection  = con;

            RefreshTable();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExcNonQ(
                " INSERT Into TBUsers(Name, Family) " +
                " VALUES('" + txtName.Text + "','" + txtFamily.Text + "')");

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            lblTable.Text = "";
            
            cmd.CommandText = 
                " SELECT *  " +
                " FROM  TBUsers ";

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lblTable.Text += reader["Id"].ToString() + ", " + reader["Name"].ToString() + ", " + reader["Family"].ToString() + "\n";
            }

            con.Close();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ExcNonQ($" UPDATE TBUsers " +
                $" SET Name='{txtName.Text}', Family='{txtFamily.Text}'" +
                $" WHERE Id= {txtId.Text}");
        }

        private void ExcNonQ(string comm)
        {
            cmd.CommandText = comm;
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            if (res != 1)
            {
                MessageBox.Show("Error in " + comm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0] + " !");
            }
            else
                RefreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ExcNonQ(
                " DELETE TBUsers" +
                " WHERE Id = " + txtId.Text);
        }

        private void btn_SP_DS_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void btnUpdateWP_Click(object sender, EventArgs e)
        {
            cmd.CommandText = $" UPDATE TBUsers " +
                $" SET Name=@parName, Family=@parFamily" +
                $" WHERE Id=@parId";

            SqlParameter parN = new SqlParameter("@parName",txtName.Text);


            cmd.Parameters.Add(parN);
            cmd.Parameters.Add(new SqlParameter("@parFamily", txtFamily.Text));
            cmd.Parameters.Add(new SqlParameter("@parId", txtId.Text));

            cmd.Connection.Open();
            int res = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            MessageBox.Show(res.ToString());
        }
    }
}
