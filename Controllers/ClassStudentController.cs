using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Controllers
{
    [Route("api/students/classes")]
    [ApiController]
    public class ClassStudentController : ControllerBase
    {
        private readonly IClassStudentHelper _classStudentHelper;

        public ClassStudentController(IClassStudentHelper studentHelper)
        {
            _classStudentHelper = studentHelper;
        }

        [HttpGet]
        [Route("/GetClassStudents")]
        public async Task<ActionResult<IEnumerable<ClassStudent>>> GetClassStudents()
        {
            try
            {
                var classStudents = await _classStudentHelper.GetClassStudents();
                return Ok(classStudents);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("/EnrollStudent/class/{classId}/student/{studentId}")]
        public async Task<IActionResult> EnrollStudent(int classId, int studentId, [FromBody] ClassStudent classStudent)
        {
            try
            {
                await _classStudentHelper.EnrollStudent(classId, studentId, classStudent);
                return Ok(classStudent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetClassStudent/{classStudentId}")]
        public async Task<IActionResult> GetClassStudent(int classStudentId)
        {
            try
            {
                var classStudent = await _classStudentHelper.GetClassStudent(classStudentId);
                if(classStudent is null)
                {
                    return NotFound();
                }
                return Ok(classStudent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
