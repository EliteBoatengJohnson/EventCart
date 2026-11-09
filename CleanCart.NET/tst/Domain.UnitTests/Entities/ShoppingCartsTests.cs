using Domain.Entities;

namespace Domain.UnitTests.Entities;

public class ShoppingCartsTests
{
    [Fact]
    public void AddItem_AddsNewItemToCart_WhenExisitingItemIsNull()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var shoppingCart = new ShoppingCart(customerId);
        var product = new Product("Test Product", 10.0m);

        //Act
        shoppingCart.AddItem(product.Id, product.Name, product.Price, quantity: 1);

        // Assert
        Assert.Single(shoppingCart.Items);
        Assert.Equal(product.Id, shoppingCart.Items.First().ProductId);
        Assert.Equal(1, shoppingCart.Items.First().Quantity);



    }

    
        [Fact]
        public void AddItem_IncrementsQuantity_WhenExistingItemIsNotNull()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var shoppingCart = new ShoppingCart(customerId);
            var product = new Product("Test Product", 10.0m);

            // Act
            shoppingCart.AddItem(product.Id, product.Name, product.Price, quantity: 1);
            shoppingCart.AddItem(product.Id, product.Name, product.Price, quantity: 2);

            // Assert
            Assert.Single(shoppingCart.Items);
            Assert.Equal(product.Id, shoppingCart.Items.First().ProductId);
            Assert.Equal(3, shoppingCart.Items.First().Quantity);
        }
}
