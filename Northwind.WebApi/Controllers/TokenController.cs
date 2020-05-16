﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using Northwind.WebApi.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{

    [Route("api/token")]
    //[EnableCors("ApiCorsPolicy")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private ITokenLogic _logic;

        public TokenController(ITokenProvider tokenProvider, ITokenLogic logic)
        {
            _tokenProvider = tokenProvider;
            _logic = logic;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _logic.ValidateUser(userLogin.Email, userLogin.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreationToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480//minutes
            };
            return token;
        }

    }
}
