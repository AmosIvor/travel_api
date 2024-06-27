using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IFeedbackRepo
    {
        Task AddFeedback(int fbId, int score, string userId, string comment);
        Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync();
        Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserIdAsync(string userId);
        Task<FeedbackVM> GetFeedbackByIdAsync(int feedbackId);
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByFilterAsync(decimal rating = 5,
            int timeFeedbackType = 0, int tripType = 0);

        Task<object> ReadChain();
    }
}
