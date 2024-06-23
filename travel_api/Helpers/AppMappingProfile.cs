using AutoMapper;
using travel_api.Models.EF;
using travel_api.Models.Utils;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.UtilViewModel;

namespace travel_api.Helpers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            // ef
            CreateMap<User, UserBaseVM>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();

            CreateMap<City, CityRequest>().ReverseMap();
            CreateMap<City, CityBaseVM>().ReverseMap();
            CreateMap<City, CityVM>().ReverseMap();

            CreateMap<Post, PostRequest>().ReverseMap();
            CreateMap<Post, PostBaseVM>().ReverseMap();
            CreateMap<Post, PostVM>().ReverseMap();

            CreateMap<Feedback, FeedbackRequest>().ReverseMap();
            CreateMap<Feedback, FeedbackBaseVM>().ReverseMap();
            CreateMap<Feedback, FeedbackVM>().ReverseMap();

            CreateMap<Location, LocationRequest>().ReverseMap();
            CreateMap<Location, LocationBaseVM>().ReverseMap();
            CreateMap<Location, LocationVM>().ReverseMap();

            CreateMap<LocationMedia, LocationMediaRequest>().ReverseMap();
            CreateMap<LocationMedia, LocationMediaBaseVM>().ReverseMap();
            CreateMap<LocationMedia, LocationMediaVM>().ReverseMap();

            CreateMap<FeedbackMedia, FeedbackMediaRequest>().ReverseMap();
            CreateMap<FeedbackMedia, FeedbackMediaBaseVM>().ReverseMap();
            CreateMap<FeedbackMedia, FeedbackMediaVM>().ReverseMap();

            CreateMap<PostMedia, PostMediaRequest>().ReverseMap();
            CreateMap<PostMedia, PostMediaBaseVM>().ReverseMap();
            CreateMap<PostMedia, PostMediaVM>().ReverseMap();

            CreateMap<Comment, CommentRequest>().ReverseMap();
            CreateMap<Comment, CommentBaseVM>().ReverseMap();
            CreateMap<Comment, CommentVM>().ReverseMap();

            CreateMap<CommentMedia, CommentMediaRequest>().ReverseMap();
            CreateMap<CommentMedia, CommentMediaBaseVM>().ReverseMap();
            CreateMap<CommentMedia, CommentMediaVM>().ReverseMap();

            // utils
            CreateMap<Photo, PhotoVM>().ReverseMap();
        }
    }
}
