using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class SetScoreYandexOptions : SetScorePlatformDependedOptions
    {
        public int score;

        public string leaderboardName;

        public SetScoreYandexOptions(int score, string leaderboardName)
        {
            _targetPlatformId = PlatformId.Yandex;
            this.score = score;
            this.leaderboardName = leaderboardName;
        }
        
        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}