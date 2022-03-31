using ClientApi.Data;
using ClientApi.Models;

namespace ClientApi.Service
{
    public class ClientVerificationForEmail
    {
        public static bool EmailCanBeSent( User user, Client client)
        {
            var matches = user.ClientId == client.ClientId;
            return matches;
        }

    }
}
