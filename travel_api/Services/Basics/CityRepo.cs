using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class CityRepo : ICityRepo
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CityRepo(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CityHasQuantityFeedbackVM>> GetCitiesHaveFeedback(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var feedbacks = await _context.Feedbacks
                                            .Where(f => f.UserId == userId)
                                            .Include(f => f.Location)
                                            .ThenInclude(l => l.City)
                                            .AsNoTracking()
                                            .ToListAsync();

            var citiesWithFeedbackCount = feedbacks
                                            .GroupBy(f => new
                                            {
                                                f.Location.City.CityId,
                                                f.Location.City.CityName,
                                                f.Location.City.CityDescription,
                                                f.Location.City.CityUrl
                                            })
                                            .Select(g => new CityHasQuantityFeedbackVM()
                                            {
                                                CityId = g.Key.CityId,
                                                CityName = g.Key.CityName,
                                                CityDescription = g.Key.CityDescription,
                                                CityUrl = g.Key.CityUrl,
                                                FeedbackQuantity = g.Count()
                                            })
                                            .ToList();

            return citiesWithFeedbackCount;
        }
    }
}
