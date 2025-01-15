using payment_gatway_app.Model;
using Stripe;

namespace payment_gatway_app.Services
{
    public class StripePaymentService : IPaymentService
    {
        private readonly string _apiKey = "api-key";

        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = _apiKey;
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(request.Amount * 100), // Convert to cents
                    Currency = request.Currency,
                    PaymentMethod = request.CardNumber, // This should be the PaymentMethod ID from the client
                    Confirm = true
                };

                var service = new PaymentIntentService();
                var intent = await service.CreateAsync(options);

                return new PaymentResponse
                {
                    Success = true,
                    TransactionId = intent.Id,
                    Message = "Payment processed successfully."
                };
            }
            catch (StripeException ex)
            {
                return new PaymentResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
