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
        [HttpGet("{pageNo}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudents(int pageNo, int pageSize,string? orderby )
        { 
            try
            {
                var response = _student.GetStudents(pageNo, pageSize, orderby);
                return Ok(response);
            }
            catch(Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var response = _student.GetStudentsById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }

        // POST api/<StudentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PostStudent([FromBody] StudentRequestResponse student)
        {
            try
            {
                _student.SaveStudent(student);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PutStuddent(int id, [FromBody] StudentRequestResponse student)
        {
            try
            {
                var response = _student.Updatetudent(id, student);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var response = _student.DeleteStudent(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }

        [HttpGet("search/{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SearchStudent(string key)
        {
            try
            {
                var response = _student.SearchStudent(key);
                return Ok(response);

            }
            catch (Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }

        [HttpPut("profile/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PutProfileImage(int id, [FromForm]ImageData image)
        {
            try
            {
                var response = _student.PutProfileImage(id, image);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem($"Soething went wrong: {e.Message}");
            }
            
        }
    }
}
