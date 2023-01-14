using AutoMapper;
using Hotels.API.Data;
using Hotels.API.Models.Hotel;

namespace Hotels.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDTO>().ReverseMap();
            //CreateMap<Hotel, Hotel>();

        }
    }
}
