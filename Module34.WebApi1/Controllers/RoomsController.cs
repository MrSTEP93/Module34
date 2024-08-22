using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Module34.WebApi1.Contracts.Models.Rooms;
using Module34.WebApi1.Data.Models;
using Module34.WebApi1.Data.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module34.WebApi1.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;

        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _repository.GetAllRooms();
            var resp = new GetRoomsResponse()
            {
                RoomAmount = rooms.Length,
                Rooms = _mapper.Map<Room[], RoomView[]>(rooms)
            };
            return StatusCode(200, resp);
        }

        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }

            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }
    }
}
