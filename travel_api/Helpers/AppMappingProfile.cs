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
            CreateMap<Post, PostVM>().ReverseMap();
            CreateMap<Feedback, FeedbackVM>().ReverseMap();
            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<FeedbackMedia,  FeedbackMediaVM>().ReverseMap();
            CreateMap<PostMedia, PostMediaVM>().ReverseMap();
            CreateMap<Comment, CommentVM>().ReverseMap();
            CreateMap<CommentMedia, CommentMediaVM>().ReverseMap();

            // utils
            CreateMap<Photo, PhotoVM>().ReverseMap();
        }
    }
}
