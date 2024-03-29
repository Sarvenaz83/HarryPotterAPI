﻿using Domain.Models;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }
        public Guid AuthorId { get; }
    }
}
