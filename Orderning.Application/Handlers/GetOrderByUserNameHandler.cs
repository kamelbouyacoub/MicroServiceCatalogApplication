using MediatR;
using Ordering.Core;
using Orderning.Application.Mapper;
using Orderning.Application.Queries;
using Orderning.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Orderning.Application.Handlers
{
    public class GetOrderByUserNameHandler : IRequestHandler<GetOrderByUserNameQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByUserNameHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentException(nameof(orderRepository));
        }
        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrderByUserName(request.UserName);

            var orderResponseList = OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orderList);
            return orderResponseList;
        }
    }
}
