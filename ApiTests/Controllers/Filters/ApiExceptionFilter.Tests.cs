using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.Controllers.Filters
{
    public class ApiExceptionFilter
    {
        [Fact]
        public void When_Exception_Is_Thrown_It_Is_Then_Http_500_Is_Being_Returned_With_OperationId()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();

            // Act

            // Assert
        }

    }
}
