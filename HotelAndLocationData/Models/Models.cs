using System.Collections.Generic;

namespace HotelAndLocationData.Models
{
    public class ApiHotelAndLocationQueryResponse
    {
        public List<Region> Regions { get; set; }
    }

    public class Region
    {
        public string RegionCode { get; set; }
        public string Name { get; set; }

        public List<Country> Countries { get; set; }
    }

    public class Country
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }

        public List<Resort> Resorts { get; set; }
    }

    public class Resort
    {
        public string ResortCode { get; set; }
        public string Name { get; set; }

        public List<Hotel> Hotels { get; set; }
        public List<Airport> Airports { get; set; }
    }

    public class Hotel
    {
        public string HotelCode { get; set; }
        public string Name { get; set; }
    }

    public class Airport
    {
        public string AirportCode { get; set; }
        public string Name { get; set; }
    }
}