using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class SetMinimumDelayBetweenInterstitialYandexOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialYandexOptions(int seconds) : base(seconds)
        {
            _targetPlatformId = PlatformId.Yandex;
        }
    }
}