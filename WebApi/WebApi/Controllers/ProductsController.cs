using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Products()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Product(long id)
        {
            return View();
        }

        [HttpPatch("{id}")]
        public IActionResult Product(long id, string description)
        {
            return View();
        }
    }
}
