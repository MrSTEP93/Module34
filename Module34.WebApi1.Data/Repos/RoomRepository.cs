using System.Linq;
using System.Threading.Tasks;
using Module34.WebApi1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Module34.WebApi1.Data.Repos;
using System.Collections.Generic;

namespace Module34.WebApi1.Data.Repos
{
    /// <summary>
    /// Репозиторий для операций с объектами типа "Room" в базе
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly WebApi1Context _context;

        public RoomRepository(WebApi1Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Отобрать все комнаты
        /// </summary>
        /// <returns></returns>
        public async Task<Room[]> GetAllRooms()
        {
            return await _context.Rooms.ToArrayAsync();
        }

        /// <summary>
        ///  Найти комнату по имени
        /// </summary>
        public async Task<Room> GetRoomByName(string name)
        {
            return await _context.Rooms.Where(r => r.Name == name).FirstOrDefaultAsync();
        }

        /// <summary>
        ///  Добавить новую комнату
        /// </summary>
        public async Task AddRoom(Room room)
        {
            var entry = _context.Entry(room);
            if (entry.State == EntityState.Detached)
                await _context.Rooms.AddAsync(room);

            await _context.SaveChangesAsync();
        }
    }
}