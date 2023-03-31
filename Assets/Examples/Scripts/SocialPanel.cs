using InstantGamesBridge;
using InstantGamesBridge.Modules.Social;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class SocialPanel : MonoBehaviour
    {
        [SerializeField] private Text _isShareSupported;

        [SerializeField] private Text _isInviteFriendsSupported;

        [SerializeField] private Text _isJoinCommunitySupported;

        [SerializeField] private Text _isAddToFavoritesSupported;

        [SerializeField] private Text _isAddToHomeScreenSupported;

        [SerializeField] private Text _isCreatePostSupported;

        [SerializeField] private Text _isRateSupported;
        
        [SerializeField] private Text _isExternalLinksAllowed;

        [SerializeField] private Button _shareButton;

        [SerializeField] private Button _inviteFriendsButton;

        [SerializeField] private Button _joinCommunityButton;

        [SerializeField] private Button _addToFavoritesButton;

        [SerializeField] private Button _addToHomeScreenButton;

        [SerializeField] private Button _createPostButton;

        [SerializeField] private Button _rateButton;

        [SerializeField] private InputField _shareVkLinkInput;

        [SerializeField] private InputField _joinCommunityVkGroupIdInput;

        [SerializeField] private InputField _createPostVkMessageInput;

        [SerializeField] private InputField _createPostVkMessageAttachmentsInput;

        [SerializeField] private GameObject _overlay;

        private void Start()
        {
            _isShareSupported.text = $"Is Share Supported: { Bridge.social.isShareSupported }";
            _isInviteFriendsSupported.text = $"Is Invite Friends Supported: { Bridge.social.isInviteFriendsSupported }";
            _isJoinCommunitySupported.text = $"Is Join Community Supported: { Bridge.social.isJoinCommunitySupported }";
            _isAddToFavoritesSupported.text = $"Is Add To Favorites Supported: { Bridge.social.isAddToFavoritesSupported }";
            _isAddToHomeScreenSupported.text = $"Is Add To Home Screen Supported: { Bridge.social.isAddToHomeScreenSupported }";
            _isCreatePostSupported.text = $"Is Create Post Supported: { Bridge.social.isCreatePostSupported }";
            _isRateSupported.text = $"Is Rate Supported: { Bridge.social.isRateSupported }";
            _isExternalLinksAllowed.text = $"Is External Links Allowed: { Bridge.social.isExternalLinksAllowed }";

            _shareButton.onClick.AddListener(OnShareButtonClicked);
            _inviteFriendsButton.onClick.AddListener(OnInviteFriendsButtonClicked);
            _joinCommunityButton.onClick.AddListener(OnJoinCommunityButtonClicked);
            _addToFavoritesButton.onClick.AddListener(OnAddToFavoritesButtonClicked);
            _addToHomeScreenButton.onClick.AddListener(OnAddToHomeScreenButtonClicked);
            _createPostButton.onClick.AddListener(OnCreatePostButtonClicked);
            _rateButton.onClick.AddListener(OnRateButtonClicked);
        }

        private void OnShareButtonClicked()
        {
            _overlay.SetActive(true);

            Bridge.social.Share(
                success => { _overlay.SetActive(false); },
                new ShareVkOptions(_shareVkLinkInput.text));
        }

        private void OnInviteFriendsButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.social.InviteFriends(success => { _overlay.SetActive(false); });
        }

        private void OnJoinCommunityButtonClicked()
        {
            _overlay.SetActive(true);

            int.TryParse(_joinCommunityVkGroupIdInput.text, out var groupId);

            Bridge.social.JoinCommunity(
                success => { _overlay.SetActive(false); },
                new JoinCommunityVkOptions(groupId));
        }

        private void OnAddToFavoritesButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.social.AddToFavorites(success => { _overlay.SetActive(false); });
        }

        private void OnAddToHomeScreenButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.social.AddToHomeScreen(success => { _overlay.SetActive(false); });
        }

        private void OnCreatePostButtonClicked()
        {
            _overlay.SetActive(true);

            Bridge.social.CreatePost(
                success => { _overlay.SetActive(false); },
                new CreatePostVkOptions(_createPostVkMessageInput.text, _createPostVkMessageAttachmentsInput.text));
        }

        private void OnRateButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.social.Rate(success => { _overlay.SetActive(false); });
        }
    }
}