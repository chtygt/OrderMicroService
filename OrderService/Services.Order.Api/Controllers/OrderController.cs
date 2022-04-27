using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Order.Api.Services;

namespace Services.Order.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result = _orderService.Get(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add([FromBody] Model.Order model)
        {
            var result = _orderService.Add(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Update(Model.Order model)
        {
            var result = _orderService.Update(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _orderService.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{offset:int=0}/{limit:int=1000}")]
        [HttpGet]
        public IActionResult List(int offset, int limit)
        {
            var result = _orderService.List(offset, limit);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Count()
        {
            var result = _orderService.Count();
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
