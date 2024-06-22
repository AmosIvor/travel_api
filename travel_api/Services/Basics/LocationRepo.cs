using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

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
                                    .Take(10)
                                    .ToListAsync();

            var top10LocationMap = _mapper.Map<IEnumerable<LocationVM>>(top10Location);

            return top10LocationMap;
        }
    }
}
