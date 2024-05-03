using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Interface
{
    public interface ISubjectHelper
    {
        public Task<IEnumerable<Subject>> GetSubjects();
        public Task<Subject> GetSubject(int id);
        public Task<Subject> AddSubject([FromBody] Subject subject);
        public Task<Subject> UpdateSubject(int id, [FromBody] Subject subject);

    }
}
