using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialAbsoluteGamesOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialAbsoluteGamesOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatformId = PlatformId.AbsoluteGames;
        }
    }
}