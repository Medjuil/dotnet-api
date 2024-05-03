using ApiProgram.Context;
using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProgram.Helpers
{
    public class ClassStudentHelper : IClassStudentHelper
    {
        private readonly CreditPortalDbContext _context;

        public ClassStudentHelper(CreditPortalDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClassStudent>> GetClassStudents()
        {
            return await _context.ClassStudents.ToListAsync()           ;
        }

        public async Task<ClassStudent> EnrollStudent(int classId, int studentId, [FromBody] ClassStudent classStudent)
        {
            await this.EnsureRequiredEntitiesExist(classId, studentId);

            _context.ClassStudents.Add(classStudent);
            await _context.SaveChangesAsync();
            return classStudent;
        }
        public async Task<ClassStudent> GetClassStudent(int classStudentId)
        {
            return await _context.ClassStudents.Include( e => e.ClassStudentGrades).AsSplitQuery().FirstOrDefaultAsync(cs => cs.Id == classStudentId);
        }

       /* public async Task<ClassStudent> TransferStudent(int classId, int studentId, [FromBody] ClassStudent classStudent)
        {
            // Ensure that the required entities exist in the database
            await EnsureRequiredEntitiesExist(classId, studentId);
            // Ensure that student will not be transferred to the same class
            if(await _context.ClassStudents.Any(e => e))
            {

            }


        }*/
        private async Task<bool> EnsureRequiredEntitiesExist(int classId, int studentId)
        {
            var classData = await _context.Classes.FirstOrDefaultAsync(c => c.Id == classId);
            var studentData = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            if (classData is null || studentData is null)
            {
                throw new ArgumentException("The specified class or student does not exist!");
            }
            return true;
        }

    }
}
