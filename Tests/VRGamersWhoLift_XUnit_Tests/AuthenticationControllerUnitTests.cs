using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq; //https://stackoverflow.com/questions/60969931/how-to-test-method-in-xunit-that-needs-usermanager-but-uses-in-memory-database
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGamersWhoLift.Controllers;
using VRGamersWhoLift.Helpers;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Models.users;
using VRGamersWhoLift.Models.ViewModels;
using VRGamersWhoLiftUnitTestsXUNIT;
using Xunit;

namespace VRGamersWhoLift_XUnit_Tests
{


    public class AuthenticationControllerUnitTests
    {
        //https://stackoverflow.com/questions/60969931/how-to-test-method-in-xunit-that-needs-usermanager-but-uses-in-memory-database

        private VRGamersWhoLiftContext _context { get; set; }
        private SignInManager<User> _SignInManager { get; set; }
        private UserManager<User> _UserManager { get; set; }

        [Fact]
        public void AuthenticationController_ReturnsAViewResult_MemberRegister()
        {
            //Arrange
            var controller = new AuthenticationController(_UserManager, _SignInManager, _context);

            //Act
            var result = controller.MemberRegister();

            //Assert
            Assert.IsType<ViewResult>(result);

        }

        
    
        [Fact]
        public void AuthenticationController_ReturnsAIActionResult_MemberRegisterWithModel()
        {
            //Arrange
            var controller = new AuthenticationController(_UserManager, _SignInManager, _context);
            RegisterViewModel model = new RegisterViewModel();

            //Act
            var result = controller.MemberRegister(model);

            //Assert
            Assert.IsType<Task<IActionResult>>(result);

        }

        [Fact]
        public void AuthenticationController_ReturnsAIActionResult_Logout()
        {
            //Arrange
            var controller = new AuthenticationController(_UserManager, _SignInManager, _context);
            
            //Act 
            var result = controller.Logout();

            //Assert
            Assert.IsType<Task<IActionResult>>(result);

        }

        [Fact]
        public void voidAuthenticationController_ReturnsAIActionResult_Login()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
