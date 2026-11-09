namespace Domain.Entities;

public enum OrderStatus
{
    Pending,  // The initial status when the order is created
    PaymentFailed, // Payment processing failed
    Paid, // Payment was successful
    Shipped, // Order has been shipped to the customer
    Delivered, // Order has been delivered to the customer
    Cancelled // Order has been cancelled by the customer or the system
}
