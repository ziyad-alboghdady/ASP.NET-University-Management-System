using demoEFapp.Models;

namespace demoEFapp.Repositoy
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void CreateNewStudent(Student student);
        public void DeleteStudent(int id);
        public void Register(int StudentId,int CourseId);
        Student GetStudentById(int id);
        void UpdateStudent(Student student);

    }
}
