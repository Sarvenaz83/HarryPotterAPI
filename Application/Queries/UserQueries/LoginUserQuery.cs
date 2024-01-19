﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserQueries
{
    public class LoginUserQuery : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
