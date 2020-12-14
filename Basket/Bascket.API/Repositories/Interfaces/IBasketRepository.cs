using Bascket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart> Getbascket(string userName);
        Task<BasketCart> UpdateBascket(BasketCart basket
            );
        Task<bool> DeleteBasket(string userName);
    }
}
