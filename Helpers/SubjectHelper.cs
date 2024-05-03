using ApiProgram.Context;
using ApiProgram.Interface;
using ApiProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProgram.Helpers
{
    public class SubjectHelper : ISubjectHelper
    {
        private readonly CreditPortalDbContext _context;

        public SubjectHelper(CreditPortalDbContext creditPortalDbContext)
        {
            this._context = creditPortalDbContext;
        }
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<Subject> GetSubject(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Subject> AddSubject([FromBody] Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
        public async Task<Subject> UpdateSubject(int id, [FromBody] Subject subject)
        {
            var subjectData = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
            if(subjectData is not null)
            {
                _context.Entry(subjectData).CurrentValues.SetValues(subject);
                await _context.SaveChangesAsync();
            }
            return subjectData;
        }
    }
}
