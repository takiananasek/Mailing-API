using ClientApi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.DTO
{
    public class RegisterRequestDTOTests
    {
        [Fact]
        public void When_I_Dont_Provide_Email_Address_The_Model_Is_InValid()
        {
            var registerRequestDTO = new RegisterClientRequestDTO
            {
                Secret = "1234567890234"
            };
            var context = new ValidationContext(registerRequestDTO, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(registerRequestDTO, context, results, true);
            Assert.False(isValid);

        }

        [Fact]
        public void When_I_Provide_Email_The_Model_Is_Valid()
        {
            var registerRequestDTO = new RegisterClientRequestDTO
            {
                Secret = "1234567890234",
                Email = "alamakota@gmail.com"
            };
            var context = new ValidationContext(registerRequestDTO, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(registerRequestDTO, context, results, true);
            Assert.True(isValid);
        }

        [Fact]
        public void When_I_Provide_Too_Short_Secret_The_Model_Is_Invalid()
        {
            var registerRequestDTO = new RegisterClientRequestDTO
            {
                Secret = "12",
                Email = "alamakota@gmail.com"
            };
            var context = new ValidationContext(registerRequestDTO, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(registerRequestDTO, context, results, true);
            Assert.False(isValid);
        }
        [Fact]
        public void When_I_Provide_Too_Long_Secret_The_Model_Is_Invalid()
        {
            var registerRequestDTO = new RegisterClientRequestDTO
            {
                Secret = "123333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333",
                Email = "alamakota@gmail.com"
            };
            var context = new ValidationContext(registerRequestDTO, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(registerRequestDTO, context, results, true);
            Assert.False(isValid);
        }




        //napisz test sprawdzajacy poprawne maile

        //niepoprawne maile

        //za krotki i za dlugi sekret
    }
}
