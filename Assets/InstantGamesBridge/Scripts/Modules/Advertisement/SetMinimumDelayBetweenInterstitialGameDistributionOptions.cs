using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class SetMinimumDelayBetweenInterstitialGameDistributionOptions : SetMinimumDelayBetweenInterstitialPlatformDependedOptions
    {
        public SetMinimumDelayBetweenInterstitialGameDistributionOptions(int seconds) : base(seconds)
        {
            _targetPlatformId = PlatformId.GameDistribution;
        }
    }
}