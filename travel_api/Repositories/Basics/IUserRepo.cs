﻿using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Repositories.Basics
{
    public interface IUserRepo
    {
        Task<ICollection<UserVM>> GetUsersAsync();
    }
}
