﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UITMBER.Models.UserFavouriteLocation
{
    public class LocationDto
    {
        public long UserId { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }
        public string Name { get; set; }

        public UserFavouriteLocation ToUFLocation()
        {
            return new UserFavouriteLocation
            {
                UserId = this.UserId,
                Name = this.Name,
                Lat = this.Lat,
                Long = this.Long
            };
        }
    }
}
