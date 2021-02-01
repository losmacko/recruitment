using System.Threading.Tasks;
using Recruitment.Common;
using Recruitment.Common.Models;

namespace Recruitment.ApiGateway.Services
{
    public interface IWebApi
    {
        Task<HashResponse> GetHashCode(LoginDataRequest request);
    }
}