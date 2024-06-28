using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
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

        public async Task<IEnumerable<MessageVM>> GetMessagesByRoomIdAsync(int roomId)
        {
            var messages = await _context.Messages
                .Where(m => m.RoomId == roomId)
                .Include(m => m.MessageMedias)
                .Include(m => m.User)
                .Include(m => m.Room)
                .OrderBy(m => m.MessageCreateAt)
                .AsNoTracking()
                .ToListAsync();

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

            if (req.userIdsJoin != null)
            {
                foreach (var userId in req.userIdsJoin)
                {
                    _context.RoomDetails.Add(new RoomDetail
                    {
                        RoomId = room.RoomId,
                        UserId = userId
                    });
                }

            }

            await _context.SaveChangesAsync();

            var roomMap = _mapper.Map<ChatRoomVM>(room);

            return roomMap;
        }

        public async Task<string> GetRoomName(ChatRoomRequest req)
        {
            
            if (req.userIdsJoin != null && req.userIdsJoin.Count == 2)
            {
                return "";
            }

            if (req.userIdsJoin != null && req.userIdsJoin.Count > 2)
            {
                if (!string.IsNullOrEmpty(req.RoomName))
                {
                    return req.RoomName;
                }

                var users = await _context.Users.Where(x => req.userIdsJoin.Contains(x.Id))
                                                .AsNoTracking()
                                                .ToListAsync();
                                                
                string roomName = users.ElementAt(0).UserName!;
                for (int i = 1; i < 3; i++)
                {
                    roomName += ", " + users.ElementAt(i).UserName;
                }

                if (req.userIdsJoin.Count > 3)
                {
                    roomName += $" + {req.userIdsJoin.Count - 1}";
                }

                return roomName;
            }

            return "";
        }

        public async Task<ChatRoomVM> UpdateRoomAsync(ChatRoomRequest req)
        {
            var room = await _context.ChatRooms.Include(x => x.RoomDetails)
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync(r => r.RoomId == req.RoomId);

            if (room == null)
            {
                throw new NotFoundException("Room not found");
            }

            if (req.RoomName != null)
            {
                room.RoomName = req.RoomName;
            }

            var roomDetails = room.RoomDetails;

            if (req.userIdsLeave != null)
            {
                foreach (var userId in req.userIdsLeave)
                {
                    var roomDetail = roomDetails.FirstOrDefault(rd => rd.UserId == userId);

                    if (roomDetail != null)
                    {
                        _context.RoomDetails.Remove(roomDetail);
                    }
                }
            }

            if (req.userIdsJoin != null)
            {
                foreach (var userId in req.userIdsJoin)
                {
                    if (!roomDetails.Any(rd => rd.UserId == userId))
                    {
                        _context.RoomDetails.Add(new RoomDetail 
                        {
                            UserId = userId,
                            RoomId = room.RoomId 
                        });
                    }
                }
            }

            await _context.SaveChangesAsync();

            var roomMap = _mapper.Map<ChatRoomVM>(room);

            return roomMap;
        }
    }
}
