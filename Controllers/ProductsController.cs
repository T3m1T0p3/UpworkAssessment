using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpworkAssessment.Model;
using UpworkAssessment.RepositoryService;

namespace UpworkAssessment.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {
        public readonly IRepositoryServices _services;
        private readonly ILogger<Product> _logger;
        private readonly IMapper _mapper;
        public ProductsController(IRepositoryServices repositoryServices,IMapper mapper, ILogger<Product> logger)
        {
            _services = repositoryServices;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{productId:guid}",Name ="get")]
        public IActionResult GetProduct([FromRoute]Guid productId)
        {
            try
            {
                var product=_services.GetProduct(productId);
                return Ok(product);
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.ToString());
                return NotFound();
            }
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromForm]ProductDto newProduct)
        {
            try
            {
                var product = _mapper.Map<Product>(newProduct);
                Console.WriteLine(product.ProductId);
                 _services.CreateProduct(product);
                return CreatedAtRoute("get",new { product.ProductId },product);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return BadRequest();
            }
        }

        [HttpDelete("delete/{productId:guid}")]
        public IActionResult DeleteProduct([FromRoute]Guid productId)
        {
            try
            {
                _services.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct([FromForm]Product newProduct)
        {
            try
            {
                _services.UpdateProduct(newProduct);
                return CreatedAtRoute("get", new { newProduct.ProductId }, newProduct);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return BadRequest();
            }
        }

    }
}
