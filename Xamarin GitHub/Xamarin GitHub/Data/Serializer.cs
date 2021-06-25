using Newtonsoft.Json;

namespace Xamarin_GitHub.Data
{
    public class Serializer<T>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public T FromJson(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        public string ToJson(T data)
        {
            return JsonConvert.SerializeObject(data, _jsonSerializerSettings);
        }
    }
}