using System.Text.Json.Serialization;

namespace Recruitment.Common
{
    public class HashResponse
    {
        /// <summary>
        /// Hash data unsing Md5
        /// </summary>
        [JsonPropertyName("hash_value")]
        public string Hash { get; set; }
    }
}
