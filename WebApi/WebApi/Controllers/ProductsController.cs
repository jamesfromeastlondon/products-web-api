using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult Products()
        {
            List<Product> products = productService.GetAll();
            return Json(new { products });
        }

        [HttpGet("{id}")]
        public IActionResult Product(long id)
        {
            Product product = productService.GetById(id);
            if (product != null)
                return Json(new { product });
            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult Product(long id, string description)
        {
            bool isUpdated = productService.UpdateProduct(id, description);
            if (isUpdated)
                return NoContent();
            return NotFound();
        }
    }
}
