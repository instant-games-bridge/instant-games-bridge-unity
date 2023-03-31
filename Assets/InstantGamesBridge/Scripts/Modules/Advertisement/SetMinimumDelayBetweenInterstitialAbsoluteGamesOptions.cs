using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class SetMinimumDelayBetweenInterstitialAbsoluteGamesOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialAbsoluteGamesOptions(int seconds) : base(seconds)
        {
            _targetPlatformId = PlatformId.AbsoluteGames;
        }
    }
}