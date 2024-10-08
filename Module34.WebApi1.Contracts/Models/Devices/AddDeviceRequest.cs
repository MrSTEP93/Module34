﻿using System.ComponentModel.DataAnnotations;

namespace Module34.WebApi1.Contracts.Devices
{
    /// <summary>
    /// Добавляет поддержку нового устройства.
    /// </summary>
    public class AddDeviceRequest
    {
        public string Name { get; set; }
        
        public string Manufacturer { get; set; }
        
        public string Model { get; set; }
        
        public string SerialNumber { get; set; }

        public int Voltage { get; set; }
        
        public bool GasUsage { get; set; }
        
        public string Location { get; set; }
    }
}
