using System.Collections.Generic;
using System.Text;
using InstantGamesBridge;
using InstantGamesBridge.Modules.RemoteConfig;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class RemoteConfigPanel : MonoBehaviour
    {
        [SerializeField] private Text _isSupportedText;
        [SerializeField] private Text _valuesText;
        [SerializeField] private Button _getButton;
        [SerializeField] private GameObject _overlay;

        private void Start()
        {
            _isSupportedText.text = $"Is Supported: { Bridge.remoteConfig.isSupported }";
            _getButton.onClick.AddListener(OnGetButtonClicked);
        }

        private void OnGetButtonClicked()
        {
            _overlay.SetActive(true);
            
            // variant 1
            Bridge.remoteConfig.Get(OnGetCompleted);
            
            // variant 2
            /*var clientFeatures = new List<RemoteConfigClientFeature>
            {
                new RemoteConfigClientFeature("client_feature_1", "test"),
                new RemoteConfigClientFeature("client_feature_2", "42"),
            };
            var yandexOptions = new RemoteConfigGetYandexOptions(clientFeatures);
            Bridge.remoteConfig.Get(yandexOptions, OnGetCompleted);*/
        }

        private void OnGetCompleted(bool success, List<RemoteConfigValue> values)
        {
            if (success)
            {
                var result = new StringBuilder();

                foreach (var remoteConfigValue in values)
                {
                    result.Append("name: " + remoteConfigValue.name + ", value: " + remoteConfigValue.value);
                }

                _valuesText.text = result.ToString();
            }
            
            _overlay.SetActive(false);
        }
    }
}