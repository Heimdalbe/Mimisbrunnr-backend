using Mimmisbrunnr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.Tests.Common
{
    public class ImageTests
    {
        // nameOfMethodBeingTested_Scenario_ExpectedBehaviour()
        [Theory]
        [InlineData(null, null)]
        [InlineData("https://picsum.photos/200", null)]
        [InlineData(null, "")]
        public void Image_CreationWithNull_ShouldThrow(string url, string description)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Image(url, description));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("This is not a link", "")]
        public void Image_CreationWithIncorrectUrl_ShouldThrow(string url, string description)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new Image(url, description));
            Assert.Throws<ArgumentException>(() => new Image(url));
        }

        [Theory]
        [InlineData("http://heimdal.be", "")]
        [InlineData("https://picsum.photos/200", "This is a description")]
        public void Image_CreationWithValidParameters_ShouldNotThrow(string url, string description)
        {
            // Arrange
            Image image;
            Image imageWithOnlyUrl;

            // Act
            image = new Image(url, description);
            imageWithOnlyUrl = new Image(url);

            // Assert
            Assert.IsType<Image>(image);
            Assert.IsType<Image>(imageWithOnlyUrl);
        }

        [Theory]
        [InlineData(null)]
        public void Image_SetDescription_ShouldThrow(string description)
        {
            // Arrange
            Image image;

            // Act
            image = new Image("https://heimdal.be");

            // Assert
            Assert.Throws<ArgumentNullException>(() => image.Description = description);
        }

        [Theory]
        [InlineData("")]
        [InlineData("This is a description")]
        public void Image_SetDescription_ShouldNotThrow(string description)
        {
            // Arrange
            Image image;

            // Act
            image = new Image("https://heimdal.be");
            image.Description = description;

            // Assert
            Assert.Equal(description, image.Description);
        }
    }
}
