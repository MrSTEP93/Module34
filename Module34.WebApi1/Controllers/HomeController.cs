﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Module34.WebApi1.Models;
using System.Text;
using System;
using AutoMapper;
using Module34.WebApi1.Contracts.Home;

namespace Module34.WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        // Инициализация конфигурации при вызове конструктора
        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для получения информации о доме
        /// </summary>
        [HttpGet]
        [Route("info")]
        public IActionResult Info()
        {
            // Получим запрос, смапив конфигурацию на модель запроса
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            // Вернём ответ
            return StatusCode(200, infoResponse);
        }
    }
}
