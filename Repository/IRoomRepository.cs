using demoEFapp.Models;

namespace demoEFapp.Repositoy
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRooms();
        public void CreateNewRoom(Room room);
        public void DeleteRoom(int id);
    }
}