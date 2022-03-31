using ClientApi.Data;
using Microsoft.AspNetCore.Mvc;
using ClientApi.DTO;
using ClientApi.Models;
using ClientApi.Utils;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using ClientApi.Controllers.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [ApiResultFilter]
        [ApiExceptionFilter]
        [HttpPost("RegisterNewClient")]
        public ActionResult RegisterNewClient([FromBody] RegisterClientRequestDTO clientRequest)
        {

            //rozszerz definicje tej metody tak aby sprawdzala czy w bazie danych jest juz taki email
            //jak jest to ma zwrocic kod HTTP odpowiadjacy za duplikate//409
            //aby do zrobic musisz dodac do ClientRepository metode EmailExists/IsDuplicate...
            //zamokuj te metode w tescie tak by raz zwracala false(rozszerz test z zajec)
            //za drugim razem ma zwracac true(w innym tecie) i sprawdz w tescie czy dostaniesz HTTP Duplicate

            if (!_clientRepository.isDuplicate(clientRequest))
            {
                Client finalClient = new Client()
                    {
                        Email = clientRequest.Email,
                        Secret = Encryption.Sha256(clientRequest.Secret),
                        Enabled = true
                    };
                 _clientRepository.Add(finalClient);
                 _clientRepository.SaveChanges();

                return new OkObjectResult(new RegisterClientResponseDTO() { ClientId = finalClient.ClientId });
            }
            return new ConflictObjectResult(new RegisterClientResponseDTO() { });
        }

        [ApiResultFilter]
        [ApiExceptionFilter]
        [HttpDelete("DeleteClient")]
        public ActionResult DeleteClient([FromBody] DeleteClientRequestDto deleteRequest)
        {
            deleteRequest.Secret = Encryption.Sha256(deleteRequest.Secret);
            try
            {
                var clientToDelete = _clientRepository.Clients.Where(c => c.ClientId == deleteRequest.Id).First();
               _clientRepository.Remove(clientToDelete);
               _clientRepository.SaveChanges();
            }
            catch(Exception e)
            {

                return new BadRequestObjectResult(new DeleteClientResponseDTO() { ClientId = deleteRequest.Id });
            };

            return new OkObjectResult(new RegisterClientResponseDTO()
            {
                ClientId = Guid.NewGuid()
            });        
        }
    }
}
