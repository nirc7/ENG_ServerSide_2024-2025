namespace WebApplication1.Models
{
    public class DBStudentsMock
    {
        public static List<Student> studnets = new List<Student>() { 
            new Student(){Id=1, Name="avi" , Grade=98 },
            new Student(){Id=3, Name="charlie" , Grade=97 },
            new Student(){Id=2, Name="benny" , Grade=99 },
            new Student(){Id=4, Name="dora" , Grade=100 },
        };
    }
}
