using ClientApi.Controllers.Filters;
using ClientApi.Data;
using ClientApi.DTO;
using ClientApi.Models;
using ClientApi.Models.NonPersistentModels.Email;
using ClientApi.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public readonly SmtpClientFactory _sMTPClientFactory;
        public readonly SmtpClientFactory _clientFactory;
        public UserController(IUserRepository userRepository, SmtpClientFactory sMTPClientFactory, SmtpClientFactory clientFactory)
        {
            _userRepository = userRepository;
            _sMTPClientFactory = sMTPClientFactory;
            _clientFactory = clientFactory;
        }

        [ApiResultFilterAttribute]
        [ApiExceptionFilter]
        [HttpPost("RegisterNewUser")]
        public ActionResult RegisterNewUser([FromBody] RegisterUserRequestDTO registerRequest)
        {
            var foundClient = _userRepository.Clients.Where(c => c.ClientId == registerRequest.ClientId).Any();
            if (!foundClient)
            {
                return new BadRequestObjectResult(new RegisterUserResponseDTO() { }) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            var user = new User()
            {
                UserId = Guid.NewGuid(),
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Activated = false,
                CreatedAt = DateTime.Now,
                ClientId = registerRequest.ClientId
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();
            //Send email with activation link
            var notificationUrl = this.Url.Action(
                   nameof(Activate),
                   this.ControllerContext.ActionDescriptor.ControllerName,
                   null,
                   this.HttpContext.Request.Protocol,
                   this.HttpContext.Request.Host.ToString());
            notificationUrl = notificationUrl + "?code=" + Guid.NewGuid().ToString() + "&linkType=Activate&userId=" + user.UserId;

            EmailData emailData = new EmailData()
            {
                Message = "Please activate your account:" + notificationUrl,
                EmailAdress = user.Email,

            };

            var apiSmtpClient = _clientFactory.GetInstance(SmtpServerInstance.Primary);
            var email = apiSmtpClient.PrepareMessage(emailData);
            apiSmtpClient.Send(email);


            //-------------------------------
            return new OkObjectResult(new RegisterUserResponseDTO() { UserId = user.UserId });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("Activate")]
        public ActionResult Activate([FromQuery] Guid code, [FromQuery] LinkType linkType, [FromQuery]Guid userId)
        {
            return Ok();
        }
    }
}
