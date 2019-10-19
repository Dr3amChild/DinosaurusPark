﻿using DinosaurusPark.WebApplication.Requests;
using FluentValidation;

namespace DinosaurusPark.WebApplication.Validation
{
    public class PagingRequestValidator : BaseValidator<PagingRequest>
    {
        public PagingRequestValidator()
        {
            RuleFor(r => r.PageSize).GreaterThan(0).WithErrorCode(ErrorCodes.PageSizeIsNegativeOrZero);
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(0).WithErrorCode(ErrorCodes.PageNumberIsNegativeOrZero);
        }
    }
}