#if UNITY_WEBGL
using System;
using InstantGamesBridge.Common;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Platform
{
    public class PlatformModule
    {
#if !UNITY_EDITOR
        public PlatformId id 
        { 
            get
            {
                var platformId = InstantGamesBridgeGetPlatformId();

                switch (platformId)
                {
                    case "vk":
                        return PlatformId.VK;
                    
                    case "yandex":
                        return PlatformId.Yandex;
                    
                    case "crazy_games":
                        return PlatformId.CrazyGames;
                    
                    case "absolute_games":
                        return PlatformId.AbsoluteGames;

                    case "game_distribution":
                        return PlatformId.GameDistribution;
                    
                    default:
                        return PlatformId.Mock;
                }
            }
        }

        public string language { get; } = InstantGamesBridgeGetPlatformLanguage();

        public string payload { get; } = InstantGamesBridgeGetPlatformPayload();

        public string tld { get; } = InstantGamesBridgeGetPlatformTld();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformId();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformLanguage();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformPayload();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetPlatformTld();
        
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeSendMessageToPlatform(string message);
#else
        public PlatformId id => PlatformId.Mock;

        public string language => "en";

        public string payload => null;
        
        public string tld => null;
#endif

        public void SendMessage(PlatformMessage message)
        {
#if !UNITY_EDITOR
            var messageString = "";

            switch (message)
            {
                case PlatformMessage.GameReady:
                    messageString = "game_ready";
                    break;
                
                case PlatformMessage.InGameLoadingStarted:
                    messageString = "in_game_loading_started";
                    break;

                case PlatformMessage.InGameLoadingStopped:
                    messageString = "in_game_loading_stopped";
                    break;

                case PlatformMessage.GameplayStarted:
                    messageString = "gameplay_started";
                    break;

                case PlatformMessage.GameplayStopped:
                    messageString = "gameplay_stopped";
                    break;

                case PlatformMessage.PlayerGotAchievement:
                    messageString = "player_got_achievement";
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(message), message, null);
            }

            InstantGamesBridgeSendMessageToPlatform(messageString);
#endif
        }
    }
}
#endif