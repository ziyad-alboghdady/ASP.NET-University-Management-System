using demoEFapp.Context;
using demoEFapp.Models;
using demoEFapp.Repositoy;

public class CourseRepository : ICourseRepository
{
    private readonly MyDBContext _dbContext;

    public CourseRepository(MyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Course> GetAllCourses()
    {
        try
        {
            return _dbContext.Courses.ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void CreateNewCourse(Course course)
    {
        _dbContext.Courses.Add(course);
        _dbContext.SaveChanges();
    }

    public void DeleteCourse(int id)
    {
        Course course = _dbContext.Courses
            .FirstOrDefault(x => x.CourseId == id);

        if (course != null)
        {
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();
        }
    }
}