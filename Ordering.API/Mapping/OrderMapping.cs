using AutoMapper;
using EventBusRabbitMQ.Events;
using Orderning.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Mapping
{
    public class OrderMapping: Profile
    {
        public OrderMapping()
        {
            CreateMap<BasketChekoutEvent, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
