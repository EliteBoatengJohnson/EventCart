using Application.Interfaces.Data;

namespace Application.Interfaces.UseCases.AddItemToCart;

public class AddItemToCartUseCase(
    IShoppingCartRepository shoppingCartRepository,
    IProductRepository productRepository
):IAddItemToCartUseCase
{
   
}
