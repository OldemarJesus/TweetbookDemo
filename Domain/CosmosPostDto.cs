using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace Tweetbook.Domain
{
    [CosmosCollection("posts")]
    public class CosmosPostDto
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
    }
}
