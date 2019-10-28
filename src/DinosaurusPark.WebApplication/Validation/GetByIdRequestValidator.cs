using DinosaurusPark.WebApplication.Requests;
using FluentValidation;

namespace DinosaurusPark.WebApplication.Validation
{
    public class GetByIdRequestValidator : BaseValidator<GetByIdRequest>
    {
        public GetByIdRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithErrorCode(ErrorCodes.IdIsEmpty);
        }
    }
}