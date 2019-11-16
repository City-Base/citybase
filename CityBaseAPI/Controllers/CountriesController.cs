using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CityBaseBusiness.BusinessDomainComponents;
using CityBaseShared.DataTransferObjects;

namespace CityBaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        // GET api/countries
        [HttpGet]
        public ActionResult<IEnumerable<CountryDTO>> Get()
        {
            var countriesBusiness = new CountriesBDC();
            var result = new ActionResult<IEnumerable<CountryDTO>>(countriesBusiness.Get());
            return result;
        }

        // GET api/countries/5
        [HttpGet("{countryId}")]
        public ActionResult<IEnumerable<StateDTO>> Get(int countryId)
        {
            var countriesBusiness = new CountriesBDC();
            var result = new ActionResult<IEnumerable<StateDTO>>(countriesBusiness.Get(countryId));
            return result;
        }

        // POST api/countries
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
