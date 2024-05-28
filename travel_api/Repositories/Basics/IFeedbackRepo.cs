using travel_api.ViewModels.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IFeedbackRepo
    {
        Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync();
        Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserId(string userId);
        Task<FeedbackVM> GetFeedbackById(int feedbackId);
    }
}
