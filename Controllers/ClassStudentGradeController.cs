using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Controllers
{
    [Route("api/studentes/classes/grades")]
    [ApiController]
    public class ClassStudentGradeController : ControllerBase
    {
        private readonly IClassStudentGradeHelper _studentGradeHelper;
        public ClassStudentGradeController(IClassStudentGradeHelper classStudentGradeHelper) { 
            this._studentGradeHelper = classStudentGradeHelper;
        }
        [HttpGet]
        [Route("/GetStudentsGrades")]
        public async Task<ActionResult<IEnumerable<ClassStudentGrade>>> GetClassStudentGrades()
        {
            var studentGrades = await _studentGradeHelper.GetClassStudentGrades();
            return Ok(studentGrades);
        }

        [HttpPost]
        [Route("/AddStudentGrade/{classStudentId}")]
        public async Task<IActionResult> AddStudentGrade(int classStudentId, ClassStudentGrade studentGrade)
        {
            try
            {
                var studentGrades = await _studentGradeHelper.AddStudentGrade(classStudentId, studentGrade);
                if(studentGrades is null) {
                    return BadRequest();
                }
                return Ok(studentGrades);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
