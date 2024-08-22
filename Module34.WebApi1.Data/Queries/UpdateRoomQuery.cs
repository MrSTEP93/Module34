using Module34.WebApi1.Contracts.Models.Rooms;
using Module34.WebApi1.Data.Models;
using System;

namespace Module34.WebApi1.Data.Queries
{
    /// <summary>
    /// Класс для передачи запроса на обновление комнаты
    /// </summary>
    public class UpdateRoomQuery
    {
        public Guid id;
        //public Room _changedRoom;
        public UpdateRoomRequest newData;

        public UpdateRoomQuery(Guid guid, UpdateRoomRequest request)
        {
            id = guid;
            newData = request;
        }
    }
}
