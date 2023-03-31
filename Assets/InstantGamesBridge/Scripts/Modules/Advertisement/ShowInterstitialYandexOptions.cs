using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialYandexOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialYandexOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatformId = PlatformId.Yandex;
        }
    }
}