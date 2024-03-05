using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorTestApp.Tests.LoginTests;

namespace BlazorTestApp.Tests.LoginWithRecoveryCodeTests
{
    public class LoginWithRecoveryCodeTests : TestContext
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            // Act
            var cut = RenderComponent<Login>();

            // Assert
            cut.MarkupMatches(@"<h1>Welcome TEST USER</h1>
                      <p>State: Authorized</p>");
        }
    }
}
