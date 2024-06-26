using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using travel_api.Hubs;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepo _service;
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationController(INotificationRepo service, IHubContext<NotificationHub> hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpGet("get-notifications")]
        public async Task<IActionResult> GetNotifications(string userId)
        {
            return Ok(await _service.GetNotifications(userId));
        }

        [HttpPost("send-notification")]
        public async Task<IActionResult> SendNotification(NotificationVM vm)
        {
            await _service.SendNotification(vm);
            await _hub.Clients.All.SendAsync("NewNotification", "");
            return Ok();
        }

        [HttpPost("read-notifications")]
        public async Task<IActionResult> ReadNotifications([FromBody] List<string> NotiIds)
        {
            await _service.ReadNotifications(NotiIds);
            return Ok();
        }
    }
}
