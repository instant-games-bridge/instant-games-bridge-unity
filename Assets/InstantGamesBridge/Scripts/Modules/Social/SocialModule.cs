#if UNITY_WEBGL
using System;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
using InstantGamesBridge.Common;
#endif

namespace InstantGamesBridge.Modules.Social
{
    public class SocialModule : MonoBehaviour
    {
        public bool isShareSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsShareSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isInviteFriendsSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsInviteFriendsSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isJoinCommunitySupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsJoinCommunitySupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isCreatePostSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsCreatePostSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isAddToHomeScreenSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsAddToHomeScreenSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isAddToFavoritesSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsAddToFavoritesSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isRateSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsRateSupported() == "true";
#else
                return false;
#endif
            }
        }
        
        public bool isExternalLinksAllowed
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsExternalLinksAllowed() == "true";
#else
                return false;
#endif
            }
        }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsShareSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsInviteFriendsSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsJoinCommunitySupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsCreatePostSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsAddToHomeScreenSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsAddToFavoritesSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsRateSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsExternalLinksAllowed();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShare(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeInviteFriends();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeJoinCommunity(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeCreatePost(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeAddToHomeScreen();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeAddToFavorites();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeRate();
#endif

        private Action<bool> _shareCallback;

        private Action<bool> _inviteFriendsCallback;

        private Action<bool> _joinCommunityCallback;

        private Action<bool> _createPostCallback;

        private Action<bool> _addToHomeScreenCallback;

        private Action<bool> _addToFavoritesCallback;

        private Action<bool> _rateCallback;


        public void Share(Action<bool> onComplete, params SharePlatformDependedOptions[] platformDependedOptions)
        {
            _shareCallback = onComplete;
            Share(platformDependedOptions);
        }

        public void Share(params SharePlatformDependedOptions[] platformDependedOptions)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeShare(platformDependedOptions.ToJson());
#else
            OnShareCompleted("false");
#endif
        }

        public void InviteFriends(Action<bool> onComplete = null)
        {
            _inviteFriendsCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeInviteFriends();
#else
            OnInviteFriendsCompleted("false");
#endif
        }

        public void JoinCommunity(Action<bool> onComplete, params JoinCommunityPlatformDependedOptions[] platformDependedOptions)
        {
            _joinCommunityCallback = onComplete;
            JoinCommunity(platformDependedOptions);
        }

        public void JoinCommunity(params JoinCommunityPlatformDependedOptions[] platformDependedOptions)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeJoinCommunity(platformDependedOptions.ToJson());
#else
            OnJoinCommunityCompleted("false");
#endif
        }

        public void CreatePost(Action<bool> onComplete, params CreatePostPlatformDependedOptions[] platformDependedOptions)
        {
            _createPostCallback = onComplete;
            CreatePost(platformDependedOptions);
        }

        public void CreatePost(params CreatePostPlatformDependedOptions[] platformDependedOptions)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeCreatePost(platformDependedOptions.ToJson());
#else
            OnCreatePostCompleted("false");
#endif
        }

        public void AddToHomeScreen(Action<bool> onComplete = null)
        {
            _addToHomeScreenCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeAddToHomeScreen();
#else
            OnAddToHomeScreenCompleted("false");
#endif
        }

        public void AddToFavorites(Action<bool> onComplete = null)
        {
            _addToFavoritesCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeAddToFavorites();
#else
            OnAddToFavoritesCompleted("false");
#endif
        }

        public void Rate(Action<bool> onComplete = null)
        {
            _rateCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeRate();
#else
            OnRateCompleted("false");
#endif
        }


        // Called from JS
        private void OnShareCompleted(string result)
        {
            var isSuccess = result == "true";
            _shareCallback?.Invoke(isSuccess);
            _shareCallback = null;
        }

        private void OnInviteFriendsCompleted(string result)
        {
            var isSuccess = result == "true";
            _inviteFriendsCallback?.Invoke(isSuccess);
            _inviteFriendsCallback = null;
        }

        private void OnJoinCommunityCompleted(string result)
        {
            var isSuccess = result == "true";
            _joinCommunityCallback?.Invoke(isSuccess);
            _joinCommunityCallback = null;
        }

        private void OnCreatePostCompleted(string result)
        {
            var isSuccess = result == "true";
            _createPostCallback?.Invoke(isSuccess);
            _createPostCallback = null;
        }

        private void OnAddToHomeScreenCompleted(string result)
        {
            var isSuccess = result == "true";
            _addToHomeScreenCallback?.Invoke(isSuccess);
            _addToHomeScreenCallback = null;
        }

        private void OnAddToFavoritesCompleted(string result)
        {
            var isSuccess = result == "true";
            _addToFavoritesCallback?.Invoke(isSuccess);
            _addToFavoritesCallback = null;
        }

        private void OnRateCompleted(string result)
        {
            var isSuccess = result == "true";
            _rateCallback?.Invoke(isSuccess);
            _rateCallback = null;
        }
    }
}
#endif