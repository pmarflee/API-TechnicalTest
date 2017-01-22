using System;
using System.Collections.Generic;
using System.Linq;
using HotelAndLocationData.Models;
using Flurl;
using Flurl.Http;
using Flurl.Http.Xml;
using System.Threading.Tasks;

namespace HotelAndLocationData.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Region>> GetHotelAndLocationData(string regionName);
    }

    public class DataService : IDataService
    {
        private readonly string _baseUrl;
        private readonly string _username;
        private readonly string _password;

        public DataService(string baseUrl, string username, string password)
        {
            _baseUrl = baseUrl;
            _username = username;
            _password = password;
        }

        public async Task<IEnumerable<Region>> GetHotelAndLocationData(string regionName)
        {
            var token = await GetToken();

            var response = await _baseUrl
                .AppendPathSegment("Reference/HotelAndLocationData")
                .WithHeader("Authorization", $"TMS {token}")
                .GetXmlAsync<ApiHotelAndLocationQueryResponse>();

            return string.IsNullOrEmpty(regionName)
                ? response.Regions
                : response.Regions.Where(region => region.RegionCode.Equals(regionName, StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<string> GetToken()
        {
            var url = _baseUrl
                .AppendPathSegment("Authentication/Get")
                .SetQueryParams(new
                {
                    username = _username,
                    password = _password
                });

            return await url.GetStringAsync();
        }        
    }
}