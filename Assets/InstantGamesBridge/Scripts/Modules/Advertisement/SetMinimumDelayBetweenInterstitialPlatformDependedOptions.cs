using System;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public abstract class SetMinimumDelayBetweenInterstitialPlatformDependedOptions : PlatformDependedOptionsBase
    {
        public int seconds;

        protected SetMinimumDelayBetweenInterstitialPlatformDependedOptions(int seconds)
        {
            this.seconds = seconds;
        }

        protected override string Serialize()
        {
            return seconds.ToString();
        }
    }
}