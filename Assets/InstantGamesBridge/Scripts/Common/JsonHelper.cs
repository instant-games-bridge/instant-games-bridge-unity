using System.Collections.Generic;
using InstantGamesBridge.Modules;

namespace InstantGamesBridge.Common
{
    public static class JsonHelper
    {
        public static string SurroundWithBraces(this string json)
        {
            return "{" + json + "}";
        }

        public static string SurroundWithKey(this string json, string key, bool quotes = false)
        {
            if (quotes)
            {
                json = "\"" + json + "\"";
            }
            
            return "\"" + key + "\":" + json;
        }

        public static string FixBooleans(this string json)
        {
            return json.Replace("True", "true").Replace("False", "false");
        }
        
        public static string ToJson(this PlatformDependedOptionsBase[] platformDependedOptions)
        {
            var json = string.Empty;
            var alreadyAddedPlatforms = new List<PlatformId>();

            for (var i = 0; i < platformDependedOptions.Length; i++)
            {
                var options = platformDependedOptions[i];
                var targetPlatform = options.GetTargetPlatform();

                if (alreadyAddedPlatforms.Contains(targetPlatform))
                {
                    continue;
                }

                if (i > 0 && i <= platformDependedOptions.Length - 1)
                {
                    json += ", ";
                }

                json += options.ToJson();
                alreadyAddedPlatforms.Add(targetPlatform);
            }

            return json;
        }
    }
}