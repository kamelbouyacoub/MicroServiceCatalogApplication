using Ordering.Core.Entities;
using Ordering.Core.Entities.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Core
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserName(string userName);
    }
}
