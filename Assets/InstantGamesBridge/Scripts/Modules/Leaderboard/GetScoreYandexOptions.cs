using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class GetScoreYandexOptions : GetScorePlatformDependedOptions
    {
        public string leaderboardName;

        public GetScoreYandexOptions(string leaderboardName)
        {
            _targetPlatformId = PlatformId.Yandex;
            this.leaderboardName = leaderboardName;
        }
        
        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}