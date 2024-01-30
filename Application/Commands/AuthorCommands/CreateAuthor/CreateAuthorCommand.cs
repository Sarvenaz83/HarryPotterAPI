﻿using Application.Dtos.AuthorDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.AuthorCommands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<CreateAuthorResponseDto>
    {
        public CreateAuthorCommand(AuthorDto newAuthor)
        {
            NewAuthor = newAuthor;
        }
        public AuthorDto NewAuthor { get; }
    }
}
