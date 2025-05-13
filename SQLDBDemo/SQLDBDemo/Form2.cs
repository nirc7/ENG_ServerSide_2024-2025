using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDBDemo
{
    public partial class Form2 : Form
    {
        string strCon = @"Data Source=LAB-G700;Initial Catalog=DBUsers;Persist Security Info=True;User ID=sa;Password=RuppinTech!;";
        SqlConnection con;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adptr;

        public Form2()
        {
            InitializeComponent();

            con = new SqlConnection(strCon);
            ds = new DataSet();
        }

        private void Form2_Load(object sender, EventArgs e) { LoadDGV(); }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            adptr = new SqlDataAdapter(
                            " SELECT * " +
                            " FROM TBUsers", con);
            adptr.Fill(ds, "T1");
            dt = ds.Tables["T1"];
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();

            dr["Id"] = txtId.Text;
            dr["Name"] = txtName.Text;
            dr["Family"] = txtFamily.Text;

            dt.Rows.Add(dr);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState != DataRowState.Deleted && dt.Rows[i]["Id"].ToString() == txtId.Text)
                {
                    dt.Rows[i]["Name"] = txtName.Text;
                    dt.Rows[i]["Family"] = txtFamily.Text; 
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState != DataRowState.Deleted && dt.Rows[i]["Id"].ToString() == txtId.Text)
                {
                    dt.Rows[i].Delete();
                }
            }
        }

        private void btnUpdateSql_Click(object sender, EventArgs e)
        {
            new SqlCommandBuilder(adptr);
            adptr.Update(dt);
        }
    }
}
