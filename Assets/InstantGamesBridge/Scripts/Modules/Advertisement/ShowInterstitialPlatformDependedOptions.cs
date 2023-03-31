using System;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public abstract class ShowInterstitialPlatformDependedOptions : PlatformDependedOptionsBase
    {
        public bool ignoreDelay;

        protected ShowInterstitialPlatformDependedOptions(bool ignoreDelay)
        {
            this.ignoreDelay = ignoreDelay;
        }

        protected override string Serialize()
        {
            return ignoreDelay.ToString();
        }
    }
}