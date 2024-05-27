using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.ViewModels.EFViewModel;
using travel_api.ViewModels.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IBaseRepo<Location, LocationVM, int> _locationRepo;
        public LocationController(IBaseRepo<Location, LocationVM, int> locationRepo)
        {
            _locationRepo = locationRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            var locationsVM = await _locationRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<LocationVM>>()
            {
                Message = "Get all locations successfully",
                Data = locationsVM
            });
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetCityById(int locationId)
        {
            var locationVM = await _locationRepo.GetByIdAsync(locationId);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Get location by id successfully",
                Data = locationVM
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(LocationVM locationVM)
        {
            var locationVMResult = await _locationRepo.AddAsync(locationVM);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Create new location successfully",
                Data = locationVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(LocationVM locationVM)
        {
            var locationVMResult = await _locationRepo.UpdateAsync(locationVM);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Update location successfully",
                Data = locationVMResult
            });
        }

        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteCityById(int locationId)
        {
            var locationVM = await _locationRepo.DeleteAsync(locationId);

            return Ok(new SuccessResponseVM<LocationVM>()
            {
                Message = "Delete location by id successfully",
                Data = locationVM
            });
        }
    }
}
