using Domain.Entities;

namespace Application.Interfaces.Data;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetByCustomeIdAsync(Guid customerId);
    Task SaveAsync(ShoppingCart shoppingcart);
}
