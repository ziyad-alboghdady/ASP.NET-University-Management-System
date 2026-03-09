using demoEFapp.Context;
using demoEFapp.Models;
using demoEFapp.Repositoy;

public class TeacherRepository : ITeacherRepository
{
    private readonly MyDBContext _dbContext;

    public TeacherRepository(MyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Teacher> GetAllTeachers()
    {
        try
        {
            return _dbContext.Teachers.ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void CreateNewTeacher(Teacher teacher)
    {
        _dbContext.Teachers.Add(teacher);
        _dbContext.SaveChanges();
    }

    public void DeleteTeacher(int id)
    {
        Teacher teacher = _dbContext.Teachers
            .FirstOrDefault(x => x.Id == id);

        if (teacher != null)
        {
            _dbContext.Teachers.Remove(teacher);
            _dbContext.SaveChanges();
        }
    }
}