using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.EFViewModel;

namespace travel_api.Services.Basics
{
    public class CityRepo : BaseRepo<City, CityVM, int>, ICityRepo
    {
        public CityRepo(DataContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<bool> IsExistCityName(string cityName)
        {
            return await _context.Cities.AnyAsync(c => c.CityName == cityName);
        }
    }
}
