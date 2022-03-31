using ClientApi.Models;
using ClientApi.Models.NonPersistentModels.Email;
using ClientApi.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ApiTests.Email
{
    public class SmtpClientFactoryTests
    {
        //private SmtpClientFactory _clientFactory;

        //public SmtpClientFactoryTests(SmtpClientFactory clientFactory)
        //{
        //    _clientFactory = clientFactory;
        //}



        [Fact]
        public void GetInstance_ReturnsApiSmtpClientType()
        {
            //arrange
            SmtpServerInstance serverInstance1 = SmtpServerInstance.Primary;
            SmtpServerInstance serverInstance2 = SmtpServerInstance.Secondary;
            var options = Options.Create(new SmtpConfiguration() { });
            SmtpClientFactory cf = new SmtpClientFactory(options);

            //act
            var result1 = cf.GetInstance(serverInstance1);
            var result2 = cf.GetInstance(serverInstance2);
            
            //assert
            Assert.IsType<ApiSmtpClient>(result1);
            Assert.IsType<ApiSmtpClient>(result2);
        }

    }
}
