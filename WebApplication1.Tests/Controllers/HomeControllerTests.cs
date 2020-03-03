using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ShouldReturnIndexPage()
        {
            //arrange
            var controller = new HomeController();

            //act
            var result = controller.Index();

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ShouldRetunAboutPage()
        {
            //assert
            var controller = new HomeController();
            //act
            var result = controller.About();
            //assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ShouldReturnContactPage()
        {
            //arrange
            var controller = new HomeController();
            //act
            var result = controller.Contact();
            //assert
            Assert.IsNotNull(result);
        }
    }
}
