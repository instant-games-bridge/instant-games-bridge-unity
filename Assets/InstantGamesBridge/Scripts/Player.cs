﻿#if UNITY_WEBGL
using System;
using System.Collections.Generic;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace MewtonGames
{
    public class Player : MonoBehaviour
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
                if (string.IsNullOrEmpty(value))
                    return null;

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
                if (string.IsNullOrEmpty(value))
                    return null;

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
                if (string.IsNullOrEmpty(json))
                    return new List<string>();
                
                try
                {
                    json = "{\"photos\":" + json + "}";
                    var photosContainer = JsonUtility.FromJson<PhotosContainer>(json);
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
        private static extern void InstantGamesBridgeAuthorizePlayer();
#endif

        private Action<bool> _authorizationCallback;


        public void Authorize(Action<bool> onComplete = null)
        {
            _authorizationCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeAuthorizePlayer();
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
        private class PhotosContainer
        {
            public List<string> photos;
        }
    }
}
#endif