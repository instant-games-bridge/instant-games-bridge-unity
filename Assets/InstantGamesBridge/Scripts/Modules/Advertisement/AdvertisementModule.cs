#if UNITY_WEBGL
using System;
using UnityEngine;
using InstantGamesBridge.Common;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Advertisement
{
    public class AdvertisementModule : MonoBehaviour
    {
        public event Action<BannerState> bannerStateChanged;
        
        public event Action<InterstitialState> interstitialStateChanged;

        public event Action<RewardedState> rewardedStateChanged;

        public BannerState bannerState { get; private set; } = BannerState.Hidden;

        public InterstitialState interstitialState { get; private set; } = InterstitialState.Closed;

        public RewardedState rewardedState { get; private set; } = RewardedState.Closed;

        public int minimumDelayBetweenInterstitial
        {
            get
            {
#if !UNITY_EDITOR
                int.TryParse(InstantGamesBridgeMinimumDelayBetweenInterstitial(), out int value);
                return value;
#else
                return _minimumDelayBetweenInterstitial;
#endif
            }
        }
        
        public bool isBannerSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsBannerSupported() == "true";
#else
                return false;
#endif
            }
        }
        
#if UNITY_EDITOR
        private int _minimumDelayBetweenInterstitial;

        private DateTime _lastInterstitialShownTimestamp = DateTime.MinValue;
#else
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeGetInterstitialState();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeMinimumDelayBetweenInterstitial();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeSetMinimumDelayBetweenInterstitial(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowInterstitial(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowRewarded();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsBannerSupported();
        
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowBanner(string options);
        
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeHideBanner();
#endif

        
        public void ShowBanner(params ShowBannerPlatformDependedOptions[] otherPlatformDependedOptions)
        {
#if !UNITY_EDITOR
            var options = otherPlatformDependedOptions.ToJson();
            InstantGamesBridgeShowBanner(options);
#else
            OnBannerStateChanged(BannerState.Loading.ToString());
            OnBannerStateChanged(BannerState.Shown.ToString());
#endif
        }

        public void HideBanner()
        {
#if !UNITY_EDITOR
            InstantGamesBridgeHideBanner();
#else
            OnBannerStateChanged(BannerState.Hidden.ToString());
#endif
        }


        public void SetMinimumDelayBetweenInterstitial(int seconds)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeSetMinimumDelayBetweenInterstitial(seconds.ToString());
#else
            _minimumDelayBetweenInterstitial = seconds;
#endif
        }

        public void SetMinimumDelayBetweenInterstitial(SetMinimumDelayBetweenInterstitialPlatformDependedOptions firstPlatformDependedOptions, params SetMinimumDelayBetweenInterstitialPlatformDependedOptions[] otherPlatformDependedOptions)
        {
#if !UNITY_EDITOR
            var options = firstPlatformDependedOptions.ToJson();
            var other = otherPlatformDependedOptions.ToJson();
            if (!string.IsNullOrEmpty(other)) {
                options += ", " + other;
                options.SurroundWithBraces();
            }

            InstantGamesBridgeSetMinimumDelayBetweenInterstitial(options);
#endif
        }

        public void ShowInterstitial(bool ignoreDelay = false)
        {
#if !UNITY_EDITOR
            var json = ignoreDelay.ToString().SurroundWithKey("ignoreDelay").FixBooleans().SurroundWithBraces();
            InstantGamesBridgeShowInterstitial(json);
#else
            var delta = DateTime.Now - _lastInterstitialShownTimestamp;
            if (delta.TotalSeconds > _minimumDelayBetweenInterstitial || ignoreDelay)
            {
                OnInterstitialStateChanged(InterstitialState.Loading.ToString());
                OnInterstitialStateChanged(InterstitialState.Opened.ToString());
                OnInterstitialStateChanged(InterstitialState.Closed.ToString());
            }
            else
            {
                OnInterstitialStateChanged(InterstitialState.Failed.ToString());
            }
#endif
        }

        public void ShowInterstitial(ShowInterstitialPlatformDependedOptions firstPlatformDependedOptions, params ShowInterstitialPlatformDependedOptions[] otherPlatformDependedOptions)
        {
#if !UNITY_EDITOR
            var options = firstPlatformDependedOptions.ToJson();
            var other = otherPlatformDependedOptions.ToJson();
            if (!string.IsNullOrEmpty(other)) {
                options += ", " + other;
                options.SurroundWithBraces();
            }

            InstantGamesBridgeShowInterstitial(options);
#else
            OnInterstitialStateChanged(InterstitialState.Loading.ToString());
            OnInterstitialStateChanged(InterstitialState.Opened.ToString());
            OnInterstitialStateChanged(InterstitialState.Closed.ToString());
#endif
        }

        public void ShowRewarded()
        {
#if !UNITY_EDITOR
            InstantGamesBridgeShowRewarded();
#else
            OnRewardedStateChanged(RewardedState.Loading.ToString());
            OnRewardedStateChanged(RewardedState.Opened.ToString());
            OnRewardedStateChanged(RewardedState.Rewarded.ToString());
            OnRewardedStateChanged(RewardedState.Closed.ToString());
#endif
        }


        private void Awake()
        {
#if !UNITY_EDITOR
            OnInterstitialStateChanged(InstantGamesBridgeGetInterstitialState());
#endif
        }
        
        private void OnBannerStateChanged(string value)
        {
            if (Enum.TryParse<BannerState>(value, true, out var state))
            {
                bannerState = state;
                bannerStateChanged?.Invoke(bannerState);
            }
        }

        private void OnInterstitialStateChanged(string value)
        {
            if (Enum.TryParse<InterstitialState>(value, true, out var state))
            {
                interstitialState = state;
                interstitialStateChanged?.Invoke(interstitialState);
                
#if UNITY_EDITOR
                if (interstitialState == InterstitialState.Closed)
                {
                    _lastInterstitialShownTimestamp = DateTime.Now;
                }
#endif
            }
        }

        private void OnRewardedStateChanged(string value)
        {
            if (Enum.TryParse<RewardedState>(value, true, out var state))
            {
                rewardedState = state;
                rewardedStateChanged?.Invoke(rewardedState);
            }
        }
    }
}
#endif