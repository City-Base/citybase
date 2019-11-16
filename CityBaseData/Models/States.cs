using System;
using System.Collections.Generic;

namespace CityBaseData.Models
{
    public partial class States
    {
        public States()
        {
            Cities = new HashSet<Cities>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

        public Countries Country { get; set; }
        public ICollection<Cities> Cities { get; set; }
    }
}
