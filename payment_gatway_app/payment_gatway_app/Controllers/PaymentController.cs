using Microsoft.AspNetCore.Mvc;
using payment_gatway_app.Model;
using payment_gatway_app.Services;

namespace payment_gatway_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _paymentService.ProcessPaymentAsync(request);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
