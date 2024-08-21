using System.Collections.Generic;
using System.Threading.Tasks;
using Module34.WebApi1.Data.Models;

namespace Module34.WebApi1.Data.Repos
{
    /// <summary>
    /// Интерфейс определяет методы для доступа к объектам типа Room в базе 
    /// </summary>
    public interface IRoomRepository
    {
        Task<Room[]> GetAllRooms();

        Task<Room> GetRoomByName(string name);

        Task AddRoom(Room room);
    }
}