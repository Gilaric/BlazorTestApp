using BlazorTestApp.Components.Account.Pages;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace BlazorTestApp.Tests
{
    public class RegisterTests
    {
        [Fact]
        public void RegisterSuccessTest()
        {
            // Create BUnit for testing if a file is created
            // Arrange
            using var ctx = new TestContext();
            // Mock RedirectManager service

            // Add other required services if needed
            /*ctx.Services.AddSingleton<IdentityRedirectManager>();*/ // Register IdentityRedirectManager

            // Act
            var cut1 = ctx.RenderComponent<Register>();
            Random rnd = new Random();

            // Find the InputText components within the form
            var inputEmail = cut1.Find("div.form-floating.mb-3 input[type='email']");
            var inputPassword = cut1.Find("div.form-floating.mb-3 input[type='password']");

            inputEmail.Change($"pkg.thomsen{rnd.Next()}@gmail.com");
            inputPassword.Change("password123");

            // Assert
            // You can optionally assert that the values have been changed
            Assert.Equal("pkg.thomsen@gmail.com", inputEmail.GetAttribute("value"));
            Assert.Equal("password123", inputPassword.GetAttribute("value"));
        }
    }
}
