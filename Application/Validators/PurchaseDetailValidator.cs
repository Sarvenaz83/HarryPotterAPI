﻿using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class PurchaseDetailValidator : AbstractValidator<Receipt>
    {
        public PurchaseDetailValidator()
        {
            RuleFor(dto => dto.PurchaseHistoryId).NotEmpty().WithMessage("PurchaseId cannot be empty.");
            RuleFor(dto => dto.BookId).NotEmpty().WithMessage("BookId cannot be empty.");
            RuleFor(dto => dto.Quantity).GreaterThan(0).WithMessage("Quantity should be greater than 0.");
            RuleFor(dto => dto.DateDetail).NotEmpty().WithMessage("DateDetail cannot be empty.");
        }
    }
}
