using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return DBStudentsMock.studnets.ToArray();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student stu2Find = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
            return stu2Find;
        }

        [HttpPost]
        public int Post([FromBody] Student value)
        {
            int idMax = DBStudentsMock.studnets.Max(stu => stu.Id);
            value.Id = idMax + 1;
            DBStudentsMock.studnets.Add(value);
            return idMax + 1;
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Student value)
        {
            Student stu2Update = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
            stu2Update.Name = value.Name;
            stu2Update.Grade = value.Grade;
            return "done:)";
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student stu2Del = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
            DBStudentsMock.studnets.Remove(stu2Del);
            var data = new { Result="Deleted Successfully!"};
            var jsonData = new JsonResult(data);
            return jsonData;
        }
    }
}
