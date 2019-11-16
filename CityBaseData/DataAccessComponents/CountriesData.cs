using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBaseData.Models;
using CityBaseShared.DataTransferObjects;

namespace CityBaseData.DataAccessComponents
{
    public class CountriesData
    {
        public CountriesData()
        {
            this.__context__ = new CityBaseContext();
        }

        private CityBaseContext __context__ { get; set; }

        public IList<CountryDTO> Get()
        {
            return __context__.Countries
                .Select(c => new CountryDTO
                    {
                        CountryId = c.CountryId,
                        CountryName = c.CountryName
                    })
                .ToList();
        }

        public IList<StateDTO> Get(int countryId)
        {
            return __context__.States
                .Where(s => s.CountryId == countryId)
                .Select(s => new StateDTO
                    {
                        StateId = s.StateId,
                        StateName = s.StateName,
                        CountryId = s.CountryId
                    })
                .ToList();
        }

    }
}
