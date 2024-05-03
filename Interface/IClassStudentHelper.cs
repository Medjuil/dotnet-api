using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProgram.Interface
{
    public interface IClassStudentHelper
    {
        public Task<IEnumerable<ClassStudent>> GetClassStudents();
        public Task<ClassStudent> GetClassStudent( int classStudentId);
        public Task<ClassStudent> EnrollStudent(int classId, int studentId, [FromBody] ClassStudent classStudent);
        //public Task<ClassStudent> TransferStudent(int classId, int studentId, [FromBody] ClassStudent classStudent);
    }
}
