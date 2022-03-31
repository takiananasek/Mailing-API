using ClientApi.Data;
using ClientApi.DTO;
using ClientApi.Models;
using ClientApi.Models.NonPersistentModels;
using ClientApi.Models.NonPersistentModels.Email;
using ClientApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private SmtpClientFactory _clientFactory;
        public readonly IClientRepository _iClientRepository;
        public readonly IUserRepository _iUserRepository;
        public readonly IClientRequestRepository _iClientRequestRepository;

        public EmailController(SmtpClientFactory clientFactory, IUserRepository userRepository, IClientRepository clientRepository, IClientRequestRepository clientRequestRepository)
        {
            _clientFactory = clientFactory;
            _iUserRepository = userRepository;
            _iClientRepository = clientRepository;
            _iClientRequestRepository = clientRequestRepository;

        }


        // POST api/<EmailController>
        [HttpPost("SendEmailPrimary")]
        public ActionResult SendEmail([FromBody] EmailData emailData)
        {
            Guid operationId = Guid.NewGuid(); //httpcontext pobierz operationId
            var user = _iUserRepository.Users.Where(u => u.UserId == emailData.UserId).FirstOrDefault();
            if (user == null)
            {
                return new BadRequestObjectResult(new SendEmailResponseDTO() { OperationId = operationId });
            }

            var client = _iClientRepository.Clients.Where(c => c.ClientId == emailData.ClientId).FirstOrDefault();

            if (client == null || client != user.Client)
            {
                return new BadRequestObjectResult(new SendEmailResponseDTO() { OperationId = operationId });
            }

            var apiSmtpClient = _clientFactory.GetInstance(SmtpServerInstance.Primary);
            var email = apiSmtpClient.PrepareMessage(emailData);
            apiSmtpClient.Send(email);

            ClientRequest clientRequest = new ClientRequest
            {
                Id = Guid.NewGuid(),
                OperationId = operationId,
                EventType = EventType.SentEmail,
                Client = client,
                ClientId = client.ClientId

            };

            _iClientRequestRepository.Add(clientRequest);
            _iClientRequestRepository.SaveChanges();
            return new OkObjectResult(new SendEmailResponseDTO() { OperationId = operationId });
        }
    }
}
