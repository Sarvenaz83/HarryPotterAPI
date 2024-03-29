using Application.Dtos.BookDtos;
using MediatR;

namespace Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookByIdDto>
    {
        public Guid Id { get; set; }
        public GetBookByIdQuery(Guid bookId)
        {
            Id = bookId;
        }

    }
}
