using System;

namespace Application.Interfaces.UseCases;

public interface IAddItemToCartUseCase
{
    Task AddItemToCartAsync(AddItemToCartInput input)

}
