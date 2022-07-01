#if UNITY_WEBGL
using System;
using InstantGamesBridge.Common;
using InstantGamesBridge.Modules.Advertisement;
using InstantGamesBridge.Modules.Device;
using InstantGamesBridge.Modules.Game;
using InstantGamesBridge.Modules.Leaderboard;
using InstantGamesBridge.Modules.Platform;
using InstantGamesBridge.Modules.Player;
using InstantGamesBridge.Modules.Social;
using InstantGamesBridge.Modules.Payment;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge
{
    public class Bridge : Singleton<Bridge>
    {
        public static bool isInitialized { get; private set; }

        public static AdvertisementModule advertisement { get; private set; }

        public static GameModule game { get; private set; }

        public static PlatformModule platform { get; private set; }

        public static SocialModule social { get; private set; }

        public static PlayerModule player { get; private set; }

        public static DeviceModule device { get; private set; }

        public static LeaderboardModule leaderboard { get; private set; }

        public static PaymentModule payment { get; private set; }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeInitialize();
#endif

        private Action<bool> _initializationCallback;


        public static void Initialize(Action<bool> onComplete = null)
        {
            if (isInitialized)
            {
                onComplete?.Invoke(true);
                return;
            }

            instance._initializationCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeInitialize();
#else
            instance.OnInitializationCompleted("true");
#endif
        }


        // Called from JS
        private void OnInitializationCompleted(string result)
        {
            isInitialized = result == "true";

            if (isInitialized)
            {
                platform = new PlatformModule();
                player = gameObject.AddComponent<PlayerModule>();
                game = gameObject.AddComponent<GameModule>();
                advertisement = gameObject.AddComponent<AdvertisementModule>();
                social = gameObject.AddComponent<SocialModule>();
                device = new DeviceModule();
                leaderboard = gameObject.AddComponent<LeaderboardModule>();
                payment = gameObject.AddComponent<PaymentModule>();
            }

            _initializationCallback?.Invoke(isInitialized);
            _initializationCallback = null;
        }
    }
}
#endif