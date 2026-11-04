
using NSubstitute;
using Application.Interfaces.Data;
using Application.UseCases.AddItemToCart;
namespace Application.UnitTests.UseCases;

public class AddItemToCartUseCaseTests
{
    [Fact]
   public async Task AddItemToCart_ValidInput_AddsItemToCart()
    {
        // Arrange
            var shoppingCartRepository = Substitute.For<IShoppingCartRepository>();
            var productRepository = Substitute.For<IProductRepository>();
            var userId = Guid.NewGuid();
            var shoppingCart = new ShoppingCart(userId);
            var product = new Product("Test Product", 10.00m);
            shoppingCartRepository.GetByCustomerIdAsync(userId).Returns(shoppingCart);
            productRepository.GetByIdAsync(product.Id).Returns(product);

            var useCase = new AddItemToCartUseCase(ShoppingCartRepository, ProductRepository);

        // Act
            _ = useCase.AddItemToCartAsync(new AddItemToCartInput(userId, product.Id, 2));

    }
}