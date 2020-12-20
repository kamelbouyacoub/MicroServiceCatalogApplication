using AutoMapper;
using Bascket.API.Entities;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Mapping
{
    public class BasketMapping : Profile
    {

        public BasketMapping()
        {
            CreateMap<BasketCheckout, BasketChekoutEvent>().ReverseMap();
        }
    }
}
