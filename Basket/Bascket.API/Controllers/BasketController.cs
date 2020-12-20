using AutoMapper;
using Bascket.API.Entities;
using Bascket.API.Repositories.Interfaces;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Bascket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
     


        private readonly IBasketRepository _repository;
        private readonly IMapper  _mapper;
        private readonly EventBusRabbitMQProducer  _eventBus;

        public BasketController( IBasketRepository repository, EventBusRabbitMQProducer eventBus, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> GetBasket(string userName)
        {
            var _basket = await _repository.GetBascket(userName);
            return Ok(_basket);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> UpdateBasket([FromBody]BasketCart basket)
        {
            var _basket = await _repository.UpdateBascket(basket);
            return Ok(_basket);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket( string userName)
        {
            var _basket = await _repository.DeleteBasket(userName);
            return Ok(_basket);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            //get Total price of basket

            var basket = await _repository.GetBascket(basketCheckout.UserName);
            if (basket == null) return BadRequest();
            var basketRemoved = await _repository.DeleteBasket(basket.UserName);
            if (! basketRemoved) return BadRequest();

            var eventMessage = _mapper.Map<BasketChekoutEvent>(basketCheckout);
            eventMessage.RequestId = Guid.NewGuid();
            eventMessage.TotalPrice = basket.TotalPrice;

            try
            {
                _eventBus.PublishBasketCheckout(EventBusConstant.BasketChekoutQueue, eventMessage);
            }
            catch (Exception)
            {
                throw;
            }
            return Accepted();
           
        }

    }
}
