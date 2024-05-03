using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Interface
{
    public interface IClassHelper
    {
        public Task<IEnumerable<Class>> GetClasses();
        public Task<Class> GetClass(int classId);
        public Task<Class> AddClass(int teacherId, int subjectId, [FromBody] Class classModel);
        public Task<Class> UpdateClass(int classId, int teacherId, int subjectId, [FromBody] Class classModel);
    }
}
