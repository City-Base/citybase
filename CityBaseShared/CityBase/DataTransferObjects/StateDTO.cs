using System;
namespace CityBaseShared.DataTransferObjects
{
    public class StateDTO
    {
        public StateDTO()
        {
        }

        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
    }
}
