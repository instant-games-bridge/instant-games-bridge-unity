using System;
using InstantGamesBridge.Common;

namespace InstantGamesBridge.Modules
{
    [Serializable]
    public abstract class PlatformDependedOptionsBase
    {
        protected PlatformId _targetPlatformId;

        public PlatformId GetTargetPlatform()
        {
            return _targetPlatformId;
        }

        public string ToJson()
        {
            var platform = GetTargetPlatformString();
            return Serialize().FixBooleans().SurroundWithKey(platform).SurroundWithBraces();
        }

        public string GetTargetPlatformString()
        {
            switch (_targetPlatformId)
            {
                case PlatformId.Mock:
                    return "mock";
                
                case PlatformId.VK:
                    return "vk";

                case PlatformId.Yandex:
                    return "yandex";

                case PlatformId.CrazyGames:
                    return "crazy_games";
                
                case PlatformId.AbsoluteGames:
                    return "absolute_games";
                
                case PlatformId.GameDistribution:
                    return "game_distribution";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract string Serialize();
    }
}