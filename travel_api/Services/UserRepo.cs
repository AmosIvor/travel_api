using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Repositories;
using travel_api.ViewModels.EFViewModel;

namespace travel_api.Services
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

        public async Task<ICollection<UserVM>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            var usersVM = _mapper.Map<ICollection<UserVM>>(users);

            return usersVM;
        }
    }
}
