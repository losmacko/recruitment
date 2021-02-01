using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Recruitment.ApiGateway.Models;
using Recruitment.Common;
using Recruitment.Common.Models;

namespace Recruitment.ApiGateway.Services
{
    public class WebApi : IWebApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppConfig _appConfig;

        public WebApi(IHttpClientFactory httpClientFactory, IOptions<AppConfig> optionConfig)
        {
            _httpClientFactory = httpClientFactory;
            _appConfig = optionConfig.Value;
        }

        public async Task<HashResponse> GetHashCode(LoginDataRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(_appConfig.HashFunction, request);

            response.EnsureSuccessStatusCode();

            var hash = await response.Content.ReadFromJsonAsync<HashResponse>();
            return hash;
        }
    }
}
