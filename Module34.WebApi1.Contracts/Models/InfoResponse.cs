using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Contracts.Models
{
    public class InfoResponse
    {
        public int FloorAmount { get; set; }
        public string Telephone { get; set; }
        public string Heating { get; set; }
        public int Voltage { get; set; }
        public bool GasConnected { get; set; }
        public int Area { get; set; }
        public string Material { get; set; }
        public AddressInfo AddressInfo { get; set; }
    }

    public class AddressInfo
    {
        public int House { get; set; }
        public int Building { get; set; }
        public string Street { get; set; }
    }
}
