using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module34.WebApi1.Contracts.Devices;
using Module34.WebApi1.Models;
using System.IO;
using System.Linq;

namespace Module34.WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : Controller
    {
        IHostEnvironment _env;
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public DevicesController(IHostEnvironment env, IOptions<HomeOptions> options, IMapper mapper)
        {
            _env = env;
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// [FromBody] // Атрибут, указывающий, откуда брать значение объекта
        /// request // Объект запроса
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] AddDeviceRequest request)
        {
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }

        [HttpGet]
        [HttpHead]
        [Route("GetManual/{name}")]
        public IActionResult GetManual([FromRoute] string name)
        {
            var staticPath = Path.Combine(_env.ContentRootPath, "Static");
            var filePath = Directory.GetFiles(staticPath)
                .FirstOrDefault(f => f.Split("\\").Last().Split('.')[0] == name);

            if (string.IsNullOrEmpty(filePath))
                return StatusCode(404, $"Инструкция для оборудования {name} не найдена. Проверьте корректность названия");

            string fileType = "file/pdf";
            string fileName = $"{name}.pdf";
            return PhysicalFile(filePath, fileType, fileName);

        }
    }
}
