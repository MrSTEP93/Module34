using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Contracts.Validators
{
    /// <summary>
    /// Класс-хранилище допустымых значений для валидаторов
    /// </summary>
    public static class Values
    {
        public static string[] ValidRooms = new[]
        {
            "Спальня",
            "Кухня",
            "Ванная",
            "Гостиная",
            "Туалет"
        };
    }
}
