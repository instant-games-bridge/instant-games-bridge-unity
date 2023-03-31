using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowInterstitialVkOptions : ShowInterstitialPlatformDependedOptions
    {
        public ShowInterstitialVkOptions(bool ignoreDelay) : base(ignoreDelay)
        {
            _targetPlatformId = PlatformId.VK;
        }
    }
}