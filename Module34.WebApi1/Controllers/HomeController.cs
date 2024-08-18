using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Module34.WebApi1.Models;
using System.Text;
using System;

namespace Module34.WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // Ссылка на объект конфигурации
        private IOptions<HomeOptions> _options;

        // Инициализация конфигурации при вызове конструктора
        public HomeController(IOptions<HomeOptions> options)
        {
            _options = options;
        }

        /// <summary>
        /// Метод для получения информации о доме
        /// </summary>
        // Для обслуживания Get-запросов
        // Настройка маршрута с помощью атрибутов
        [HttpGet] 
        [Route("info")] 
        public IActionResult Info()
        {
            // Объект StringBuilder, в который будем "собирать" результат из конфигурации
            var pageResult = new StringBuilder();

            var newLine = Environment.NewLine;
            // Проставляем все значения из конфигурации для последующего вывода на страницу
            pageResult.Append($"Добро пожаловать в API вашего дома!{newLine}");
            pageResult.Append($"Здесь вы можете посмотреть основную информацию.{newLine}{newLine}"); 
            pageResult.Append($"Количество этажей:         {_options.Value.FloorAmount}{newLine}");
            pageResult.Append($"Стационарный телефон:      {_options.Value.Telephone}{newLine}"); 
            pageResult.Append($"Тип отопления:             {_options.Value.Heating}{newLine}"); 
            pageResult.Append($"Напряжение электросети:    {_options.Value.CurrentVolts}{newLine}"); 
            pageResult.Append($"Подключен к газовой сети:  {_options.Value.GasConnected}{newLine}"); 
            pageResult.Append($"Жилая площадь:             {_options.Value.Area} м2{newLine}"); 
            pageResult.Append($"Материал:                  {_options.Value.Material}{newLine}{newLine}");
            pageResult.Append($"Адрес:                     {_options.Value.Address.Street} ");
            pageResult.Append($"{_options.Value.Address.House}/");
            pageResult.Append($"{_options.Value.Address.Building}{newLine}");

            // Преобразуем результат в строку и выводим, как обычную веб-страницу
            return StatusCode(200, pageResult.ToString());
        }
    }
}
