using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Social
{
    [Serializable]
    public class JoinCommunityVkOptions : JoinCommunityPlatformDependedOptions
    {
        public int groupId;

        public JoinCommunityVkOptions(int groupId)
        {
            _targetPlatformId = PlatformId.VK;
            this.groupId = groupId;
        }

        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}