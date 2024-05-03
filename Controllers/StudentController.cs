using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentHelper _studentHelper;

        public StudentController(IStudentHelper studentHelper)
        {
            _studentHelper = studentHelper;
        }

        [HttpGet]
        [Route("/GetStudents")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentHelper.GetStudents();
        }

        [HttpGet]
        [Route("/GetStudent/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentHelper.GetStudent(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [Route("/AddStudent")]
        public async Task<ActionResult<Student>> AddStudent([FromBody]Student student) {
            try
            {
                await _studentHelper.AddStudent(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("/UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody]Student student)
        {
            if (id != student.Id) return BadRequest();
            try
            {
                var studentData = await _studentHelper.UpdateStudent(id, student);
                if (studentData is null) return BadRequest();
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
