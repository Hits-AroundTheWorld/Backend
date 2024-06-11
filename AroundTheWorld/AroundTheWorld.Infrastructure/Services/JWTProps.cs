using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Services
{
    public class TokenProps
    {
        public TimeSpan AccessTokenExpiration { get; private set; }
        public SecurityKey? TokenKey { get; private set; }

        private readonly IConfiguration _configuration;

        public TokenProps(IConfiguration configuration)
        {
            _configuration = configuration;
            SetExpirationTime();
            SetKey();
        }

        private void SetKey()
        {
            TokenKey =
                new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetValue<string>("ApiSettings:SecretKey")!)
                );
        }
        private void SetExpirationTime()
        {

            AccessTokenExpiration = TimeSpan.FromMinutes(
                _configuration.GetValue<double>("ApiSettings:AccessTokenExpiration", 15)
            );
        }
    }
}
