namespace payment_gatway_app.Model
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string Cvc { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd";
    }
}
