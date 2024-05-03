using ApiProgram.Context;
using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProgram.Helpers
{
    public class ClassStudentGradeHelper : IClassStudentGradeHelper
    {
        private readonly CreditPortalDbContext _context;

        public ClassStudentGradeHelper(CreditPortalDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClassStudentGrade>> GetClassStudentGrades()
        {
            return await _context.ClassStudentGrades.ToListAsync();
        }
        public async Task<ClassStudentGrade> AddStudentGrade(int classStudentId, ClassStudentGrade studentGrade)
        {
            await EnsureRequiredEntitiesExist(classStudentId, studentGrade);

            _context.ClassStudentGrades.Add(studentGrade);
            await _context.SaveChangesAsync();
            return studentGrade;
        }
        private async Task<bool> EnsureRequiredEntitiesExist(int classStudentId, ClassStudentGrade studentGrade)
        {
            var classStudentData = await _context.ClassStudents.FirstOrDefaultAsync(cs  => cs.Id == classStudentId);
            if(classStudentId != studentGrade.ClassStudentId)
            {
                throw new BadHttpRequestException("The specified resource did not match the provided argument!");
            }
            if (classStudentData is null) {
                throw new InvalidOperationException("The specified class student does not exist!");
            }
            return true;
        }
    }
}
