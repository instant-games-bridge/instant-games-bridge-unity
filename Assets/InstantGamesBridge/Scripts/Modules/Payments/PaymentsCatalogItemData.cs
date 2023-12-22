using System;

namespace InstantGamesBridge.Modules.Payments
{
    [Serializable]
    public class PaymentsCatalogItemData
    {
        public string id;
        public string title;
        public string description;
        public string icon;
        public string price;
        public string priceValue;
        public string priceCurrencyCode;

        public PaymentsCatalogItemData(string id, string title, string description, string icon, string price, string priceValue, string priceCurrencyCode)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.icon = icon;
            this.price = price;
            this.priceValue = priceValue;
            this.priceCurrencyCode = priceCurrencyCode;
        }
    }
}