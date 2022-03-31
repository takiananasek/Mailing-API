using ClientApi.Models;
using ClientApi.Models.NonPersistentModels.Email;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace ClientApi.Service
{
    public class SmtpClientFactory
    {
        private readonly SmtpConfiguration _smtpConfiguration;

        public SmtpClientFactory(IOptions<SmtpConfiguration> smtpConfigurationOptions)
        {
            _smtpConfiguration = smtpConfigurationOptions.Value;
        }

        public ApiSmtpClient GetInstance(SmtpServerInstance smtpServerInstance)
        {
            if (smtpServerInstance == SmtpServerInstance.Primary)
            {
                return new ApiSmtpClient(_smtpConfiguration.Primary);
            }
            return new ApiSmtpClient(_smtpConfiguration.Secondary);

        }
    }
}
