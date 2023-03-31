#if UNITY_WEBGL
using System;
using System.Collections.Generic;
using InstantGamesBridge.Common;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Leaderboard
{
    public class LeaderboardModule : MonoBehaviour
    {
        public bool isSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsLeaderboardSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isNativePopupSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsLeaderboardNativePopupSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isMultipleBoardsSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsLeaderboardMultipleBoardsSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isSetScoreSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsLeaderboardSetScoreSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isGetScoreSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsLeaderboardGetScoreSupported() == "true";
#else
                return false;
#endif
            }
        }

        public bool isGetEntriesSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsLeaderboardGetEntriesSupported() == "true";
#else
                return false;
#endif
            }
        }

#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsLeaderboardSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsLeaderboardNativePopupSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsLeaderboardMultipleBoardsSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsLeaderboardSetScoreSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsLeaderboardGetScoreSupported();

        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsLeaderboardGetEntriesSupported();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeLeaderboardSetScore(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeLeaderboardGetScore(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeLeaderboardGetEntries(string options);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeLeaderboardShowNativePopup(string options);
#endif

        private Action<bool> _setScoreCallback;

        private Action<bool, int> _getScoreCallback;

        private Action<bool, List<LeaderboardEntry>> _getEntriesCallback;

        private Action<bool> _showNativePopupCallback;


        public void SetScore(Action<bool> onComplete, params SetScorePlatformDependedOptions[] platformDependedOptions)
        {
            _setScoreCallback = onComplete;
            SetScore(platformDependedOptions);
        }

        public void SetScore(params SetScorePlatformDependedOptions[] platformDependedOptions)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeLeaderboardSetScore(platformDependedOptions.ToJson());
#else
            OnLeaderboardSetScoreCompleted("false");
#endif
        }

        public void GetScore(Action<bool, int> onComplete, params GetScorePlatformDependedOptions[] platformDependedOptions)
        {
            _getScoreCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeLeaderboardGetScore(platformDependedOptions.ToJson());
#else
            OnLeaderboardGetScoreCompleted("false");
#endif
        }

        public void GetEntries(Action<bool, List<LeaderboardEntry>> onComplete, params GetEntriesPlatformDependedOptions[] platformDependedOptions)
        {
            _getEntriesCallback = onComplete;
#if !UNITY_EDITOR
            InstantGamesBridgeLeaderboardGetEntries(platformDependedOptions.ToJson());
#else
            OnLeaderboardGetEntriesCompletedSuccess("false");
#endif
        }

        public void ShowNativePopup(Action<bool> onComplete, params ShowNativePopupPlatformDependedOptions[] platformDependedOptions)
        {
            _showNativePopupCallback = onComplete;
            ShowNativePopup(platformDependedOptions);
        }

        public void ShowNativePopup(params ShowNativePopupPlatformDependedOptions[] platformDependedOptions)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeLeaderboardShowNativePopup(platformDependedOptions.ToJson());
#else
            OnLeaderboardShowNativePopupCompleted("false");
#endif
        }


        // Called from JS
        private void OnLeaderboardSetScoreCompleted(string result)
        {
            var isSuccess = result == "true";
            _setScoreCallback?.Invoke(isSuccess);
            _setScoreCallback = null;
        }

        private void OnLeaderboardGetScoreCompleted(string result)
        {
            var isSuccess = result != "false";
            var score = 0;

            if (isSuccess)
            {
                int.TryParse(result, out score);
            }

            _getScoreCallback?.Invoke(isSuccess, score);
            _getScoreCallback = null;
        }

        private void OnLeaderboardGetEntriesCompletedSuccess(string result)
        {
            var entries = new List<LeaderboardEntry>();

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    var entriesContainer = JsonUtility.FromJson<EntriesContainer>(result.SurroundWithKey("entries").SurroundWithBraces());
                    if (entriesContainer != null && entriesContainer.entries.Count > 0)
                    {
                        entries = entriesContainer.entries;
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }

            _getEntriesCallback?.Invoke(true, entries);
            _getEntriesCallback = null;
        }

        private void OnLeaderboardGetEntriesCompletedFailed()
        {
            _getEntriesCallback?.Invoke(false, null);
            _getEntriesCallback = null;
        }

        private void OnLeaderboardShowNativePopupCompleted(string result)
        {
            var isSuccess = result == "true";
            _showNativePopupCallback?.Invoke(isSuccess);
            _showNativePopupCallback = null;
        }


        // Unity's JsonUtility does only support objects as top level nodes
        [Serializable]
        private class EntriesContainer
        {
            public List<LeaderboardEntry> entries;
        }
    }
}
#endif