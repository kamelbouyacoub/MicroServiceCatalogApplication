using Bascket.API.Data.Interfaces;
using Bascket.API.Entities;
using Bascket.API.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBascketContext context;
        public BasketRepository(IBascketContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return  await context.Redis.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart> GetBascket(string userName)
        {
            var _basket = await context.Redis.StringGetAsync(userName);
            if (_basket.IsNullOrEmpty) return null;
            return JsonConvert.DeserializeObject<BasketCart>(_basket);
        }

        public async Task<BasketCart> UpdateBascket(BasketCart basket)
        {
            var updated = await context.Redis.StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            if (!updated) return null;
            return await GetBascket(basket.UserName);
        }
    }
}
