using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Interface
{
    public interface ITeacherHelper
    {
        public Task<IEnumerable<Teacher>> GetTeachers();
        public Task<Teacher> AddTeacher([FromBody] Teacher teacher);
        public Task<Teacher> GetTeacher(int id);
        public Task<Teacher> UpdateTeacher(int id, [FromBody] Teacher teacher);
    }
}
