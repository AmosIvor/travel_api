using travel_api.Models.EF;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IChatRepo
    {
        Task<IEnumerable<ChatRoomVM>> GetUserConversations(string userId);
        Task<IEnumerable<Message>> GetMessages(int roomId);
        Task<IEnumerable<ChatRoomVM>> FindConversations(string search);
        Task<Message> SendMessage(MessageVM message);
    }
}
