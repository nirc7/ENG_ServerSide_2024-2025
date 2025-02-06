using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsRWController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student[]> Get()
        {
            try
            {
                //throw new InvalidOperationException("go 2 school and respect your teacher!");
                return Ok(DBStudentsMock.studnets.ToArray());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                Student stu2Return = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
                if (stu2Return == null)
                {
                    return NotFound($"student with id = {id} was not found in the Get by Id action!");
                }
                return Ok(stu2Return);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Get(string name)
        //{
        //    try
        //    {
        //        Student stu2Return = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Name == name);
        //        if (stu2Return == null)
        //        {
        //            return NotFound($"student with id = {name} was not found in the Get by Id action!");
        //        }
        //        return Ok(stu2Return);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpGet("{isAvi:bool}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(bool isAvi    )
        {
            try
            {
                if (isAvi)
                {


                    Student stu2Return = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Name == "avi");
                    if (stu2Return == null)
                    {
                        return NotFound($"student with name avi was not found in the Get by Avi action!");
                    }
                    return Ok(stu2Return);
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        //[Route("/api/StudentsRW/{id}/grade")]
        [Route("{id}/grade")]
        [Route("~/grade/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGrade(int id)
        {
            try
            {
                Student stu2Return = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
                if (stu2Return == null)
                {
                    return NotFound($"student with id = {id} was not found in the Get Grade by Id action!");
                }
                return Ok(stu2Return.Grade);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Student value)
        {
            try
            {
                if (value == null)
                    return BadRequest();
                else if (value.Id != 0)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                value.Id = DBStudentsMock.studnets.Max(stu => stu.Id) + 1;
                DBStudentsMock.studnets.Add(value);

                //return Created();
                //return StatusCode(StatusCodes.Status201Created, value.Id);
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //???
        //[HttpPost]
        //[Route("~/post2")]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Student))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult Post2([FromBody] Student value, [FromBody] int id)
        //{
        //    try
        //    {
        //        if (value == null)
        //            return BadRequest();
        //        else if (value.Id != 0)
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //        value.Id = DBStudentsMock.studnets.Max(stu => stu.Id) + 1;
        //        DBStudentsMock.studnets.Add(value);

        //        //return Created();
        //        //return StatusCode(StatusCodes.Status201Created, value.Id);
        //        return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            try
            {
                if (value == null || id != value.Id)
                    return BadRequest();

                Student stu2Update = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
                if (stu2Update == null)
                {
                    return NotFound($"student with id = {id} was not found in the Update by Id action!");
                }
                stu2Update.Name = value.Name;
                stu2Update.Grade = value.Grade;
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                Student stu2Del = DBStudentsMock.studnets.FirstOrDefault(stu => stu.Id == id);
                if (stu2Del == null)
                {
                    return NotFound($"student with id = {id} was not found in the Delete by Id action!");
                }
                DBStudentsMock.studnets.Remove(stu2Del);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

