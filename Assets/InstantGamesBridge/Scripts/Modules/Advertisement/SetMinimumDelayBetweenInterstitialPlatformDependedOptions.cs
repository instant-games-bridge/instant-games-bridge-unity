using System;
using InstantGamesBridge.Common;

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
    
        public new string ToJson()
        {
            var platform = GetTargetPlatformString();
            return seconds.ToString().SurroundWithKey(platform);
        }
    }
}