using VRGamersWhoLift.Helpers;
using VRGamersWhoLift.Models;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.database;

namespace VRGamersWhoLift_XUnit_Tests
{
    public class bizLogicUnitTests
    {
       [Fact]
        public void RegisterActive_unitTest_isString ()
        {
            //Arrange
            string link = "/link";
            string currentAction = "TEST";

            //Act
            string result = Nav.RegisterActive(link, currentAction);

            //Assert
            Assert.IsType<String>(result);
        }

        [Fact]
        public void RegisterActive_unitTest_isConverted()
        {
            //Arrange
            string link = "/link";
            string currentAction = "TEST";

            //Act
            string result = Nav.RegisterActive(link, currentAction);

            //Assert
            Assert.NotEqual(currentAction, result);
        }

    }
}
