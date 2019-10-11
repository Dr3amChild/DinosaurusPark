using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace DinosaurusPark.WebApplication.Validation
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IValidatorInterceptor
    {
        public ValidationContext BeforeMvcValidation(
            ControllerContext controllerContext,
            ValidationContext validationContext)
        {
            return validationContext;
        }

        public ValidationResult AfterMvcValidation(
            ControllerContext controllerContext,
            ValidationContext validationContext,
            ValidationResult result)
        {
            controllerContext.HttpContext.Items.Add("ValidationResult", result);
            return result;
        }
    }
}