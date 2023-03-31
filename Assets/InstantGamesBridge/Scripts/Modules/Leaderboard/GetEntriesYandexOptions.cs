using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Leaderboard
{
    [Serializable]
    public class GetEntriesYandexOptions : GetEntriesPlatformDependedOptions
    {
        public string leaderboardName;

        public bool includeUser;

        public int quantityTop;

        public int quantityAround;

        public GetEntriesYandexOptions(string leaderboardName, bool includeUser = false, int quantityTop = 5, int quantityAround = 5)
        {
            _targetPlatformId = PlatformId.Yandex;
            this.leaderboardName = leaderboardName;
            this.includeUser = includeUser;
            this.quantityTop = quantityTop;
            this.quantityAround = quantityAround;
        }

        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}