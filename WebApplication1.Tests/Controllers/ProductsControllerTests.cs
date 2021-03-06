﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void ShouldReturnProductsIndex()
        {
            //arrange
            var products = new List<Product>
            {
                new Product { Name = "AK-47", Price = 2000, Stock = 20, GenreID = 1 },
                new Product { Name = "AK-47", Price = 2000, Stock = 20, GenreID = 1 },
            };
            var _productService = new Mock<IProductService>();
            var _genreService = new Mock<IGenreService>();
            var _orderService = new Mock<IOrderService>();
            _productService.Setup(x => x.GetProducts()).Returns(Task.FromResult(products));
            var controller = new ProductsController(_productService.Object, _genreService.Object, _orderService.Object);

            //act
            var result = controller.IndexAsync().GetAwaiter().GetResult() as ViewResult;
            var productsresult = result.Model as List<Product>;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, productsresult.Count);
        }

        [TestMethod]
        public void ShouldReturnProductsCreateGET()
        {
            //arrange
            var _productService = new Mock<IProductService>();
            var _genreService = new Mock<IGenreService>();
            var _orderService = new Mock<IOrderService>();
            var controller = new ProductsController(_productService.Object, _genreService.Object, _orderService.Object);

            //act
            var result = controller.Create().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldPostProducts()
        {
            //arrange
            var model = new ProductViewModel { ProductID = 1, Name = "AK-47", Price = 2000, Stock = 20, Amount = 1, GenreID = 1 };
            var product = new Product { Name = model.Name, Price = model.Price, Stock = model.Stock, GenreID = model.GenreID };
            var _productService = new Mock<IProductService>();
            var _genreService = new Mock<IGenreService>();
            var _orderService = new Mock<IOrderService>();
            var controller = new ProductsController(_productService.Object, _genreService.Object, _orderService.Object);

            //act
            _productService.Setup(x => x.CreateProduct(model, null)).Returns(Task.FromResult(product));
            //var result = controller.Create(model).GetAwaiter().GetResult() as ViewResult;
            //var resultproduct = result.Model as Product;

            ////assert
            //Assert.AreEqual(model.ProductID, resultproduct.ProductID);
        }
    }
}
