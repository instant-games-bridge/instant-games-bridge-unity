using System;

namespace InstantGamesBridge.Modules.RemoteConfig
{
    [Serializable]
    public class RemoteConfigValue
    {
        public string name;
        public string value;

        public RemoteConfigValue(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}