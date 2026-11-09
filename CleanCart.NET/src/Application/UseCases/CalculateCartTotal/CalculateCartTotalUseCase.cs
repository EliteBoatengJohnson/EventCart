using Application.Interfaces.Data;
using Application.Interfaces.UseCases;
using Domain.Entities;
namespace Application.UseCases.CalculateCartTotal;

public class CalculateCartTotalUseCase(IShoppingCartRepository shoppingCartRepository) : ICalculateCartTotalUseCase
{

    public async Task<decimal> CalculateTotalAsync(CalculateCartTotalInput input)
    {
       var shoppingCart = await shoppingCartRepository.GetByCustomerIdAsync(input.UserId);

       decimal subtotal = CalculateSubtotal(shoppingCart);
       decimal tax = CalculateTax(subtotal);
       decimal total = subtotal + tax;

       return total;
    }

    private decimal CalculateSubtotal(ShoppingCart? shoppingCart)
    {
        return shoppingCart?.Items.Sum(item => item.ProductPrice * item.Quantity) ?? 0;
    }

    private decimal CalculateTax(decimal subtotal)
    {
        const decimal taxRate = 0.08m; // Assuming 8% tax rate
        return subtotal * taxRate;
    }
}
