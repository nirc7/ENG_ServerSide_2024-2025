using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return DBStudentsMOCK.students.ToArray();

        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student s = DBStudentsMOCK.students.FirstOrDefault(stu => stu.ID == id);
            return s;
        }
    }
}
