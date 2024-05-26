namespace travel_api.Repositories.Basics
{
    public interface ICityRepo
    {
        Task<bool> IsExistCityName(string cityName);
    }
}
