using AutoMapper;
using Module34.WebApi1.Configuration;
using Module34.WebApi1.Contracts.Devices;
using Module34.WebApi1.Contracts.Home;
using Module34.WebApi1.Contracts.Models.Devices;
using Module34.WebApi1.Contracts.Models.Rooms;
using Module34.WebApi1.Data.Models;
using Module34.WebApi1.Models;

namespace Module34.WebApi1
{
    /// <summary>
    /// Настройки маппинга всех сущностей приложения
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));

            // Валидация запросов:
            CreateMap<AddDeviceRequest, Device>()
                .ForMember(d => d.Location,
                    opt => opt.MapFrom(r => r.RoomLocation));
            CreateMap<AddRoomRequest, Room>();
            CreateMap<Device, DeviceView>();
        }
    }
}
