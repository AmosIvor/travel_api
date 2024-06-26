﻿using travel_api.Models.EF;

namespace travel_api.ViewModels.Responses.EFViewModel
{
    public class LocationBaseVM
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime LocationOpenTime { get; set; }

        public decimal LocationLongtitude { get; set; }

        public decimal LocationLatitude { get; set; }

        public decimal LocationRateAverage { get; set; }

        public string LocationDescription { get; set; }

        public int CityId { get; set; }
    }

    public class LocationVM : LocationBaseVM
    {
        public ICollection<PostBaseVM>? Posts { get; set; }

        public ICollection<FeedbackBaseVM>? Feedbacks { get; set; }

        public ICollection<LocationMediaBaseVM>? LocationMedias { get; set; }

        public Dictionary<int, int>? RatingStatistic { get; set; }

        public CityBaseVM? City { get; set; }

        public ICollection<PlanDetail>? PlanDetails { get; set; }
    }

    public class LocationBaseWithCityVM : LocationBaseVM
    {
        public string CityName { get; set; }

        public ICollection<LocationMediaBaseVM>? LocationMedias { get; set; }
    }
}
