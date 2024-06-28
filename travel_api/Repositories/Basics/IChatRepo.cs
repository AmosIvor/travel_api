using travel_api.Models.EF;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IChatRepo
    {
        Task<IEnumerable<ChatRoomVM>> GetUserConversations(string userId);
        Task<IEnumerable<MessageVM>> GetMessagesByRoomIdAsync(int roomId);
        Task<IEnumerable<ChatRoomVM>> FindConversations(string search);
        Task<ChatRoomVM> CreateNewRoom(ChatRoomRequest vm);
        Task<ChatRoomVM> UpdateRoomAsync(ChatRoomRequest vm);
        Task<MessageVM> SendMessageAsync(MessageRequest req);
    }
}
