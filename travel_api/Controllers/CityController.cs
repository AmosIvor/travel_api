using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IBaseRepo<City, CityVM, CityRequest, int> _baseRepo;
        private readonly ICityRepo _cityRepo;

        public CityController(IBaseRepo<City, CityVM, CityRequest, int> baseRepo, ICityRepo cityRepo)
        {
            _baseRepo = baseRepo;
            _cityRepo = cityRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            var citiesVM = await _baseRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<CityVM>>()
            {
                Message = "Get all cities successfully",
                Data = citiesVM
            });
        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCityById(int cityId)
        {
            var cityVM = await _baseRepo.GetByIdAsync(cityId);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Get city by id successfully",
                Data = cityVM
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(CityRequest cityVM)
        {
            var cityVMResult = await _baseRepo.AddAsync(cityVM);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Create new city successfully",
                Data = cityVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityRequest cityVM)
        {
            var cityVMResult = await _baseRepo.UpdateAsync(cityVM);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Update city successfully",
                Data = cityVMResult
            });
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCityById(int cityId)
        {
            var cityVM = await _baseRepo.DeleteAsync(cityId);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Delete city by id successfully",
                Data = cityVM
            });
        }

        [HttpGet("{userId}/city-has-feedback")]
        public async Task<IActionResult> GetCitiesHaveFeedback(string userId)
        {
            var result = await _cityRepo.GetCitiesHaveFeedback(userId);

            return Ok(new SuccessResponseVM<IEnumerable<CityHasQuantityFeedbackVM>>()
            {
                Message = "Get list city has feedback successfully",
                Data = result
            });
        }
    }
}
