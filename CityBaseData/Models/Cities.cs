using System;
using System.Collections.Generic;

namespace CityBaseData.Models
{
    public partial class Cities
    {
        public Cities()
        {
            CityRatings = new HashSet<CityRatings>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityDescription { get; set; }
        public int StateId { get; set; }
        public string ImageUrl { get; set; }

        public States State { get; set; }
        public ICollection<CityRatings> CityRatings { get; set; }
    }
}
