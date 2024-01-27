using System.Collections;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Player;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Examples
{
    public class PlayerPanel : MonoBehaviour
    {
        [SerializeField] private Text _isAuthorizationSupported;
        [SerializeField] private Text _isAuthorized;
        [SerializeField] private Text _id;
        [SerializeField] private Text _name;
        [SerializeField] private Image _photo;
        [SerializeField] private Toggle _authorizeYandexScopesOption;
        [SerializeField] private Button _authorizeButton;
        [SerializeField] private GameObject _overlay;

        private void Start()
        {
            UpdateValues();
            _overlay.SetActive(false);
            _authorizeButton.onClick.AddListener(OnAuthorizeButtonClicked);
        }

        private void OnAuthorizeButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.player.Authorize(OnAuthorizePlayerCompleted, new AuthorizeYandexOptions(_authorizeYandexScopesOption.isOn));
        }

        private void OnAuthorizePlayerCompleted(bool success)
        {
            UpdateValues();
            _overlay.SetActive(false);
        }

        private void UpdateValues()
        {
            _isAuthorizationSupported.text = $"Is Authorization Supported: { Bridge.player.isAuthorizationSupported }";
            _isAuthorized.text = $"Is Authorized: { Bridge.player.isAuthorized }";
            _id.text = $"ID: { Bridge.player.id }";
            _name.text = $"Name: { Bridge.player.name }";

            if (Bridge.player.photos.Count > 0)
            {
                StartCoroutine(LoadPhoto(Bridge.player.photos[0]));
            }
        }

        private IEnumerator LoadPhoto(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                _photo.sprite = sprite;
            }
        }
    }
}