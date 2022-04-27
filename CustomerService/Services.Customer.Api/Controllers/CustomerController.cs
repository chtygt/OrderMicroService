using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Customer.Api.Services;

namespace Services.Customer.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }        

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result = _customerService.Get(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add([FromBody] Model.Customer model)
        {
            var result = _customerService.Add(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Update(Model.Customer model)
        {
            var result = _customerService.Update(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _customerService.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{offset:int=0}/{limit:int=1000}")]
        [HttpGet]
        public IActionResult List(int offset, int limit)
        {
            var result = _customerService.List(offset, limit);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Count()
        {
            var result = _customerService.Count();
            return StatusCode((int)result.StatusCode, result);
        }
               
    }
}
