using System;
using System.Collections.Generic;
using CityBaseData.DataAccessComponents;
using CityBaseShared.DataTransferObjects;
namespace CityBaseBusiness.BusinessDomainComponents
{
    public class CountriesBDC
    {

        public CountriesData CountriesData { get; set; }
        public CountriesBDC()
        {
            CountriesData = new CountriesData();
        }

        //Get list of all countries
        public IList<CountryDTO> Get()
        {
            
            return CountriesData.Get();

        }

        //Get list of all states using a countryId
        public IList<StateDTO> Get(int countryId)
        {
            return CountriesData.Get(countryId);
        }
    }
}
