
using System.Xml.Schema;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public static class DBServices
    {
        static string conStr = @"Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";

        internal static int AddStudent(Student value)
        {
            return ExcnonQRetInt(
                " INSERT INTO " +
                " TBStudents(Name, Grade) " +
                $" VALUES('{value.Name}',{value.Grade});" +
                $" SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]; ");
        }

        private static int ExcNonQ(string comm)
        {
            //string conStr = "Data Source=LAB-G700;Initial Catalog=DBUsers;User ID=sa;Password=RuppinTech!;";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(comm, con);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
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

        private static int ExcnonQRetInt(string command)
        {
            int newId = -1;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand(command, con);

            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                newId = (int)(decimal)reader[0];
            }
            comm.Connection.Close();

            return newId;
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

        internal static int UpdateStudent(Student value)
        {
            return ExcNonQ(
                $" UPDATE TBStudents " +
                $" SET Name='{value.Name}', Grade={value.Grade} " +
                $" WHERE Id={value.Id}");
        }

        internal static int DeleteStudent(int id)
        {
            return ExcNonQ(
                $" DELETE TBStudents " +
                $" WHERE Id={id}");
        }
    }
}
