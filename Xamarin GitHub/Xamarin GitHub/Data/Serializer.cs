using Newtonsoft.Json;

namespace Xamarin_GitHub.Data
{
    public class Serializer<T>
    {
        public JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public T FromJson(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
        }

        public string ToJson(T data)
        {
            return JsonConvert.SerializeObject(data, JsonSerializerSettings);
        }
    }
}