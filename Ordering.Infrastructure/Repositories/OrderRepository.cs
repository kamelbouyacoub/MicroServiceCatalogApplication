using Microsoft.EntityFrameworkCore;
using Ordering.Core;
using Ordering.Core.Entities;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public OrderRepository(OrderContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrderByUserName(string userName)
        {
            var orderList = await _dbContext.Orders.Where(o => o.UserName.Equals(userName)).ToListAsync();
            return orderList;
        }
    }
}
