#if UNITY_WEBGL
using System;
using System.Collections.Generic;
using InstantGamesBridge.Common;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.RemoteConfig
{
    public class RemoteConfigModule : MonoBehaviour
    {
        public bool isSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsRemoteConfigSupported() == "true";
#else
                return false;
#endif
            }
        }
        
#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsRemoteConfigSupported();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeRemoteConfigGet(string options);
#endif
        private Action<bool, List<RemoteConfigValue>> _getCallback;

        
        public void Get(Action<bool, List<RemoteConfigValue>> onComplete)
        {
            _getCallback = onComplete;

#if !UNITY_EDITOR
            InstantGamesBridgeRemoteConfigGet("");
#else
            OnRemoteConfigGetFailed();
#endif
        }

        public void Get(RemoteConfigGetPlatformDependedOptions options, Action<bool, List<RemoteConfigValue>> onComplete)
        {
            _getCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeRemoteConfigGet(options.ToJson());
#else
            OnRemoteConfigGetFailed();
#endif
        }


        // Called from JS
        private void OnRemoteConfigGetSuccess(string result)
        {
            List<RemoteConfigValue> values;

            Debug.Log(result);
            
            try
            {
                var container = JsonUtility.FromJson<ValuesContainer>(result.SurroundWithKey("values").FixBooleans().SurroundWithBraces());
                values = container.values;
            }
            catch (Exception e)
            {
                values = new List<RemoteConfigValue>();
            }
            
            _getCallback?.Invoke(true, values);
        }

        private void OnRemoteConfigGetFailed()
        {
            _getCallback?.Invoke(false, null);
        }
        
        // Unity's JsonUtility does only support objects as top level nodes
        [Serializable]
        private class ValuesContainer
        {
            public List<RemoteConfigValue> values;
        }
    }
}
#endif