using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using travel_api.Hubs;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepo _service;
        private readonly IHubContext<ChatHub> _hub;

        public ChatController(IChatRepo service, IHubContext<ChatHub> hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpGet("get-conversations")]
        public async Task<IActionResult> GetConversations(string userId)
        {
            return Ok(await _service.GetUserConversations(userId));
        }

        [HttpGet("get-messages")]
        public async Task<IActionResult> GetMessages(int roomId)
        {
            return Ok(await _service.GetMessages(roomId));
        }

        [HttpGet("find-conversations")]
        public async Task<IActionResult> FindConversations(string search)
        {
            return Ok(await _service.FindConversations(search));
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(MessageVM vm)
        {
            var result = await _service.SendMessage(vm);
            await _hub.Clients.All.SendAsync("ReceiveMessage", result);

            return Ok(result);
        }

        [HttpPost("new-room")]
        public async Task<IActionResult> NewRoom(ChatRoomVM vm)
        {
            return Ok(await _service.CreateNewRoom(vm));
        }
    }
}
