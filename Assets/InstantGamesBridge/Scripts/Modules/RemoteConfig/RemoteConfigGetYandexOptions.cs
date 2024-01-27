using System;
using System.Collections.Generic;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules.RemoteConfig
{
    [Serializable]
    public class RemoteConfigGetYandexOptions : RemoteConfigGetPlatformDependedOptions
    {
        public List<RemoteConfigClientFeature> clientFeatures;

        public RemoteConfigGetYandexOptions(List<RemoteConfigClientFeature> clientFeatures)
        {
            _targetPlatformId = PlatformId.Yandex;
            this.clientFeatures = clientFeatures;
        }

        protected override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}