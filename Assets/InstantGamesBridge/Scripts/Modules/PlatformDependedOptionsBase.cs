using System;
using InstantGamesBridge.Common;
using UnityEngine;

namespace InstantGamesBridge.Modules
{
    [Serializable]
    public abstract class PlatformDependedOptionsBase
    {
        protected OptionsTargetPlatform _targetPlatform;

        public OptionsTargetPlatform GetTargetPlatform()
        {
            return _targetPlatform;
        }

        public string ToJson()
        {
            var platform = GetTargetPlatformString();
            return JsonUtility.ToJson(this).SurroundWithKey(platform);
        }

        public string GetTargetPlatformString()
        {
            switch (_targetPlatform)
            {
                case OptionsTargetPlatform.VK:
                    return "vk";

                case OptionsTargetPlatform.Yandex:
                    return "yandex";

                case OptionsTargetPlatform.CrazyGames:
                    return "crazy_games";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}