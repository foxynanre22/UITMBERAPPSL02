using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using UITMBER.Models.UserFavouriteLocation;

namespace UITMBER.Services.UFLocations
{
    public interface IUFLocationsService
    {
        Task<List<UserFavouriteLocation>> GetMyLocations();
        Task<bool> AddLocations(LocationDto LoDto);
        Task<bool> DeleteLocation(long id);
    }
}
