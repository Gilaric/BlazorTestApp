using AngleSharp.Dom;
using BlazorTestApp.Components.Pages;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorTestApp.Tests
{
    public class FileCreateTest
    {
        [Fact]
        public void FileCreateSuccessTest()
        {
            // Arrange
            using var ctx = new TestContext();
            InputFileContent fileToUpload = InputFileContent.CreateFromText("Text content", "Filename.txt");
            IRenderedComponent<FileCreate> cut = ctx.RenderComponent<FileCreate>();
            IRenderedComponent<InputFile> inputFile = cut.FindComponent<InputFile>();

            // Act
            inputFile.UploadFiles(fileToUpload);

            // Assert
            Assert.NotNull(inputFile);
            var smallElm = cut.Find("p.cl_FileSuccess");
            smallElm.MarkupMatches(@"<p class=""cl_FileSuccess"">Files successfully uploaded</p>");
        }

        [Fact]
        public void FileCreateFailedCreateTest()
        {
            // Arrange
            using var ctx = new TestContext();
            InputFileContent[] filesToUpload = new InputFileContent[]
            {
                InputFileContent.CreateFromText("Text content 1", "File1.txt"),
                InputFileContent.CreateFromText("Text content 2", "File2.txt"),
                InputFileContent.CreateFromText("Text content 3", "File3.txt"),
                InputFileContent.CreateFromText("Text content 4", "File4.txt"),
                InputFileContent.CreateFromText("Text content 5", "File5.txt")
            };

            IRenderedComponent<FileCreate> cut = ctx.RenderComponent<FileCreate>();
            IRenderedComponent<InputFile> inputFile = cut.FindComponent<InputFile>();

            // Act
            inputFile.UploadFiles(filesToUpload);

            // Assert
            Assert.NotEmpty(filesToUpload);
            Assert.InRange(filesToUpload.Length, 4, 5);

            var FailElm2 = cut.Find("h2");
            FailElm2.MarkupMatches(@"<h2>Errors</h2>");

            var FailElm = cut.Find("p.cl_FileFailed");
            FailElm.MarkupMatches(@"<p class=""cl_FileFailed"">File not uploaded</p>");
        }

        [Fact]
        public void FileCreateViewTest()
        {
            // Arrange
            using var ctx = new TestContext();
            IRenderedComponent<FileCreate> cut = ctx.RenderComponent<FileCreate>();

            // Act
            var FailElm2 = cut.Find("input");

            // Assert
            FailElm2.MarkupMatches(@"<input multiple="""" type=""file"" >");
        }

        [Fact]
        public void FileCreateNoViewTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<FileCreate>();

            // Act 
            var failElm2 = cut.Find("input");

            // Assert
            Assert.False(failElm2.IsInvalid());
        }
    }
}
