using AutoMapper;
using travel_api.Models.EF;
using travel_api.Models.Utils;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.UtilViewModel;

namespace travel_api.Helpers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            // ef
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<City, CityVM>().ReverseMap();

            // utils
            CreateMap<Photo, PhotoVM>().ReverseMap();
        }
    }
}
