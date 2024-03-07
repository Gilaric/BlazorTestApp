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
            var smallElm = cut.Find("p.cl_FileSuccess");
            smallElm.MarkupMatches(@"<p class=""cl_FileSuccess"">Files successfully uploaded</p>");
        }

        [Fact]
        public void FailedCreateTest()
        {
            // Create BUnit for testing if a file is created
            // Arrange
            using var ctx = new TestContext();

            // Create an array of InputFileContent with more than 3 files
            InputFileContent[] filesToUpload = new InputFileContent[]
            {
                InputFileContent.CreateFromText("Text content 1", "File1.txt"),
                InputFileContent.CreateFromText("Text content 2", "File2.txt"),
                InputFileContent.CreateFromText("Text content 3", "File3.txt"),
                InputFileContent.CreateFromText("Text content 4", "File4.txt"),
                InputFileContent.CreateFromText("Text content 5", "File5.txt")
            };

            // Render the component under test which contains the InputFile component as a child component
            IRenderedComponent<FileCreate> cut = ctx.RenderComponent<FileCreate>();

            // Find the InputFile component
            IRenderedComponent<InputFile> inputFile = cut.FindComponent<InputFile>();

            inputFile.UploadFiles(filesToUpload);

            // Assertions...
            Assert.NotEmpty(filesToUpload);

            Assert.InRange(filesToUpload.Length, 4, 5);

            var FailElm2 = cut.Find("h2");
            FailElm2.MarkupMatches(@"<h2>Errors</h2>");

            var FailElm = cut.Find("p.cl_FileFailed");
            FailElm.MarkupMatches(@"<p class=""cl_FileFailed"">File not uploaded</p>");
        }
    }
}
