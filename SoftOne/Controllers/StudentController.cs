using Microsoft.AspNetCore.Mvc;
using SoftOne.Interfaces;
using SoftOne.Models;
using SoftOne.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Istudent _student;
        public StudentController(Istudent student)
        {
            _student = student;

        }
        // GET: api/<StudentController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudents(string? orderby)
        {
            var response =  _student.GetStudents(orderby);
            return Ok(response);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudentById(int id)
        {
            var response = _student.GetStudentsById(id);
            return Ok(response);
        }

        // POST api/<StudentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PostStudent([FromBody] StudentRequestResponse student)
        {
            _student.SaveStudent(student);
            return Ok();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PutStuddent(int id, [FromBody] StudentRequestResponse student)
        {
            var response = _student.Updatetudent(id, student);
            return Ok(response);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteStudent(int id)
        {
            var response = _student.DeleteStudent(id);
            return Ok(response);
        }

        [HttpGet("search/{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchStudent(string key)
        {
            var response = _student.SearchStudent( key);
            return Ok(response);
        }

        [HttpPut("profile/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PutProfileImage(int id, [FromForm]ImageData image)
        {
            var response = _student.PutProfileImage(id, image);
            return Ok(response);
        }
    }
}
