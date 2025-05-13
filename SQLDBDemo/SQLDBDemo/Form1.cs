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
            string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(
                " SELECT *  " +
                " FROM  TBUsers ", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lblTable.Text += reader["Id"].ToString() + ", " + reader["Name"].ToString() + ", " + reader["Family"].ToString() + "\n";
            }

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ExcNonQ($" UPDATE TBUsers " +
                $" SET Name='{txtName.Text}', Family='{txtFamily.Text}'" +
                $" WHERE Id= {txtId.Text}");
        }

        private void ExcNonQ(string comm)
        {
            string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(comm, con);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            if (res != 1)
            {
                MessageBox.Show( "Error in " + comm.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0] + " !");
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
    }
}
