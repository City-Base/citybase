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
        public CountriesController()
        {
            this.countriesBDC = new CountriesBDC();
        }

        public CountriesBDC countriesBDC { get; set; }

        // GET api/countries
        [HttpGet]
        public ActionResult<IList<CountryDTO>> Get()
        {
            var result = new ActionResult<IList<CountryDTO>>(countriesBDC.Get());
            return result;
        }

        // GET api/countries/5
        [HttpGet("{countryId}")]
        public ActionResult<IList<StateDTO>> Get(int countryId)
        {
            var result = new ActionResult<IList<StateDTO>>(countriesBDC.Get(countryId));
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
