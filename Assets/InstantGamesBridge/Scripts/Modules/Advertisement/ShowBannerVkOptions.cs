using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules.Advertisement
{
    [Serializable]
    public class ShowBannerVkOptions : ShowBannerPlatformDependedOptions
    {
        public VkBannerPosition position;

        public ShowBannerVkOptions(VkBannerPosition position)
        {
            _targetPlatformId = PlatformId.VK;
            this.position = position;
        }

        protected override string Serialize()
        {
            return position.ToString().ToLower().SurroundWithKey("position", true).SurroundWithBraces();
        }
    }
}