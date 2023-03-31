using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class ShowNativePopupVkOptions : ShowNativePopupPlatformDependedOptions
    {
        public int userResult;

        public bool global;

        public ShowNativePopupVkOptions(int userResult, bool global)
        {
            _targetPlatformId = PlatformId.VK;
            this.userResult = userResult;
            this.global = global;
        }
        
        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}