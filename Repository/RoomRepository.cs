using demoEFapp.Context;
using demoEFapp.Models;
using demoEFapp.Repositoy;

public class RoomRepository : IRoomRepository
{
    private readonly MyDBContext _dbContext;

    public RoomRepository(MyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Room> GetAllRooms()
    {
        try
        {
            return _dbContext.Rooms.ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void CreateNewRoom(Room room)
    {
        _dbContext.Rooms.Add(room);
        _dbContext.SaveChanges();
    }

    public void DeleteRoom(int id)
    {
        Room room = _dbContext.Rooms
            .FirstOrDefault(x => x.RoomId == id);

        if (room != null)
        {
            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
        }
    }
}