using System;
using System.Collections.Generic;
using InstantGamesBridge.Common;
using UnityEngine;
#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Payments
{
    public class PaymentsModule : MonoBehaviour
    {
        public bool isSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsPaymentsSupported() == "true";
#else
                return false;
#endif
            }
        }
        
#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsPaymentsSupported();
        
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgePaymentsPurchase(string id);

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgePaymentsConsumePurchase(string token);
        
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgePaymentsGetPurchases();
        
        [DllImport("__Internal")]
        private static extern void InstantGamesBridgePaymentsGetCatalog();
#endif
        
        private Action<bool> _purchaseCallback;
        private Action<bool> _consumePurchaseCallback;
        private Action<bool, List<PaymentsPurchaseData>> _getPurchasesCallback;
        private Action<bool, List<PaymentsCatalogItemData>> _getCatalogCallback;


        public void Purchase(string id, Action<bool> onComplete = null)
        {
            _purchaseCallback = onComplete;

#if !UNITY_EDITOR
            InstantGamesBridgePaymentsPurchase(id);
#else
            OnPaymentsPurchaseCompleted("false");
#endif
        }
        
        public void ConsumePurchase(string token, Action<bool> onComplete = null)
        {
            _consumePurchaseCallback = onComplete;

#if !UNITY_EDITOR
            InstantGamesBridgePaymentsConsumePurchase(token);
#else
            OnPaymentsConsumePurchaseCompleted("false");
#endif
        }
        
        public void GetPurchases(Action<bool, List<PaymentsPurchaseData>> onComplete = null)
        {
            _getPurchasesCallback = onComplete;

#if !UNITY_EDITOR
            InstantGamesBridgePaymentsGetPurchases();
#else
            OnPaymentsGetPurchasesCompletedFailed();
#endif
        }
        
        public void GetCatalog(Action<bool, List<PaymentsCatalogItemData>> onComplete = null)
        {
            _getCatalogCallback = onComplete;

#if !UNITY_EDITOR
            InstantGamesBridgePaymentsGetCatalog();
#else
            OnPaymentsGetCatalogCompletedFailed();
#endif
        }


        // Called from JS
        private void OnPaymentsPurchaseCompleted(string result)
        {
            var isSuccess = result == "true";
            _purchaseCallback?.Invoke(isSuccess);
            _purchaseCallback = null;
        }
        
        private void OnPaymentsConsumePurchaseCompleted(string result)
        {
            var isSuccess = result == "true";
            _consumePurchaseCallback?.Invoke(isSuccess);
            _consumePurchaseCallback = null;
        }
        
        private void OnPaymentsGetPurchasesCompletedSuccess(string result)
        {
            var purchases = new List<PaymentsPurchaseData>();

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    var container = JsonUtility.FromJson<PaymentsPurchasesContainer>(result.SurroundWithKey("purchases").SurroundWithBraces());
                    if (container != null && container.purchases.Count > 0)
                    {
                        purchases = container.purchases;
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }

            _getPurchasesCallback?.Invoke(true, purchases);
            _getPurchasesCallback = null;
        }

        private void OnPaymentsGetPurchasesCompletedFailed()
        {
            _getPurchasesCallback?.Invoke(false, null);
            _getPurchasesCallback = null;
        }
        
        private void OnPaymentsGetCatalogCompletedSuccess(string result)
        {
            var items = new List<PaymentsCatalogItemData>();

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    var container = JsonUtility.FromJson<PaymentsCatalogContainer>(result.SurroundWithKey("items").SurroundWithBraces());
                    if (container != null && container.items.Count > 0)
                    {
                        items = container.items;
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }

            _getCatalogCallback?.Invoke(true, items);
            _getCatalogCallback = null;
        }

        private void OnPaymentsGetCatalogCompletedFailed()
        {
            _getCatalogCallback?.Invoke(false, null);
            _getCatalogCallback = null;
        }
        
        
        // Unity's JsonUtility does only support objects as top level nodes
        [Serializable]
        private class PaymentsPurchasesContainer
        {
            public List<PaymentsPurchaseData> purchases;
        }
        
        [Serializable]
        private class PaymentsCatalogContainer
        {
            public List<PaymentsCatalogItemData> items;
        }
    }
}