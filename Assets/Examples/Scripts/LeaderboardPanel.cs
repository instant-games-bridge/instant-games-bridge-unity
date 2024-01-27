using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class LeaderboardPanel : MonoBehaviour
    {
        [SerializeField] private Text _isSupported;
        [SerializeField] private Text _isNativePopupSupported;
        [SerializeField] private Text _isMultipleBoardsSupported;
        [SerializeField] private Text _isSetScoreSupported;
        [SerializeField] private Text _isGetScoreSupported;
        [SerializeField] private Text _isGetEntriesSupported;
        [SerializeField] private InputField _showNativePopupVkUserResult;
        [SerializeField] private Toggle _showNativePopupVkGlobalToggle;
        [SerializeField] private Button _showNativePopupButton;
        [SerializeField] private InputField _yandexLeaderboardNameInput;
        [SerializeField] private InputField _getSetScoreYandexScoreInput;
        [SerializeField] private Button _setScoreButton;
        [SerializeField] private Button _getScoreButton;
        [SerializeField] private Toggle _getEntriesYandexIncludeUserToggle;
        [SerializeField] private InputField _getEntriesYandexQuantityAroundInput;
        [SerializeField] private InputField _getEntriesYandexQuantityTopInput;
        [SerializeField] private Button _getEntriesButton;
        [SerializeField] private Text _entriesContainer;
        [SerializeField] private GameObject _overlay;

        private void Start()
        {
            _isSupported.text = $"Is Supported: { Bridge.leaderboard.isSupported }";
            _isNativePopupSupported.text = $"Is Native Popup Supported: { Bridge.leaderboard.isNativePopupSupported }";
            _isMultipleBoardsSupported.text = $"Is Multiple Boards Supported: { Bridge.leaderboard.isMultipleBoardsSupported }";
            _isSetScoreSupported.text = $"Is Set Score Supported: { Bridge.leaderboard.isSetScoreSupported }";
            _isGetScoreSupported.text = $"Is Get Score Supported: { Bridge.leaderboard.isGetScoreSupported }";
            _isGetEntriesSupported.text = $"Is Get Entries Supported: { Bridge.leaderboard.isGetEntriesSupported }";

            _showNativePopupButton.onClick.AddListener(OnShowNativePopupButtonClicked);
            _setScoreButton.onClick.AddListener(OnSetScoreButtonClicked);
            _getScoreButton.onClick.AddListener(OnGetScoreButtonClicked);
            _getEntriesButton.onClick.AddListener(OnGetEntriesButtonClicked);
        }

        private void OnShowNativePopupButtonClicked()
        {
            _overlay.SetActive(true);

            int.TryParse(_showNativePopupVkUserResult.text, out var userResult);

            Bridge.leaderboard.ShowNativePopup(
                success => { _overlay.SetActive(false); },
                new ShowNativePopupVkOptions(userResult, _showNativePopupVkGlobalToggle.isOn));
        }

        private void OnSetScoreButtonClicked()
        {
            _overlay.SetActive(true);

            int.TryParse(_getSetScoreYandexScoreInput.text, out var score);

            Bridge.leaderboard.SetScore(
                success => { _overlay.SetActive(false); },
                new SetScoreYandexOptions(score, _yandexLeaderboardNameInput.text));
        }

        private void OnGetScoreButtonClicked()
        {
            _overlay.SetActive(true);
            _getSetScoreYandexScoreInput.text = string.Empty;

            Bridge.leaderboard.GetScore(
                (success, score) =>
                {
                    if (success)
                    {
                        _getSetScoreYandexScoreInput.text = score.ToString();
                    }

                    _overlay.SetActive(false);
                },
                new GetScoreYandexOptions(_yandexLeaderboardNameInput.text));
        }

        private void OnGetEntriesButtonClicked()
        {
            _overlay.SetActive(true);

            int.TryParse(_getEntriesYandexQuantityAroundInput.text, out var quantityAround);
            int.TryParse(_getEntriesYandexQuantityTopInput.text, out var quantityTop);

            var yandexOptions = new GetEntriesYandexOptions(
                _yandexLeaderboardNameInput.text,
                _getEntriesYandexIncludeUserToggle.isOn,
                quantityTop,
                quantityAround);

            Bridge.leaderboard.GetEntries(
                (success, entries) =>
                {
                    if (success)
                    {
                        var text = "Entries:";

                        foreach (var entry in entries)
                        {
                            text += $"\n ID: {entry.id}, name: {entry.name}, score: {entry.score}, rank: {entry.rank}";
                        }

                        _entriesContainer.text = text;
                    }

                    _overlay.SetActive(false);
                },
                yandexOptions);
        }
    }
}