using AutoMapper;
using Ordering.Core.Entities;
using Orderning.Application.Commands;
using Orderning.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orderning.Application.Mapper
{
    public class OrderMappingProfile: Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
