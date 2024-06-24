using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Helpers;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

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
                ratingStatistic[(int)rating.Star] = rating.Quantity;
                totalRatings += (int)rating.Star * rating.Quantity;
                totalCount += rating.Quantity;
            }

            locationMap.RatingStatistic = ratingStatistic;

            // Calculate LocationRateAverage
            locationMap.LocationRateAverage = totalCount > 0 ? Math.Round((decimal)totalRatings / totalCount, 1) : 0;

            return locationMap;
        }

        public async Task<IEnumerable<PlaceResponse<object>>> GetLocationOrCityBySearchAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return Enumerable.Empty<PlaceResponse<object>>();
            }

            searchString = AppUtils.RemoveDiacritics(searchString.Trim().ToLower());

            var cities = await _context.Cities.ToListAsync();

            var cityResults = cities
            .Where(c => AppUtils.RemoveDiacritics(c.CityName.ToLower()).Contains(searchString))
            .Select(c => new PlaceResponse<object>
            {
                Result = new CityBaseVM
                {
                    CityId = c.CityId,
                    CityName = c.CityName,
                    CityDescription = c.CityDescription
                },
                IsCity = true,
                IsLocation = false
            });

            var locations = await _context.Locations.ToListAsync();

            var locationResults = locations
            .Where(l => AppUtils.RemoveDiacritics(l.LocationName.ToLower()).Contains(searchString))
            .Select(l => new PlaceResponse<object>
            {
                Result = new LocationBaseVM
                {
                    LocationId = l.LocationId,
                    LocationName = l.LocationName,
                    LocationAddress = l.LocationAddress,
                    LocationOpenTime = l.LocationOpenTime,
                    LocationLongtitude = l.LocationLongtitude,
                    LocationLatitude = l.LocationLatitude,
                    LocationRateAverage = l.LocationRateAverage,
                    CityId = l.CityId,
                },
                IsCity = false,
                IsLocation = true
            });

            return cityResults.Concat(locationResults);
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
