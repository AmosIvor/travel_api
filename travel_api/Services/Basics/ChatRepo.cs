using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class ChatRepo : IChatRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ChatRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<IEnumerable<MessageVM>> GetMessages(int roomId)
        {
            var messages = await _context.ChatRooms
                .Where(r => r.RoomId == roomId)
                .Select(r => r.Messages)
                .FirstOrDefaultAsync();

            var messagesMap = _mapper.Map<IEnumerable<MessageVM>>(messages);

            return messagesMap;
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

        public async Task<ChatRoomVM> CreateNewRoom(ChatRoomRequest req)
        {
            var room = new ChatRoom()
            {
                RoomName = await GetRoomName(req)
            };

            _context.ChatRooms.Add(room);
            await _context.SaveChangesAsync();

            if (req.userIds != null)
            {
                foreach (var userId in req.userIds)
                {
                    _context.RoomDetails.Add(new RoomDetail
                    {
                        RoomId = room.RoomId,
                        UserId = userId
                    });
                }

                await _context.SaveChangesAsync();
            }

            var roomMap = _mapper.Map<ChatRoomVM>(room);

            return roomMap;
        }

        public async Task<string> GetRoomName(ChatRoomRequest req)
        {
            
            if (req.userIds != null && req.userIds.Count == 2)
            {
                return "";
            }

            if (req.userIds != null && req.userIds.Count > 2)
            {
                if (!string.IsNullOrEmpty(req.RoomName))
                {
                    return req.RoomName;
                }

                var users = await _context.Users.Where(x => req.userIds.Contains(x.Id))
                                                .AsNoTracking()
                                                .ToListAsync();
                                                
                string roomName = users.ElementAt(0).UserName!;
                for (int i = 1; i < 3; i++)
                {
                    roomName += ", " + users.ElementAt(i).UserName;
                }

                if (req.userIds.Count > 3)
                {
                    roomName += $" + {req.userIds.Count - 1}";
                }

                return roomName;
            }

            return "";
        }
    }
}
