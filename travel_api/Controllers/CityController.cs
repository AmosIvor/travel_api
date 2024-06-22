using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.ViewModels.Requests.EFRequest;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IBaseRepo<City, CityVM, CityRequest, int> _cityRepo;

        public CityController(IBaseRepo<City, CityVM, CityRequest, int> cityRepo)
        {
            _cityRepo = cityRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            var citiesVM = await _cityRepo.GetAllAsync();

            return Ok(new SuccessResponseVM<IEnumerable<CityVM>>()
            {
                Message = "Get all cities successfully",
                Data = citiesVM
            });
        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCityById(int cityId)
        {
            var cityVM = await _cityRepo.GetByIdAsync(cityId);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Get city by id successfully",
                Data = cityVM
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(CityRequest cityVM)
        {
            var cityVMResult = await _cityRepo.AddAsync(cityVM);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Create new city successfully",
                Data = cityVMResult
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityRequest cityVM)
        {
            var cityVMResult = await _cityRepo.UpdateAsync(cityVM);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Update city successfully",
                Data = cityVMResult
            });
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCityById(int cityId)
        {
            var cityVM = await _cityRepo.DeleteAsync(cityId);

            return Ok(new SuccessResponseVM<CityVM>()
            {
                Message = "Delete city by id successfully",
                Data = cityVM
            });
        }
    }
}
