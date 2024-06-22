using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IFeedbackRepo
    {
        Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync();
        Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserIdAsync(string userId);
        Task<FeedbackVM> GetFeedbackByIdAsync(int feedbackId);
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByFilterAsync(decimal rating = 5, int timeFeedbackType = 1, int tripType = 4);
    }
}
