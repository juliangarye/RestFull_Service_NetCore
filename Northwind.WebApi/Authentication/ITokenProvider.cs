using Microsoft.IdentityModel.Tokens;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreationToken(User user, DateTime expiry);

        TokenValidationParameters GetValidationParameters();

    }
}
