using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class SetMinimumDelayBetweenInterstitialCrazyGamesOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialCrazyGamesOptions(int seconds) : base(seconds)
        {
            _targetPlatformId = PlatformId.CrazyGames;
        }
    }
}