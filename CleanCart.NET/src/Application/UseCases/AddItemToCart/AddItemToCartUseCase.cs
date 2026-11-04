using Application.Interfaces.Data;
using Application.Interfaces.UseCases;
using Domain.Entities;


namespace Application.UseCases.AddItemToCart;

public class AddItemToCartUseCase(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository): IAddItemToCartUseCase
{
    public async Task AddItemToCartAsync(AddItemToCartInput input)
    {
        // Retrieve the product from the repository

        var product = await productRepository.GetByIdAsync(input.ProductId);
        if (product is null)
          return;


        // Retrieve the shopping cart for the customer
        var shoppingCart = await shoppingCartRepository.GetByCustomeIdAsync(input.CustomerId) ?? new ShoppingCart(input.CustomerId);

        // Add the product to the shopping cart
        shoppingCart.AddItem(product.Id, product.Name, product.Price, input.Quantity);
        
        // save the updated shopping cart back to the repository
        await shoppingCartRepository.SaveAsync(shoppingCart);
    }
}
