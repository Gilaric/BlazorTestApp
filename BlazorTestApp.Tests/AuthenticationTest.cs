using BlazorTestApp.Components.Pages;

namespace BlazorTestApp.Tests
{
    public class AuthenticationTest
    {
        [Fact]
        public void LoginViewTest()
        {
            // Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<div>You are logged in...</div>");

        }

        [Fact]
        public void LoginCodeTest()
        {
            // Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");

            // Act
            var cut = ctx.RenderComponent<Home>();
            var myInstance = cut.Instance;

            // Assert
            Assert.True(myInstance._isAuthenticated);
        }
        [Fact]
        public void NotLoggedInViewTest()
        {
            // Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<div>You are NOT logged in...</div>");
        }

        [Fact]
        public void NotLoggedInCodeTest()
        {
            // Arange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();

            // Act
            var cut = ctx.RenderComponent<Home>();
            var myInstance = cut.Instance;

            // Assert
            Assert.False(myInstance._isAuthenticated);
        }
    }
}
