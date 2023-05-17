using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialGameDistributionOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialGameDistributionOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatformId = PlatformId.GameDistribution;
        }
    }
}