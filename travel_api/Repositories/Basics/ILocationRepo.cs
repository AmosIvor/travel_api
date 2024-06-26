﻿using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.ResultResponseViewModel;

namespace travel_api.Repositories.Basics
{
    public interface ILocationRepo
    {
        Task<IEnumerable<LocationVM>> GetLocationsAsync();
        Task<LocationVM> GetLocationByIdAsync(int locationId);
        Task<IEnumerable<LocationVM>> GetTop10LocationByRatingAsync();
        Task<IEnumerable<PlaceResponse<object>>> GetLocationOrCityBySearchAsync(string searchString);
        IEnumerable<LocationVM> GetLocationsByCity(int cityId);
        Task<IEnumerable<FeedbackVM>> GetFeedbacksByLocationAsync(int locationId);
    }
}
