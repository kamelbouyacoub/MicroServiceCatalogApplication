using MediatR;
using Orderning.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orderning.Application.Queries
{
    public class GetOrderByUserNameQuery: IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            userName = userName ?? throw new ArgumentException(nameof(userName));
        }
    }
}
