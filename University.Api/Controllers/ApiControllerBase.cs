using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace University.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
                return Ok(result);

            var errorsDictionary = new Dictionary<string, string[]> { { "Messages", _errors.ToArray() } };

            var validationProblemDetails = new ValidationProblemDetails(errorsDictionary);

            return BadRequest(validationProblemDetails);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}
