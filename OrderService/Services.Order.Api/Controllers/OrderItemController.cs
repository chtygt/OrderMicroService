using Microsoft.AspNetCore.Mvc;
using Services.Order.Api.Services;
using Services.Order.Model;

namespace Services.Order.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemService _orderItemService;
        public OrderItemController(OrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result = _orderItemService.Get(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add([FromBody] OrderItem model)
        {
            var result = _orderItemService.Add(model);
            return StatusCode((int)result.StatusCode, result);
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult Update(OrderItem model)
        {
            var result = _orderItemService.Update(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _orderItemService.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{orderItemId}/{offset:int=0}/{limit:int=1000}")]
        [HttpGet]
        public IActionResult List(Guid contactId, int offset, int limit)
        {
            var result = _orderItemService.List(contactId, offset, limit);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult ListAll()
        {
            var result = _orderItemService.ListAll();
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{orderItemId}")]
        [HttpGet]
        public IActionResult Count(Guid contactId)
        {
            var result = _orderItemService.Count(contactId);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
