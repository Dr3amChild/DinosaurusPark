using DinosaursPark.WebApplication.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace DinosaursPark.WebApplication.Filters
{
    public sealed class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            IEnumerable<ErrorResponse> errors;

            if (context.HttpContext.Items.TryGetValue(nameof(ValidationResult), out var value)
                && value is ValidationResult validationResult)
            {
                errors = validationResult.Errors.Select(e => new ErrorResponse(e.ErrorCode, e.ErrorMessage));
            }
            else
            {
                errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => new ErrorResponse(e.ErrorMessage, e.ErrorMessage))
                    .ToArray();
            }

            context.Result = new BadRequestObjectResult(new CollectionResponse<ErrorResponse>(errors));
        }
    }
}
