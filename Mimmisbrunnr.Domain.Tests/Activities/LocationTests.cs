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
        //
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





    }
}
