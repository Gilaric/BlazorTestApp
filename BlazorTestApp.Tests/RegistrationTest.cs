using BlazorTestApp.Components.Account.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.Tests
{
    public class RegistrationTest
    {
        [Fact]
        public void RegisterViewTest()
        {
            // Arange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Register>();

            // Act

            // Assert
            var h1Element = cut.Find("h1");
            Assert.Equal("Register", h1Element.TextContent);
        }

        [Fact]
        public void RegisterCodeTest()
        {
            // Arange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Register>();

            // Assert
            //Assert.True(myInstance._isAuthenticated);
        }
        [Fact]
        public void NotRegisteredViewTest()
        {
            // Arange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Register>();

            // Assert
            cut.MarkupMatches("<div>You are NOT logged in...</div>");
        }

        [Fact]
        public void NotRegisteredTest()
        {
            // Arange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<Register>();

            // Assert
            //Assert.False(myInstance._isAuthenticated);
        }
    }
}
