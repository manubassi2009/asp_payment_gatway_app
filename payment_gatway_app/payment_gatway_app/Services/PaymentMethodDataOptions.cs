using Stripe;

namespace payment_gatway_app.Services
{
    internal class PaymentMethodDataOptions : PaymentIntentPaymentMethodDataOptions
    {
        public string Type { get; set; }
        public object Card { get; set; }
    }
}