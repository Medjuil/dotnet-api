using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectHelper _subjectHelper;

        public SubjectController(ISubjectHelper subjectHelper)
        {
            this._subjectHelper = subjectHelper;
        }

        [HttpGet]
        [Route("/GetSubjects")]
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _subjectHelper.GetSubjects();
        }

        [HttpGet]
        [Route("/GetSubject/{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var subject = await _subjectHelper.GetSubject(id);
            if(subject is null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        [Route("/AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
         {
            try
            {
                await _subjectHelper.AddSubject(subject);
                return Ok(subject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("/UpdateSubject/{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] Subject subject)
        {
            if(id != subject.Id)
            {
                return BadRequest();
            }

            try
            {
                await _subjectHelper.UpdateSubject(id, subject);
                return Ok(subject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
