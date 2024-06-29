using travel_api.Models.EF;
using travel_api.Services.Utils;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.UtilViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IFeedbackRepo
    {
        Task<Feedback> AddFeedback(FeedbackBCVM vm);
        Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync();
        Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserIdAsync(string userId);
        Task<FeedbackVM> GetFeedbackByIdAsync(int feedbackId);
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByFilterAsync(int locationId, decimal rating = 5,
            int timeFeedbackType = 0, int tripType = 0);

        Task<object> GetBlockDetail(int feedbackId);
        Task<IEnumerable<FeedbackBC>> GetChainData();
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByUserIdAndCityIdAsync(string userId, int cityId);
    }
}
