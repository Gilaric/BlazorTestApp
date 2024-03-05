using System;

namespace BlazorTestApp.Tests.RegisterTests
{
    public class RegisterTests : TestContext
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            // Act
            var cut = RenderComponent<Register>();

            // Assert
            cut.MarkupMatches(@"<h1>Welcome TEST USER</h1>
                      <p>State: Authorized</p>");
        }
    }
}
