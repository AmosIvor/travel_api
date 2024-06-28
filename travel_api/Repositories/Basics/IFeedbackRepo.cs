using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IFeedbackRepo
    {
        Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync();
        Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserIdAsync(string userId);
        Task<FeedbackVM> GetFeedbackByIdAsync(int feedbackId);
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByFilterAsync(int locationId, decimal rating = 5,
            int timeFeedbackType = 0, int tripType = 0);
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByUserIdAndCityIdAsync(string userId, int cityId);
    }
}
