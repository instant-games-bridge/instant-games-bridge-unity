using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.Player
{
    [Serializable]
    public class AuthorizeYandexOptions : AuthorizePlatformDependedOptions
    {
        public bool scopes;

        public AuthorizeYandexOptions(bool scopes)
        {
            _targetPlatformId = PlatformId.Yandex;
            this.scopes = scopes;
        }

        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}