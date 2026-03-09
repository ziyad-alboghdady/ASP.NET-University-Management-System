using demoEFapp.Models;

namespace demoEFapp.Repositoy
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void CreateNewTeacher(Teacher teacher);
        public void DeleteTeacher(int id);
    }
}