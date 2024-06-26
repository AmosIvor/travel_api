using travel_api.Models.EF;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface INotificationRepo
    {
        Task<IEnumerable<Notification>> GetNotifications(string userId);
        Task SendNotification(NotificationVM vm);
        Task ReadNotifications(List<string> NotiIds);
    }
}
