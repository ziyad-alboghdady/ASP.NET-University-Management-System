using demoEFapp.Context;
using Microsoft.EntityFrameworkCore;
using demoEFapp.Models;

namespace demoEFapp.Repositoy
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDBContext _dbContext;
        public StudentRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetAllStudents()
        {
            return _dbContext.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .ToList();
        }
        public void CreateNewStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);

            if (student == null)
                return;

            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
        public void Register(int StudentId, int CourseId)
        {
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.StudentId = StudentId;
            studentCourse.CourseId = CourseId;

            _dbContext.StudentCourses.Add(studentCourse);
            _dbContext.SaveChanges();
        }
        public Student GetStudentById(int id)
        {
            return _dbContext.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public void UpdateStudent(Student student)
        {
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
        }
    }
}
