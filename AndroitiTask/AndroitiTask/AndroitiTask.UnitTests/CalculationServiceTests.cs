using AndroitiTask.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace AndroitiTask.UnitTests
{
    public class CalculationServiceTests
    {
        [Fact]
        public void GetCharactersCount_GivenSampleText_CalculateCharsCorrectly()
        {
            //Arrange
            Mock<IFileService> fileServiceMock = new Mock<IFileService>();

            CalculationService service = new CalculationService(fileServiceMock.Object);

            string text = "Hello World";

            fileServiceMock.Setup(fs => fs.GetText()).Returns(text);
            //Act
            int number = service.GetCharactersCount();
            //Assert
            number.Should().Be(11);
        }

        [Theory]
        [InlineData("Hello World", 2)]
        [InlineData("", 0)]
        public void GetWordCount_GivenSampleText_CalculateWordsCorrectly(string text, int wordCount)
        {
            //Arrange
            Mock<IFileService> fileServiceMock = new Mock<IFileService>();

            CalculationService service = new CalculationService(fileServiceMock.Object);

            fileServiceMock.Setup(fs => fs.GetText()).Returns(text);
            //Act
            int number = service.GetWordCount();
            //Assert
            number.Should().Be(wordCount);
        }
    }
}