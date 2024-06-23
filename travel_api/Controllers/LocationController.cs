using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IBaseRepo<Location, LocationVM, LocationRequest, int> _baseRepo;
        private readonly ILocationRepo _locationRepo;
        public LocationController(IBaseRepo<Location, LocationVM, LocationRequest, int> baseRepo, ILocationRepo locationRepo)
        {
            _baseRepo = baseRepo;
            _locationRepo = locationRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            var locationsVM = await _baseRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<LocationVM>>()
            {
                Message = "Get all locations successfully",
                Data = locationsVM
            });
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var locationVM = await _locationRepo.GetLocationByIdAsync(locationId);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Get location by id successfully",
                Data = locationVM
            });
        }

        [HttpGet("search-locations-or-cities")]
        public async Task<IActionResult> SearchLocationsOrCities([FromQuery] string searchString)
        {
            var result = await _locationRepo.GetLocationOrCityBySearchAsync(searchString);

            return Ok(new SuccessResponseVM<IEnumerable<PlaceResponse<object>>>()
            {
                Message = "Search locations or cities successfully",
                Data = result
            });
        }

        [HttpGet("get-locations-by-city")]
        public async Task<IActionResult> GetLocationsByCity(int cityId)
        {
            var result = await _locationRepo.GetLocationsByCity(cityId);

            return Ok(new SuccessResponseVM<IEnumerable<LocationVM>>()
            {
                Message = "Get locations by city successfully",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationRequest locationVM)
        {
            var locationVMResult = await _baseRepo.AddAsync(locationVM);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Create new location successfully",
                Data = locationVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(LocationRequest locationVM)
        {
            var locationVMResult = await _baseRepo.UpdateAsync(locationVM);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Update location successfully",
                Data = locationVMResult
            });
        }

        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteLocationById(int locationId)
        {
            var locationVM = await _baseRepo.DeleteAsync(locationId);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Delete location by id successfully",
                Data = locationVM
            });
        }

        [HttpGet("top-10-location")]
        public async Task<IActionResult> GetTop10LocationByRating()
        {
            var listLocationVM = await _locationRepo.GetTop10LocationByRatingAsync();

            return Ok(new SuccessResponseVM<IEnumerable<LocationVM>>()
            {
                Message = "Get top 10 location successfully",
                Data = listLocationVM
            });
        }
    }
}
