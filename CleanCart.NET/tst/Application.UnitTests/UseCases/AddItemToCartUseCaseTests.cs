
using NSubstitute;
using Application.Interfaces.Data;
using Application.UseCases.AddItemToCart;
using Domain.Entities;
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

            var useCase = new AddItemToCartUseCase(shoppingCartRepository, productRepository);

        // Act
            _ = useCase.AddItemToCartAsync(new AddItemToCartInput(userId, product.Id, 2));


        // Assert
            await productRepository.Received(1).GetByIdAsync(product.Id);
            await shoppingCartRepository.Received(1).GetByCustomerIdAsync(userId);
            await shoppingCartRepository.Received(1).SaveAsync(shoppingCart);


    }

    [Fact]
    public async Task AddItemToCartAsync_ShouldCreateNewCart_WhenCartDoesNotExist()
    {
        // Arrange
        var shoppingCartRepository = Substitute.For<IShoppingCartRepository>();
        var productRepository = Substitute.For<IProductRepository>();
        var userId = Guid.NewGuid();
        var product = new Product("Test Product", 10.00m);
        shoppingCartRepository.GetByCustomerIdAsync(userId).Returns((ShoppingCart?)null);
        productRepository.GetByIdAsync(product.Id).Returns(product);

        var useCase = new AddItemToCartUseCase(shoppingCartRepository, productRepository);

        // Act
        await useCase.AddItemToCartAsync(new AddItemToCartInput(userId, product.Id, 2));

        // Assert
        await shoppingCartRepository.Received(1).SaveAsync(Arg.Is<ShoppingCart>(cart => cart.CustomerId == userId && cart.Items.Any(i => i.ProductId == product.Id && i.Quantity == 2)));
    }
}