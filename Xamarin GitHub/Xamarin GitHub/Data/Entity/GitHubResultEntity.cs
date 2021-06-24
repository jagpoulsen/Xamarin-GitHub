using System.Collections.Generic;
using Newtonsoft.Json;

namespace Xamarin_GitHub.Data.Entity
{
    public class GitHubResultEntity
    {
        [JsonProperty("total_count")]
        public int TotalCount;

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults;

        [JsonProperty("items")]
        public List<GitHubUserEntity> Items;
    }
}