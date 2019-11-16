using System;
using System.Collections.Generic;

namespace CityBaseData.Models
{
    public partial class Countries
    {
        public Countries()
        {
            States = new HashSet<States>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ICollection<States> States { get; set; }
    }
}
