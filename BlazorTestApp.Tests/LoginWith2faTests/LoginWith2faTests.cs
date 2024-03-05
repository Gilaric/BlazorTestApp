﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.Tests.LoginWith2faTests
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
