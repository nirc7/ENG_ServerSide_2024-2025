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
        SqlCommand cmd;

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
            ds.Tables.Clear();
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

        private void btnSelectFWSP_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SearchUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parId = new SqlParameter("@MyID", txtId.Text);
            parId.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parId);

            SqlParameter parF = new SqlParameter("@FamilyName",SqlDbType.NVarChar, 20);
            parF.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parF);

            SqlParameter parRet = new SqlParameter();
            parRet.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(parRet);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            if ((int)parRet.Value == 0)
            {
                MessageBox.Show(parF.Value.ToString());
            }
            else
                MessageBox.Show(":(" + (int)parRet.Value);
        }

        private void btnTableWSP_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SearchUserTable", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //opt1
            cmd.Parameters.Add(new SqlParameter("@MyID", txtId.Text));

            //opt2
            //SqlParameter parId = new SqlParameter("@MyID", txtId.Text);
            //parId.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(parId);

            SqlDataAdapter adptr2 = new SqlDataAdapter(cmd);

            ds.Tables.Clear();
            adptr2.Fill(ds, "T2");
            dataGridView1.DataSource = ds.Tables["T2"]; 
        }
    }
}
