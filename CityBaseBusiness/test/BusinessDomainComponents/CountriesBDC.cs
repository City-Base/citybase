using System;
using System.Collections.Generic;
using CityBaseShared.DataTransferObjects;
namespace CityBaseBusiness.BusinessDomainComponents
{
    public class CountriesBDC
    {
        public CountriesBDC()
        {
        }

        //Get list of all countries
        public IEnumerable<CountryDTO> Get()
        {
            IList<CountryDTO> countries = new List<CountryDTO>();
            for(var i = 0; i<=5; i++)
            {
                var country = new CountryDTO {
                    CountryId = i,
                    CountryName = "Country" + i
                };
                countries.Add(country);
            }
            return countries;

        }

        //Get list of all states using a countryId
        public IEnumerable<StateDTO> Get(int countryId)
        {
            IList<StateDTO> states = new List<StateDTO>();
            for (var i = 0; i <= 5; i++)
            {
                var state = new StateDTO {
                    StateId = i,
                    CountryId = countryId,
                    StateName = "State" + i
                };
                states.Add(state);
            }
            return states;

        }
    }
}
