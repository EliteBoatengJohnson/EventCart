using Domain.Entities;
using Application.Interfaces.UseCases;
using Application.Interfaces.Data;
namespace Application.UseCases.RemoveItemFromCart;

public class RemoveItemFromCartUseCase (IShoppingCartRepository shoppingCartRepository): IRemoveItemFromCartUseCase
{
   public async Task RemoveItemFromCartAsync(RemoveItemFromCartInput input)

    {
        // Retrive the shopping cart for the customer
        ShoppingCart? cart = await shoppingCartRepository.GetByCustomerIdAsync(input.UserId);
        if ( cart != null )
        {
           cart.RemoveItem(input.ProductId, input.Quantity);

            // Save the updated shopping cart
            await shoppingCartRepository.SaveAsync(cart);
        }
        else
        {
            // Handle the case where the shopping cart does not exist for the customer
            // You can throw an exception or return an error message as per your application's requirements
            throw new InvalidOperationException("Shopping cart not found for the specified customer.");
        }
    }
}
