using System;

namespace Domain.Entities;

public class ShoppingCart(Guid customerId)
{
    public Guid Id {get; private set;} = Guid.NewGuid();
    public Guid CustomerId {get;} = customerId;

    // Preserve encapsulation via a read-only view
    public IReadOnlyCollection<ShoppingCartItem> Items => _items.AsReadOnly();

    // Keep the mutable list private
    private readonly List<ShoppingCartItem> _items = new();

    public void AddItem(Guid productId, string productName, decimal productPrice, int quantity)
    {   
        // Check if the item already exists in the cart
        var existingItem = _items.SingleOrDefault( i => i.ProductId == productId);
        // If it exists, update the quantity; otherwise, add a new item
        if (existingItem is not null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            // Add a new item to the cart
            _items.Add(new ShoppingCartItem(productId, productName, productPrice, quantity));
        }
    }
}
