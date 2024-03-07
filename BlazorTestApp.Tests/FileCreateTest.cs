using BlazorTestApp.Components.Pages;
using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BlazorTestApp.Tests
{
	public class FileCreateTest
	{
		[Fact]
		public void CreateTest()
		{
			// Create BUnit for testing if a file is created
			// Arrange
			using var ctx = new TestContext();

			// Create an InputFileContent with string content
			InputFileContent fileToUpload = InputFileContent.CreateFromText("Text content", "Filename.txt");

			// Render the component under test which contains the InputFile component as a child component
			IRenderedComponent<FileCreate> cut = ctx.RenderComponent<FileCreate>();

			// Find the InputFile component
			IRenderedComponent<InputFile> inputFile = cut.FindComponent<InputFile>();

			// Upload the file to upload to the InputFile component
			inputFile.UploadFiles(fileToUpload);

			// Assertions...
			Assert.NotNull(inputFile);
        }
	}
}
