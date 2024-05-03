using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassHelper _classHelper;

        public ClassController(IClassHelper classHelper)
        {
            this._classHelper = classHelper;
        }

        [HttpGet]
        [Route("/GetClasses")]
        public async Task<IEnumerable<Class>> GetClasses()
        {
            return await _classHelper.GetClasses();
        }

        [HttpPost]
        [Route("/AddClass/teacher{teacherId}/subject/{subjectId}")]
        public async Task<IActionResult> AddClass(int teacherId, int subjectId, [FromBody] Class classModel)
        {
            try
            {
                await _classHelper.AddClass(teacherId, subjectId, classModel);
                return Ok(classModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("/GetClass/{classId}")]
        public async Task<IActionResult> GetClass(int classId)
        {
            var classData = await _classHelper.GetClass(classId);
            if(classData is null)
            {
                return NotFound();
            }
            return Ok(classData);

        }

        [HttpPut]
        [Route("/UpdateClass/teacher/{teacherId}/subject/{subjectId}")]
        public async Task<IActionResult> UpdateClass(int classId, int teacherId, int subjectId, [FromBody] Class classModel)
        {
            try
            {
                if (classId != classModel.Id)
                {
                    return BadRequest();
                }
                await _classHelper.UpdateClass(classId, teacherId, subjectId, classModel);
                return Ok(classModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
