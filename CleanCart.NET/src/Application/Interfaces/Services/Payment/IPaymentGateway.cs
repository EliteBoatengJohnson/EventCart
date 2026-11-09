using System;

namespace Application.Interfaces.Services.Payment;

public interface IPaymentGateway
{
    Task<PaymentResult> ProcessPaymentsAsync(PaymentRequest paymentrequest);
    Task<PaymentStatus> GetPaymentStatusAsync(string paymentId);
}
