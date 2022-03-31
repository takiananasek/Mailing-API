using ClientApi.Controllers;
using ClientApi.Data;
using ClientApi.DTO;
using ClientApi.Models;
using ClientApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests
{
    public class ClientControllerTests
    {

        //post method tests

        [Fact]
        public void RegisterNewClient_Saves_Client_In_Database_And_Returns_200()
        {
            // Arrange 
            var registerRequestDTO = new RegisterClientRequestDTO
            {
                Email = "test@test.com",
                Secret = "secret"
            };
            var expectedClient = new Client()
            {
                Email = registerRequestDTO.Email,
                Secret = Encryption.Sha256(registerRequestDTO.Secret),
                Enabled = true
            };
            var clientRepositoryMock = new Mock<IClientRepository>();
            clientRepositoryMock.Setup(x => x.isDuplicate(It.IsAny<RegisterClientRequestDTO>())).Returns(false);
            clientRepositoryMock
                .Setup(x => x.Add(It.IsAny<Client>()))
                .Callback<Client>(x =>
                {
                    Assert.Equal(expectedClient.Email, x.Email);
                    Assert.Equal(expectedClient.Secret, x.Secret);
                    Assert.Equal(expectedClient.Enabled, x.Enabled);
                }
                );
            var sut = new ClientController(clientRepositoryMock.Object);

            // Act
            var result = sut.RegisterNewClient(registerRequestDTO);


            // Assert
            clientRepositoryMock.Verify(x => x.SaveChanges(), Times.Once);
            var actualResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, actualResult.StatusCode);
        }


        [Fact]
        public void RegisterNewClient_Returns_409_When_Duplicate()
        {
            //Arrange
            var registerRequestDTO = new RegisterClientRequestDTO
            {
                Email = "test@test.com",
                Secret = "secret"
            };
            var clientRepositoryMock = new Mock<IClientRepository>();
            clientRepositoryMock.Setup(x => x.isDuplicate(It.IsAny<RegisterClientRequestDTO>())).Returns(true);
            var sut = new ClientController(clientRepositoryMock.Object);

            //Act
            var result = sut.RegisterNewClient(registerRequestDTO);

            //Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

    }
}