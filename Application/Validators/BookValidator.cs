﻿using Application.Dtos.BookDtos;
using FluentValidation;

namespace Application.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(dto => dto.Title).NotEmpty().WithMessage("Title cannot be empty.");
            RuleFor(dto => dto.AuthorId).NotEmpty().WithMessage("Author Id can not be empty.");
            RuleFor(dto => dto.Genre).NotEmpty().WithMessage("Genre cannot be empty.");
            RuleFor(dto => dto.Pages).GreaterThan(0).WithMessage("Pages should be greater than 0.");
            RuleFor(dto => dto.Rating).InclusiveBetween(0, 5).WithMessage("Rating should be between 0 and 5.");
        }
    }
}
