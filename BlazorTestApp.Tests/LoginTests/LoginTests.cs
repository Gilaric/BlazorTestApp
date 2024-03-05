using BlazorTestApp.Tests.LoginTests;

namespace BlazorTestApp.Tests.LoginWith2faTests.LoginTests
{
    public class LoginTests : TestContext
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
