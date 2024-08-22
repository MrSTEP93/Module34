using Module34.WebApi1.Data.Models;
using Module34.WebApi1.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module34.WebApi1.Data.Repos
{
    public interface IDeviceRepository
    {
        Task<Device[]> GetDevices();
        Task<Device> GetDeviceByName(string name);
        Task<Device> GetDeviceById(Guid id);
        Task SaveDevice(Device device, Room room);
        Task EditDevice(Device device, Room room, EditDeviceQuery query);
        Task DeleteDevice(Device device);
    }
}
