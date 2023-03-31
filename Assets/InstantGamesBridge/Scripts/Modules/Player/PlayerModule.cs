#if UNITY_WEBGL
using System;
using System.Collections.Generic;
using UnityEngine;
#if !UNITY_EDITOR
using InstantGamesBridge.Common;
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Player
{
    public class PlayerModule : MonoBehaviour
    {
        public bool isAuthorizationSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsPlayerAuthorizationSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isAuthorized
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsPlayerAuthorized() == "true";
#else
                return false;
#endif
            }
        }

        public string id
        {
            get
            {
#if !UNITY_EDITOR
                var value = InstantGamesBridgePlayerId();
                if (string.IsNullOrEmpty(value)) {
                    return null;
                }

                return value;
#else
                return null;
#endif
            }
        }

        public new string name
        {
            get
            {
#if !UNITY_EDITOR
                var value = InstantGamesBridgePlayerName();
                if (string.IsNullOrEmpty(value)) {
                    return null;
                }

                return value;
#else
                return null;
#endif
            }
        }

        public List<string> photos
        {
            get
            {
#if !UNITY_EDITOR
                var json = InstantGamesBridgePlayerPhotos();
                if (string.IsNullOrEmpty(json)) {
                    return new List<string>();
                }
                
                try
                {
                    var photosContainer = JsonUtility.FromJson<PhotosContainer>(json.SurroundWithKey("photos").FixBooleans().SurroundWithBraces());
                    return photosContainer.photos;
                }
                catch (Exception e)
                {
                    return new List<string>();
                }
#else
                return new List<string>();
#endif
            }
        }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsPlayerAuthorizationSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsPlayerAuthorized();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgePlayerId();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgePlayerName();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgePlayerPhotos();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeAuthorizePlayer(string platformSpecifiedOptions);
#endif

        private Action<bool> _authorizationCallback;


        public void Authorize(Action<bool> onComplete = null, params AuthorizePlatformDependedOptions[] platformDependedOptions)
        {
            _authorizationCallback = onComplete;

#if !UNITY_EDITOR
            InstantGamesBridgeAuthorizePlayer(platformDependedOptions.ToJson());
#else
            OnAuthorizeCompleted("false");
#endif
        }


        // Called from JS
        private void OnAuthorizeCompleted(string result)
        {
            var isSuccess = result == "true";
            _authorizationCallback?.Invoke(isSuccess);
            _authorizationCallback = null;
        }

        // Unity's JsonUtility does only support objects as top level nodes
        [Serializable]
        private class PhotosContainer
        {
            public List<string> photos;
        }
    }
}
#endif