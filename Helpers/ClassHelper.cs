using ApiProgram.Context;
using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProgram.Helpers
{
    public class ClassHelper : IClassHelper
    {
        private readonly CreditPortalDbContext _context;
        public ClassHelper(CreditPortalDbContext creditPortalDbContext)
        {
            this._context = creditPortalDbContext;
        }
        public async Task<IEnumerable<Class>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }
        public async Task<Class> AddClass(int teacherId, int subjectId, [FromBody] Class classModel)
        {
            await EnsureRequiredEntitiesExists(teacherId, subjectId);
            _context.Classes.Add(classModel);
            await _context.SaveChangesAsync();
            return classModel;
        }
        public async Task<Class> GetClass(int classId)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.Id == classId);
        }

        public async Task<Class> UpdateClass(int classId, int teacherId, int subjectId, [FromBody] Class classModel)
        {
            await EnsureRequiredEntitiesExists(teacherId, subjectId);

            var classData = await _context.Classes.FirstOrDefaultAsync(c => c.Id == classId);
            if (classData is not null)
            {
                _context.Entry(classData).CurrentValues.SetValues(classModel);
                await _context.SaveChangesAsync();
            }
            return classData;
        }

        public async Task<bool> EnsureRequiredEntitiesExists(int teacherId, int subjectId) {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);
            var subject = await _context.Subjects.FirstOrDefaultAsync(t => t.Id == subjectId);
            if (teacher is null || subject is null)
            {
                throw new InvalidOperationException("The specified teacher or subject does not exist!");
            }
            return true;
        }
    }
}
