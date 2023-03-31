using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Social
{
    [Serializable]
    public class ShareVkOptions : SharePlatformDependedOptions
    {
        public string link;

        public ShareVkOptions(string link)
        {
            _targetPlatformId = PlatformId.VK;
            this.link = link;
        }

        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}