using ApiProgram.Context;
using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProgram.Helpers
{
    public class TeacherHelper : ITeacherHelper
    {
        private readonly CreditPortalDbContext _context;
        public TeacherHelper (CreditPortalDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }
        public async Task<Teacher> GetTeacher(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Teacher> AddTeacher([FromBody] Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
        public async Task<Teacher> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            var teacherData = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (teacherData is not null)
            {
                _context.Entry(teacherData).CurrentValues.SetValues(teacher);
                await _context.SaveChangesAsync();
            }
            return teacherData;
        }
    }
}
