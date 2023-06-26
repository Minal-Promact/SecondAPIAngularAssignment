using AutoMapper;
using SecondAPIAngularAssignment.DTO;
using SecondAPIAngularAssignment.Model;

namespace SecondAPIAngularAssignment.AutomapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Carousel, CarouselRequestDTO>().ReverseMap();            
        }
    }
}
