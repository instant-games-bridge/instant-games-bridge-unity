using InstantGamesBridge;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class PaymentsPanel : MonoBehaviour
    {
        [SerializeField] private Text _isSupported;
        
        [SerializeField] private Button _getCatalogButton;
        [SerializeField] private Button _getPurchasesButton;

        [SerializeField] private InputField _purchaseIdInput;
        [SerializeField] private Button _purchaseButton;

        [SerializeField] private InputField _purchaseTokenInput;
        [SerializeField] private Button _consumePurchaseButton;

        [SerializeField] private GameObject _overlay;

        private void Start()
        {
            _isSupported.text = $"Is Supported: { Bridge.payments.isSupported }";
            _getCatalogButton.onClick.AddListener(OnGetCatalogButtonClicked);
            _getPurchasesButton.onClick.AddListener(OnGetPurchasesButtonClicked);
            _purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
            _consumePurchaseButton.onClick.AddListener(OnConsumePurchaseButtonClicked);
        }

        private void OnGetCatalogButtonClicked()
        {
            _overlay.SetActive(true);

            Bridge.payments.GetCatalog((success, list) =>
            {
                if (success)
                {
                    foreach (var catalogItemData in list)
                    {
                        var itemText = $"\n ID: {catalogItemData.id}, title: {catalogItemData.title}, description: {catalogItemData.description}, icon: {catalogItemData.icon}, price: {catalogItemData.price}, priceValue: {catalogItemData.priceValue}, priceCurrencyCode: {catalogItemData.priceCurrencyCode}";
                        Debug.Log(itemText);
                    }
                }
                
                _overlay.SetActive(false);
            });
        }

        private void OnGetPurchasesButtonClicked()
        {
            _overlay.SetActive(true);

            Bridge.payments.GetPurchases((success, list) =>
            {
                if (success)
                {
                    foreach (var purchaseData in list)
                    {
                        var purchaseText = $"\n ID: {purchaseData.id}, token: {purchaseData.token}";
                        Debug.Log(purchaseText);
                    }
                }
                
                _overlay.SetActive(false);
            });
        }
        
        private void OnPurchaseButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.payments.Purchase(_purchaseIdInput.text, success => { _overlay.SetActive(false); });
        }

        private void OnConsumePurchaseButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.payments.ConsumePurchase(_purchaseTokenInput.text, success => { _overlay.SetActive(false); });
        }
    }
}