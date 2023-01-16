using System.Text;
using Hotels.API.Contracts;
using Hotels.API.Models.Users;
using Hotels.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using static NuGet.Protocol.Core.Types.Repository;

namespace Hotels.API.Tests
{

    public class Tests
    {
        IAuthManager _authManager;
        private IConfiguration _configuration;
        
        [SetUp]
        public void Setup()
        {
            var builder = WebApplication.CreateBuilder();
            _configuration = builder.Configuration;
            _authManager = new AuthManager(_configuration);
        }

        [Test]
        [Description("Must return JTW - not NULL")]
        public void Test_Login()
        {
            LoginDTO login = new LoginDTO
            {
                Email = "vedran@gmail.com",
                Password = "123456"
            };

            // Act
            var result = _authManager.Login(login);

            // Assert
            Assert.That(result.Result, Is.Not.EqualTo(null));
        }
    }
}