using ClientApi.Models;
using ClientApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ApiTests.Service
{
    public class ClientVerificationForEmailTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public ClientVerificationForEmailTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new Client() { ClientId = Guid.Empty}, new User() { ClientId=Guid.Empty} };
            yield return new object[] { new Client() { ClientId=Guid.Parse("931554c3-e3a3-4878-9643-29d587337adb") }, new User() { ClientId = Guid.Parse("931554c3-e3a3-4878-9643-29d587337adb") } };
            yield return new object[] { new Client() {ClientId = Guid.Parse("eca4a860-485a-4366-b1d0-da598089c6f8") }, new User() {ClientId = Guid.Parse("eca4a860-485a-4366-b1d0-da598089c6f8") } };
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void CanBeSent_ForMatchingClientAndUserID_ReturnsTrue(Client client, User user)
        {
            //arrange

            //act
            var result = ClientVerificationForEmail.EmailCanBeSent(user, client);
            //assert
            _testOutputHelper.WriteLine($"Testing: {client.ClientId} clientID with {user.ClientId} user Id");
            Assert.True(result);
        }

        
    }
}
