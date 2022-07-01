using System;
using UnityEngine;

#if !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace InstantGamesBridge.Modules.Payment
{
    public class PaymentModule : MonoBehaviour
    {
#if !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string InstantGamesBridgeIsPaymentSupported();

        [DllImport("__Internal")]
        private static extern void InstantGamesBridgeShowOrderPayments(string title);
#endif

        public bool isSupported
        {
            get
            {
#if !UNITY_EDITOR
                return InstantGamesBridgeIsPaymentSupported() == "true";
#else
                return false;
#endif
            }
        }

        public void showOrderPayment(string title)
        {
#if !UNITY_EDITOR
            InstantGamesBridgeShowOrderPayments(title);
#endif
        }
    }
}