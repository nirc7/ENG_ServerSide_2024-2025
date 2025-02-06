
using System.Xml.Schema;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public static class DBServices
    {
        static string conStr = @"Data Source=LAB-G700;Initial Catalog=DBStudents;User ID=sa;Password=RuppinTech!;";

        internal static int AddStudent(Student value)
        {
            ExcNonQ();
        }

        private int ExcNonQ(string comm)
        {
            string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(comm, con);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            if (res != 1)
            {
                return -1;
            }
            else
                
        }

        internal static Student[] GetAllStudents()
        {
            return ExcQ(
                " SELECT * " +
                " FROM TBStudents ");
        }

        internal static Student GetStudentById(int id)
        {
            try
            {
                return ExcQ(
                    " SELECT * " +
                    " FROM TBStudents " +
                    " WHERE ID = " + id)[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Student[] ExcQ(string command)
        {
            List<Student> students = new List<Student>();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand(command, con);
            
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                students.Add(
                    new Student()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Grade = (int)reader["Grade"]
                    });
            }
            comm.Connection.Close();

            return students.ToArray();
        }
    }
}
