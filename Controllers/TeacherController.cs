using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherHelper _teacherHelper;

        public TeacherController(ITeacherHelper teacherHelper)
        {
            this._teacherHelper = teacherHelper;
        }

        [HttpGet]
        [Route("/GetTeachers")]
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _teacherHelper.GetTeachers();
        }

        [HttpPost]
        [Route("/GetTeacher/{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _teacherHelper.GetTeacher(id);
            if(teacher is null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Route("/AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                await _teacherHelper.AddTeacher(teacher);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("/UpdateTeacher/{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if(id != teacher.Id)
            {
                return BadRequest();
            }
            try
            {
                var teacherData = await _teacherHelper.UpdateTeacher(id, teacher);
                if (teacherData == null)
                {
                    return BadRequest();
                }
                return Ok(teacherData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
