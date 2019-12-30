using DinosaursPark.WebApplication.Requests;
using FluentValidation;

namespace DinosaursPark.WebApplication.Validation
{
    public class GetByIdRequestValidator : BaseValidator<GetByIdRequest>
    {
        public GetByIdRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithErrorCode(ErrorCodes.IdIsEmpty);
        }
    }
}