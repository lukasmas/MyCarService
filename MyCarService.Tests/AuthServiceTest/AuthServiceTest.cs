using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyCarService.AuthServices;


namespace MyCarService.Tests.AuthServiceTest
{
    public class AuthServiceTest
    {
        AuthService authService;

        public AuthServiceTest()
        {
            authService = new AuthService("TOP_SECRET_TOKEN", 10);
        }

        [Fact]
        public void HashPasswordTest()
        {
            string password = "topSecretPassword";
            string hashedPassword = authService.HashPassword(password);

            Assert.True(authService.VerifyPassword(password, hashedPassword));
        }

        [Fact]
        public void GenerateAuthData()
        {
            string id = "abc-123";
            var date = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()+10;
            var authData = authService.GetAuthData(id);
            Assert.NotNull(authData);
            Assert.Equal(id, authData.Id);
            Assert.Equal(date, authData.TokenExpirationTime);
        }
    }
}
