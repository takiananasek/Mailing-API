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
    public class RegisterUserDTO
    {
        [Fact]
        public void When_I_Dont_Enter_Email_Model_Is_Invalid()
        {
            var model = new RegisterUserRequestDTO()
            {
                Password = "12345678999999999",
                ClientId = Guid.NewGuid()
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results,true);
            Assert.False(isValid);
        }

        [Fact]
        public void When_I_Dont_Enter_Password_Model_Is_Invalid()
        {
            var model = new RegisterUserRequestDTO()
            {
                Email = "abc@gmail.com",
                ClientId = Guid.NewGuid()
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results,true);
            Assert.False(isValid);
        }

        [Fact]
        public void When_I_Dont_Enter_Client_Id_Model_Is_Invalid()
        {
            var model = new RegisterUserRequestDTO()
            {
                Email = "abc@gmail.com",
                Password = "123456789090"
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            Assert.False(isValid);
        }

        [Fact]
        public void When_I__Enter_Too_Long_Password_Model_Is_Invalid()
        {
            var model = new RegisterUserRequestDTO()
            {
                Email = "abc@gmail.com",
                Password = "1234567890922222222222222222222222222222222222222222222222222222222222222222222222222222220",
                ClientId = Guid.NewGuid()
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results,true);
            Assert.False(isValid);
        }

        [Fact]
        public void When_I__Enter_Too_Short_Password_Model_Is_Invalid()
        {
            var model = new RegisterUserRequestDTO()
            {
                Email = "abc@gmail.com",
                Password = "1230",
                ClientId = Guid.NewGuid()
            };

            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results,true);
            Assert.False(isValid);
        }

    }
}
