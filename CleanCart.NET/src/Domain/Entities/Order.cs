

namespace Domain.Entities;

public class Order
{
    // Order properties and methods
    // makes a list of order items and calculates the total price of the order
    private readonly List<OrderItem> _items = new();

    public Guid Id { get; private set;}
    public Guid UserId { get; private set;}
    // creates a read-only collection of oerder items from the private list of order items
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public decimal TotalAmount { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public OrderStatus Status { get; private set; }


    public Order(Guid userId, IEnumerable<OrderItem> items, decimal totalamount)
    {
       Id = Guid.NewGuid();
       UserId = userId;
       // Add the provided items to the order's item list
       _items.AddRange(items);
       TotalAmount = totalamount;
       CreatedOn = DateTime.UtcNow;
       Status = OrderStatus.Pending; // Initial status of the order
    }
}
