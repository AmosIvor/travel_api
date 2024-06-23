using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class ChatRepo : IChatRepo
    {
        private readonly DataContext _context;
        public ChatRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatRoomVM>> GetUserConversations(string userId)
        {
            var rooms = await _context.RoomDetails
                .Where(d => d.UserId == userId)
                .Select(d => new ChatRoomVM
                {
                    RoomId = d.RoomId,
                    RoomName = d.Room!.RoomName
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<IEnumerable<Message>> GetMessages(int roomId)
        {
            var messages = await _context.ChatRooms
                .Where(r => r.RoomId == roomId)
                .Select(r => r.Messages)
                .FirstOrDefaultAsync();

            if (messages == null)
            {
                return new List<Message>();
            }

            return messages;
        }

        public async Task<IEnumerable<ChatRoomVM>> FindConversations(string search)
        {
            var rooms = await _context.ChatRooms
                .Where(r => r.RoomName!.ToLower().Contains(search.ToLower()))
                .Select(r => new ChatRoomVM
                {
                    RoomId = r.RoomId,
                    RoomName = r.RoomName,
                })
                .ToListAsync();

            return rooms;
        }
    }
}
