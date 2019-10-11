using DinosaurusPark.WebApplication.Requests;
using FluentValidation;

namespace DinosaurusPark.WebApplication.Validation
{
    public class GetAllRequestValidator : AbstractValidator<GetAllRequest>
    {
        public GetAllRequestValidator()
        {
            RuleFor(r => r.Count).NotEmpty().GreaterThan(0).WithErrorCode(ErrorCodes.CountIsNegativeOrZero);
            RuleFor(r => r.Offset).NotEmpty().GreaterThanOrEqualTo(0).WithErrorCode(ErrorCodes.OffsetIsNegative);
        }
    }
}
