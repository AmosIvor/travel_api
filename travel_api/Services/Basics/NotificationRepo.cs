using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly DataContext _context;

        public NotificationRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetNotifications(string userId)
        {
            return await _context.Notifications.Where(n => n.UserId == userId).ToListAsync();
        }

        public async Task ReadNotifications(List<string> NotiIds)
        {
            foreach (var notiId in NotiIds)
            {
                var noti = await _context.Notifications.FindAsync(notiId);

                if (noti == null) continue;

                noti.IsRead = true;
                _context.Notifications.Update(noti);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SendNotification(NotificationVM vm)
        {
            foreach (var userId in vm.UserIds)
            {
                var newNoti = new Notification
                {
                    NotiId = Guid.NewGuid().ToString(),
                    NotiTitle = vm.NotiTitle,
                    NotiContent = vm.NotiContent,
                    CreateTime = DateTime.Now,
                    Redirect = vm.Redirect,
                    IsRead = false,
                    UserId = userId,
                };

                _context.Notifications.Add(newNoti);
                await _context.SaveChangesAsync();
            }
        }
    }
}
