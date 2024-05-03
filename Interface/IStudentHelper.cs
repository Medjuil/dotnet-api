using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Interface
{
    public interface IStudentHelper
    {
        public Task<IEnumerable<Student>> GetStudents();

        public Task<Student> AddStudent([FromBody]Student student);

        public Task<Student> GetStudent(int id);

        public Task<Student> UpdateStudent(int id,[FromBody] Student student);
    }
}
