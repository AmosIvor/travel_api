using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using travel_api.Hubs;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IBaseRepo<Message, MessageVM, MessageRequest, int> _baseRepo;
        private readonly IChatRepo _service;
        private readonly IHubContext<ChatHub> _hub;

        public ChatController(IChatRepo service, IHubContext<ChatHub> hub, IBaseRepo<Message, MessageVM, MessageRequest, int> baseRepo)
        {
            _service = service;
            _hub = hub;
            _baseRepo = baseRepo;
        }

        [HttpGet("{userId}/conversations")]
        public async Task<IActionResult> GetConversations(string userId)
        {
            var result = await _service.GetUserConversations(userId);

            return Ok(new SuccessResponseVM<IEnumerable<ChatRoomVM>>()
            {
                Message = "Get user conversation successfully",
                Data = result
            });
        }

        [HttpGet("{roomId}/messages")]
        public async Task<IActionResult> GetMessages(int roomId)
        {
            //return Ok(await _service.GetMessages(roomId));
            var result = await _service.GetMessagesByRoomIdAsync(roomId);

            return Ok(new SuccessResponseVM<IEnumerable<MessageVM>>()
            {
                Message = "Get messages successfully",
                Data = result
            });
        }

        [HttpGet("conversations/{searchString}")]
        public async Task<IActionResult> FindConversations(string searchString)
        {
            var result = await _service.FindConversations(searchString);

            return Ok(new SuccessResponseVM<IEnumerable<ChatRoomVM>>()
            {
                Message = "Get list conversation successfully",
                Data = result
            });
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(MessageRequest vm)
        {
            var result = await _baseRepo.AddAsync(vm);
            await _hub.Clients.All.SendAsync("ReceiveMessage", result);

            return Ok(new SuccessResponseVM<MessageVM>()
            {
                Message = "Create message successfully",
                Data = result
            });
        }

        [HttpPost("new-room")]
        public async Task<IActionResult> CreateRoom(ChatRoomRequest vm)
        {
            var result = await _service.CreateNewRoom(vm);

            return Ok(new SuccessResponseVM<ChatRoomVM>()
            {
                Message = "Create chat room successfully",
                Data = result
            });
        }

        [HttpPut("update-room")]
        public async Task<IActionResult> UpdateRoom(ChatRoomRequest vm)
        {
            var result = await _service.UpdateRoomAsync(vm);

            return Ok(new SuccessResponseVM<ChatRoomVM>()
            {
                Message = "Update chat room successfully",
                Data = result
            });
        }
    }
}
