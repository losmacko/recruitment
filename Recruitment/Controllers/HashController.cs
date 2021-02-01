using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Recruitment.Common.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Options;
using Recruitment.ApiGateway.Models;
using Recruitment.ApiGateway.Services;
using Recruitment.Common;

namespace Recruitment.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        private readonly IWebApi _webApi;

        public HashController(IWebApi webApi)
        {
            _webApi = webApi;
        }
        
        /// <summary>
        /// Generate Md5 data
        /// </summary>
        /// <param name="loginDataRequest">Login model.</param>
        /// <returns>Hash using Md5</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HashResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateHash(LoginDataRequest loginDataRequest)
        {
            var hash = await _webApi.GetHashCode(loginDataRequest);
            return Ok(hash);
        }
    }
}
