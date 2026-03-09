using demoEFapp.Models;

namespace demoEFapp.Repositoy
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        public void CreateNewCourse(Course course);
        public void DeleteCourse(int id);
    }
}