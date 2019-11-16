using System;
using System.Collections.Generic;

namespace CityBaseData.Models
{
    public partial class CityRatings
    {
        public int RatingId { get; set; }
        public int CityId { get; set; }
        public int? Month { get; set; }
        public int Rating { get; set; }
        public int Cost { get; set; }

        public Cities City { get; set; }
    }
}
