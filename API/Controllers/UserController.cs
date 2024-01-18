﻿using Application.Commands.UserCommands.RegisterUser;
using Application.Dtos;
using Application.Queries.UserQueries;
using Application.Validators;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly PasswordValidator _passwordValidator;
        private readonly UsernameValidator _usernameValidator;


        public UserController(IMediator mediator, IUserRepository userRepository, PasswordValidator passwordValidator, UsernameValidator usernameValidator)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
            _usernameValidator = usernameValidator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(string username, string password)
        {
            var validationResult = _usernameValidator.Validate(username);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var passwordResult = _passwordValidator.Validate(password);
            if (!passwordResult.IsValid)
            {
                return BadRequest(passwordResult.Errors);
            }

            var user = await _mediator.Send(new RegisterUserCommand { Username = username, Password = password });
            return Ok(new { user.UserId, user.UserName }); ;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(string username, string password)
        {
            var usernameResult = _usernameValidator.Validate(username);
            if (!usernameResult.IsValid)
            {
                return BadRequest(usernameResult.Errors);
            }

            var passwordResult = _passwordValidator.Validate(password);
            if (!passwordResult.IsValid)
            {
                return BadRequest(passwordResult.Errors);
            }


            var user = await _mediator.Send(new LoginUserQuery { Username = username, Password = password });

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Return some kind of success response, without JWT for now
            // You might want to return a user object or a simple success 
            return Ok(new { Message = "Login successful", user.UserId, user.UserName });
        }


    }
}
