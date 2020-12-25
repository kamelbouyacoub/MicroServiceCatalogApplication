using MediatR;
using Ordering.Core;
using Ordering.Core.Entities;
using Orderning.Application.Commands;
using Orderning.Application.Mapper;
using Orderning.Application.Queries;
using Orderning.Application.Responses;
using System;
 
using System.Threading;
using System.Threading.Tasks;

namespace Orderning.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null) throw new ApplicationException("not mapped");
            var newOrder = await _orderRepository.AddAsync(orderEntity);
            var orderReponse = OrderMapper.Mapper.Map<OrderResponse>(newOrder);
            return orderReponse;
        }
    }
}
