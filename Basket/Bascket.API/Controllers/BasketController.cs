using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bascket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
     

        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
        }

      
    }
}
