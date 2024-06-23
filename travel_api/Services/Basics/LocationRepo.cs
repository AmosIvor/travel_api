using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
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
                                                   .Include(l => l.LocationMedias)
                                                   .SingleOrDefaultAsync(l => l.LocationId == locationId);

            if (location == null)
            {
                throw new NotFoundException("Location not found");
            }

            var locationMap = _mapper.Map<LocationVM>(location);

            var ratingStatistic = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 }
            };

            // Calculate star ratings distribution
            var actualRatings = location.Feedbacks
                                .GroupBy(f => f.FeedbackRate)
                                .Select(g => new { Star = g.Key, Quantity = g.Count() });

            int totalRatings = 0;
            int totalCount = 0;

            foreach (var rating in actualRatings)
            {
                ratingStatistic[rating.Star] = rating.Quantity;
                totalRatings += rating.Star * rating.Quantity;
                totalCount += rating.Quantity;
            }

            locationMap.RatingStatistic = ratingStatistic;

            // Calculate LocationRateAverage
            locationMap.LocationRateAverage = totalCount > 0 ? Math.Round((decimal)totalRatings / totalCount, 1) : 0;

            return locationMap;
        }

        public async Task<IEnumerable<PlaceResponseVM>> GetLocationOrCityBySearchAsync(string search)
        {
            var locations = await _context.Locations
                .Where(l => l.LocationName.Contains(search) || l.LocationAddress.Contains(search))
                .ToListAsync();

            var places = new List<PlaceResponseVM>();
            foreach (var location in locations)
            {
                places.Add(_mapper.Map<PlaceResponseVM>(location));
            }

            var cities = await _context.Cities
                .Where(c => c.CityName.Contains(search))
                .ToListAsync();

            foreach (var city in cities)
            {
                places.Add(_mapper.Map<PlaceResponseVM>(city));
            }

            return places;
        }

        public async Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync()
        {
            var top10Location = await _context.Locations
                                    .OrderByDescending(l => l.LocationRateAverage)
                                    .Include(l => l.LocationMedias)
                                    .Take(10)
                                    .ToListAsync();

            var top10LocationMap = _mapper.Map<IEnumerable<LocationVM>>(top10Location);

            return top10LocationMap;
        }
    }
}
