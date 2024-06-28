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
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserVM> GetUserByIdAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var userMap = _mapper.Map<UserVM>(user);

            return userMap;
        }

        public async Task<ICollection<UserVM>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            var usersVM = _mapper.Map<ICollection<UserVM>>(users);

            return usersVM;
        }

        public async Task<IEnumerable<UserBaseVM>> SearchUsersByUserNameAsync(string userNameSearchString)
        {
            var userNameSearchStringStandardized = userNameSearchString.ToLower().Trim();
            var users = await _context.Users
                                           .Where(x => x.UserName.ToLower().Trim().Contains                                                        (userNameSearchStringStandardized))
                                           .OrderByDescending(x => x.Feedbacks.Count)
                                           .AsNoTracking()
                                           .ToListAsync();

            var usersMap = _mapper.Map<IEnumerable<UserBaseVM>>(users);

            return usersMap;
        }

        public async Task<UserVM> UpdateUserAsync(UserUpdateRequest req)
        {
            var user = await _context.Users.FindAsync(req.UserId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            if (req.CityId != null)
            {
                user.CityId = req.CityId;
                var city = await _context.Cities.FindAsync(req.CityId);
                
                if (city != null)
                {
                    user.City = city;
                }
            }
            user.UserDescription = req.UserDescription;
            user.Avatar = req.Avatar;

            _context.Update(user);

            await _context.SaveChangesAsync();

            var userMap = _mapper.Map<UserVM>(user);

            return userMap;
        }
    }
}
