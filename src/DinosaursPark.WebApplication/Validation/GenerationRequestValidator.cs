using DinosaursPark.WebApplication.Requests;
using FluentValidation;

namespace DinosaursPark.WebApplication.Validation
{
    public class GenerationRequestValidator : BaseValidator<GenerationRequest>
    {
        public GenerationRequestValidator()
        {
            RuleFor(r => r.Data).NotNull().WithErrorCode(ErrorCodes.BodyIsNull);
            RuleFor(r => r.Data.SpeciesCount).GreaterThan(0).WithErrorCode(ErrorCodes.SpeciesCountIsNegativeOrZero);
            RuleFor(r => r.Data.DinosaursCount).GreaterThan(0).WithErrorCode(ErrorCodes.DinosaursCountIsNegativeOrZero);
        }
    }
}