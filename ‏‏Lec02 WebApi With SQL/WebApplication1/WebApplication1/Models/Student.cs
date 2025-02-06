namespace WebApplication1.Models
{
    public class Student  :Object
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }

         

        public override string ToString()
        {
            return $"{Id},{Name}, {Grade}";
        }
    }
}
