using ApiProgram.Context;
using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiProgram.Helpers
{
    public class StudentHelper : IStudentHelper
    {
        private readonly CreditPortalDbContext _context;
        public StudentHelper(CreditPortalDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Student> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateStudent(int id, [FromBody] Student student)
        {
            var studentData = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (studentData is not null)
            {
                _context.Entry(studentData).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();
            }
            return studentData;
        }
    }
}
