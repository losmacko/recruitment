using Recruitment.Common.Models;

namespace Recruitment.HashFunction.Services
{
    public interface IHash
    {
        string GenerateHash(LoginDataRequest logindata);
    }
}