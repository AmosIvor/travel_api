using Microsoft.AspNetCore.Mvc;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepo _service;

        public ChatController(IChatRepo service)
        {
            _service = service;
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
            return Ok(await _service.SendMessage(vm));
        }
    }
}
