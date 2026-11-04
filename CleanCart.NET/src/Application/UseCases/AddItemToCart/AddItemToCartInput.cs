using System;

namespace Application.UseCases.AddItemToCart;

public class AddItemToCartInput(Guid customerId, Guid productId, int quantity)
{
    public Guid CustomerId {get;} = customerId;
    public Guid ProductId {get;} = productId;   
    public int Quantity {get;} = quantity;
}
