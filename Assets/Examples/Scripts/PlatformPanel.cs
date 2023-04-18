using InstantGamesBridge;
using InstantGamesBridge.Modules.Platform;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class PlatformPanel : MonoBehaviour
    {
        [SerializeField] private Text _id;

        [SerializeField] private Text _language;

        [SerializeField] private Text _payload;
        
        [SerializeField] private Text _tld;

        [SerializeField] private Button _sendGameReadyMessageButton;
        
        [SerializeField] private Button _sendInGameLoadingStartedMessageButton;
        
        [SerializeField] private Button _sendInGameLoadingStoppedMessageButton;
        
        [SerializeField] private Button _sendGameplayStartedMessageButton;
        
        [SerializeField] private Button _sendGameplayStoppedMessageButton;
        
        [SerializeField] private Button _sendPlayerGotAchievementMessageButton;

        private void Start()
        {
            _id.text = $"ID: { Bridge.platform.id }";
            _language.text = $"Language: { Bridge.platform.language }";
            _payload.text = $"Payload: { Bridge.platform.payload }";
            _tld.text = $"TLD: { Bridge.platform.tld }";
            
            _sendGameReadyMessageButton.onClick.AddListener(OnSendGameReadyMessageButtonClicked);
            _sendInGameLoadingStartedMessageButton.onClick.AddListener(OnSendInGameLoadingStartedMessageButtonClicked);
            _sendInGameLoadingStoppedMessageButton.onClick.AddListener(OnSendInGameLoadingStoppedMessageButtonClicked);
            _sendGameplayStartedMessageButton.onClick.AddListener(OnSendGameplayStartedMessageButtonClicked);
            _sendGameplayStoppedMessageButton.onClick.AddListener(OnSendGameplayStoppedMessageButtonClicked);
            _sendPlayerGotAchievementMessageButton.onClick.AddListener(OnSendPlayerGotAchievementMessageButtonClicked);
        }

        private void OnSendGameReadyMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameReady);
        }

        private void OnSendInGameLoadingStartedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.InGameLoadingStarted);
        }
        
        private void OnSendInGameLoadingStoppedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.InGameLoadingStopped);
        }
        
        private void OnSendGameplayStartedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameplayStarted);
        }
        
        private void OnSendGameplayStoppedMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.GameplayStopped);
        }
        
        private void OnSendPlayerGotAchievementMessageButtonClicked()
        {
            Bridge.platform.SendMessage(PlatformMessage.PlayerGotAchievement);
        }
    }
}