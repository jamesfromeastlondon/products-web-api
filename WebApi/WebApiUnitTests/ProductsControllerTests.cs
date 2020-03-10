using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApi.Controllers;
using WebApi.Interfaces;
using WebApi.Models;
using Xunit;

namespace WebApiUnitTests
{
    public class ProductsControllerTests 
    {
        [Fact]
        public void GetAllProducts()
        {
            // Arrange
            var productOne = new Product("oneName", "oneImgUri", 99.99m, "oneDescription");
            var productTwo = new Product("twoName", "twoImgUri", 99.99m, "twoDescription");
            var products = new List<Product> { productOne, productTwo };

            var mock = new Mock<IProductService>();
            mock.Setup(p => p.GetAll()).Returns(products);
            var controller = new ProductsController(mock.Object);

            // Act
            var controllerResult = (controller.Products() as JsonResult).Value;
            var json = JsonConvert.SerializeObject(controllerResult);
            JObject jObject = JObject.Parse(json);

            var productResultOne = jObject.GetValue("products")[0]["Name"];
            var productResultTwo = jObject.GetValue("products")[1]["Name"];

            // Assert
            Assert.Equal(productOne.Name, productResultOne);
            Assert.Equal(productTwo.Name, productResultTwo);
        }
    }
}
