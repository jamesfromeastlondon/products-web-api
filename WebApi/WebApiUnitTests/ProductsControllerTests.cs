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

        [Fact]
        public void GetProductById()
        {
            // Arrange
            var product = new Product("testName", "testImgUri", 99.99m, "testDescription");

            var mock = new Mock<IProductService>();
            mock.Setup(p => p.GetById(0)).Returns(product);
            var controller = new ProductsController(mock.Object);

            // Act
            var controllerResult = (controller.Product(0) as JsonResult).Value;
            var json = JsonConvert.SerializeObject(controllerResult);
            JObject jObject = JObject.Parse(json);

            var nameResult = jObject.GetValue("product")["Name"];
            var imgUriResult = jObject.GetValue("product")["ImgUri"];
            var descriptionResult = jObject.GetValue("product")["Description"];
            var priceResult = jObject.GetValue("product")["Price"];

            //Assert
            Assert.Equal("testName", nameResult);
            Assert.Equal("testImgUri", imgUriResult);
            Assert.Equal("testDescription", descriptionResult);
            Assert.Equal("99.99", priceResult);
        }
    }
}
