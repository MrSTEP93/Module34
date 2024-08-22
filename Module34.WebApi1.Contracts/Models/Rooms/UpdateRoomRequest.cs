using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Contracts.Models.Rooms
{
    public class UpdateRoomRequest
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public bool GasConnected { get; set; }
        public int Voltage { get; set; }
    }
}
