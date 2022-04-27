using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Product.Api.Services;

namespace Services.Product.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result = _productService.Get(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add([FromBody] Model.Product model)
        {
            var result = _productService.Add(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Update(Model.Product model)
        {
            var result = _productService.Update(model);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var result = _productService.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{offset:int=0}/{limit:int=1000}")]
        [HttpGet]
        public IActionResult List(int offset, int limit)
        {
            var result = _productService.List(offset, limit);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Count()
        {
            var result = _productService.Count();
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
