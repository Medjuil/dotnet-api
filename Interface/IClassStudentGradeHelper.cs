using ApiProgram.Models;

namespace ApiProgram.Interface
{
    public interface IClassStudentGradeHelper
    {
        public Task<IEnumerable<ClassStudentGrade>> GetClassStudentGrades();
        public Task<ClassStudentGrade> AddStudentGrade(int classStudentId, ClassStudentGrade studentGrade);
        
    }
}
