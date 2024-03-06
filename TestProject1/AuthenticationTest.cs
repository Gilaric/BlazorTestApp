﻿using BlazorTestApp.Components.Pages;
using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
