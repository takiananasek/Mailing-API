using ClientApi.DTO.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.DTO.Attributes
{
   public class Tests
    {

        [Fact]
        public void test()
        {
            NonEmptyGuidAttribute attribute = new NonEmptyGuidAttribute();
            Guid testCase = Guid.Empty;
            var isValid = attribute.IsValid(testCase);
            Assert.False(isValid);
        }
    }
}
