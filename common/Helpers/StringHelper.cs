using Newtonsoft.Json;

namespace CleanArchitecture.Common.Helpers;

public static class StringHelper
{
    private static JsonSerializerSettings JsonSerializerSettings
    {
        get
        {
            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return settings;
        }
    }
    public static string ToJsonString(this object data)
    {
        return JsonConvert.SerializeObject(data, JsonSerializerSettings);
    }
}
