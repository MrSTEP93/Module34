using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Contracts.Models.Devices
{
    public class EditDeviceRequest
    {
        /// <summary>
        /// Запрос для обновления свойств подключенного устройства
        /// </summary>
        public string NewRoom { get; set; }
        public string NewName { get; set; }
        public string NewSerial { get; set; }
    }
}
