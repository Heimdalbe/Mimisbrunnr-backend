using Mimmisbrunnr.Domain.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Mimmisbrunnr.Domain.Tests.Activities
{
    public class LocationTests
    {
        
        [Theory]
        [InlineData(null, null, null)]
        [InlineData(null, "Meerstraat", "9000 Gent")]
        [InlineData("Comic Sans", null, "9000 Gent")]
        [InlineData("Comic Sans", "Meerstraat", null)]
        public void Location_CreationWithNull_ShouldThrow(string title, string address, string city)
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Location(title, address, city));
        }

        [Theory]
        [InlineData("Kortrijk")]
        [InlineData("Antwerpen")]
        public void Location_SetCity_ShouldNotThrow(string city)
        {
            //Arrange
            Location location;

            //Act
            location = new Location("Comic Sans", "Meerstraat", "9000 Gent");
            location.City = city;

            //Assert
            Assert.Equal(city, location.City);
        }

        [Theory]
        [InlineData(null)]
        public void Location_SetCityWithNull_ShouldThrow(string city)
        {
            //Arrange
            Location location;

            //Act
            location = new Location("Comic Sans", "Meerstraat", "9000 Gent");

            //Assert
            Assert.Throws<ArgumentNullException>(() => location.City = city);
        }

        [Theory]
        [InlineData("")]
        public void Location_SetCityWithEmptyCity_ShouldThrow(string city)
        {
            //Arrange
            Location location;

            //Act
            location = new Location("Comic Sans", "Meerstraat", "9000 Gent");

            //Assert
            Assert.Throws<ArgumentException>(() => location.City = city);
        }


    }
}
