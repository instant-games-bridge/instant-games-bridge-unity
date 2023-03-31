using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialCrazyGamesOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialCrazyGamesOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatformId = PlatformId.CrazyGames;
        }
    }
}