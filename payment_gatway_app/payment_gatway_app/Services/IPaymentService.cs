using payment_gatway_app.Model;

namespace payment_gatway_app.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
    }
}
