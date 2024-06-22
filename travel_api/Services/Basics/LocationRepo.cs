using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class LocationRepo : ILocationRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LocationRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LocationVM> GetLocationByIdAsync(int locationId)
        {
            var location = await _context.Locations.Include(l => l.Feedbacks)
                                                   .Include(l => l.Posts)
                                                   .SingleOrDefaultAsync(l => l.LocationId == locationId);

            var locationMap = _mapper.Map<LocationVM>(location);

            return locationMap;
        }

        public async Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync()
        {
            var top10Location = await _context.Locations
                                    .OrderByDescending(l => l.LocationRateAverage)
                                    .Take(10)
                                    .ToListAsync();

            var top10LocationMap = _mapper.Map<IEnumerable<LocationVM>>(top10Location);

            return top10LocationMap;
        }
    }
}
