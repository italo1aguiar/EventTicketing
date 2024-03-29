namespace EventTicketing.Domain.Entities;

public class Payment
{
    public Guid Id { get; set; } // Use GUID for unique identifier
    public int OrderId { get; set; } // Foreign key to identify the order associated with the payment
    public decimal Amount { get; set; } // The amount of the payment
    public DateTime PaymentDate { get; set; } // Date and time when the payment was made
    public Guid CorrelationId { get; set; } // Correlation ID for tracking related actions
    public Guid TransactionId { get; set; } // Transaction ID for tracking payment transactions

    // Relationship: One Payment to One Order
    public Order Order { get; set; }
}