using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductService productService;
        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>Retrieve all products.</summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult Products()
        {
            List<Product> products = productService.GetAll();
            return Json(new { products });
        }

        /// <summary>Retrieve a product by Id.</summary>
        /// <response code="200">Success</response>            
        /// <response code="404">NotFound. Product Id does not exist.</response>   
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Product(long id)
        {
            Product product = productService.GetById(id);
            if (product != null)
                return Json(new { product });
            return NotFound();
        }

        /// <summary>Update a product description by Id.</summary>
        /// <response code="204">NoContent. Product successfully updated, and no content is returned.</response>            
        /// <response code="404">NotFound. Product Id does not exist.</response>  
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Product(long id, string description)
        {
            bool isUpdated = productService.UpdateProduct(id, description);
            if (isUpdated)
                return NoContent();
            return NotFound();
        }
    }
}
