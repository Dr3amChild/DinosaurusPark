using DinosaurusPark.WebApplication.Requests;
using FluentValidation;

namespace DinosaurusPark.WebApplication.Validation
{
    public class GetAllRequestValidator : BaseValidator<GetAllRequest>
    {
        public GetAllRequestValidator()
        {
            RuleFor(r => r.Count).GreaterThan(0).WithErrorCode(ErrorCodes.CountIsNegativeOrZero);
            RuleFor(r => r.Offset).GreaterThanOrEqualTo(0).WithErrorCode(ErrorCodes.OffsetIsNegative);
        }
    }
}