using System.Linq;
using System.Threading.Tasks;
using Module34.WebApi1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Module34.WebApi1.Data.Repos;
using System.Collections.Generic;
using Module34.WebApi1.Data.Queries;
using System;
using System.Threading;

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
        ///  Найти комнату по ИД
        /// </summary>
        public async Task<Room> GetRoomById(Guid id)
        {
            return await _context.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
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

        public async Task UpdateRoom(UpdateRoomQuery query)
        {
            var entry = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == query.id);
            if (entry != null)
            {
                if (!string.IsNullOrEmpty(query.newData.Name)) 
                    entry.Name = query.newData.Name;

                if (query.newData.Area > 0)
                    entry.Area = query.newData.Area;

                if (query.newData.Voltage > 0)
                    entry.Voltage = query.newData.Voltage;

                entry.GasConnected = query.newData.GasConnected;
            }

            await _context.SaveChangesAsync();
        }
    }
}