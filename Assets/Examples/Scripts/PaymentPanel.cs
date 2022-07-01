using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using UnityEngine.UI;

namespace Example
{
    public class PaymentPanel : MonoBehaviour
    {
        [SerializeField] private Text _isSupported;

        [SerializeField] private InputField _getItemInput;

        [SerializeField] private GameObject _overlay;

        [SerializeField] private Button _showOrderPayment;

        private void OnEnable()
        {
            _isSupported.text = $"Is Supported: { Bridge.payment.isSupported }";

            _showOrderPayment.onClick.AddListener(OnShowPaymentsButtonClicked);
        }

        private void OnDisable()
        {
            _showOrderPayment.onClick.RemoveAllListeners();
        }

        private void showOrderPayment()
        {
            Bridge.payment.showOrderPayment("item1");
        }

        private void OnShowPaymentsButtonClicked()
        {
            _overlay.SetActive(true);
            // string.TryParse(_getItemInput.text, out var userResult);
            Bridge.payment.showOrderPayment(_getItemInput.text);
            _overlay.SetActive(false);
        }
    }
}
