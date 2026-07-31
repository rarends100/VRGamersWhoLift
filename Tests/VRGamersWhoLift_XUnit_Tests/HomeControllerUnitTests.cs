namespace VRGamersWhoLiftUnitTestsXUNIT
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using VRGamersWhoLift.Controllers;
    using VRGamersWhoLift.Helpers;
    using VRGamersWhoLift.Models.Abstract;
    using VRGamersWhoLift.Models.database;
    using VRGamersWhoLift.Models.users;
    using VRGamersWhoLift.Models.ViewModels;
    using VRGamersWhoLift.Models;
    using VRGamersWhoLiftUnitTestsXUNIT;
    using Xunit;
    public class HomeControllerUnitTests
    {
        //HomeContoller
        [Fact]
        public void HomeController_ReturnsAViewResult_Index() //https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-10.0
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void HomeController_ReturnsAViewResult_Privacy()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Privacy();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

         /* I don't understand this yet, need to learn more.
        [Fact]
        public void HomeController_ReturnsAViewResult_Error()
        {
            //Arrange
            var controller = new HomeController();
            ErrorViewModel ErrorViewModel = new ErrorViewModel();

            //Act
            var result = controller.Error();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
         */

        //Authentication Controller
    }
}