using System;

namespace InstantGamesBridge.Modules.RemoteConfig
{
    [Serializable]
    public class RemoteConfigClientFeature
    {
        public string name;
        public string value;

        public RemoteConfigClientFeature(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}