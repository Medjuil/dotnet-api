using ApiProgram.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProgram.Context
{
    public class CreditPortalDbContext : DbContext
    {
        public CreditPortalDbContext(DbContextOptions<CreditPortalDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassStudent> ClassStudents { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassStudentGrade> ClassStudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One - Many relationships between Student and ClassStudent
            modelBuilder.Entity<Student>()
                .HasMany(s => s.ClassStudents)
                .WithOne(cs => cs.Student)
                .HasForeignKey(cs => cs.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            // One - Many relationships between Teacher and Class
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Classes)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            // One - Many relationships between Subject and Class
            modelBuilder.Entity<Subject>()
                .HasMany(sub => sub.Classes)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
            // One - Many relationships between Class and ClassStudent
            modelBuilder.Entity<Class>()
                .HasMany(c => c.ClassStudents)
                .WithOne(cs => cs.Class)
                .HasForeignKey(cs => cs.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
            // One - Many relationships between ClassStudent and ClassStudentGrades
            modelBuilder.Entity<ClassStudent>()
                .HasMany(cs => cs.ClassStudentGrades)
                .WithOne(csg => csg.ClassStudent)
                .HasForeignKey(csg => csg.ClassStudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
