#if UNITY_WEBGL
using InstantGamesBridge.Common;
using InstantGamesBridge.Modules.Advertisement;
using InstantGamesBridge.Modules.Device;
using InstantGamesBridge.Modules.Game;
using InstantGamesBridge.Modules.Storage;
using InstantGamesBridge.Modules.Leaderboard;
using InstantGamesBridge.Modules.Payments;
using InstantGamesBridge.Modules.Platform;
using InstantGamesBridge.Modules.Player;
using InstantGamesBridge.Modules.Social;

namespace InstantGamesBridge
{
    public class Bridge : Singleton<Bridge>
    {
        public static AdvertisementModule advertisement => instance._advertisement;
        public static GameModule game => instance._game;
        public static StorageModule storage => instance._storage; 
        public static PlatformModule platform => instance._platform; 
        public static SocialModule social => instance._social; 
        public static PlayerModule player => instance._player; 
        public static DeviceModule device => instance._device; 
        public static LeaderboardModule leaderboard => instance._leaderboard; 
        public static PaymentsModule payments => instance._payments; 

        private AdvertisementModule _advertisement;
        private GameModule _game;
        private StorageModule _storage;
        private PlatformModule _platform;
        private SocialModule _social;
        private PlayerModule _player;
        private DeviceModule _device;
        private LeaderboardModule _leaderboard;
        private PaymentsModule _payments;

        protected override void Awake()
        {
            base.Awake();
            _platform = new PlatformModule();
            _game = gameObject.AddComponent<GameModule>();
            _player = gameObject.AddComponent<PlayerModule>();
            _storage = gameObject.AddComponent<StorageModule>();
            _advertisement = gameObject.AddComponent<AdvertisementModule>();
            _social = gameObject.AddComponent<SocialModule>();
            _device = new DeviceModule();
            _leaderboard = gameObject.AddComponent<LeaderboardModule>();
            _payments = gameObject.AddComponent<PaymentsModule>();
        }
    }
}
#endif