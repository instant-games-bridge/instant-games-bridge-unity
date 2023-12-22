using System;

namespace InstantGamesBridge.Modules.Payments
{
    [Serializable]
    public class PaymentsPurchaseData
    {
        public string id;
        public string token;

        public PaymentsPurchaseData(string id, string token)
        {
            this.id = id;
            this.token = token;
        }
    }
}