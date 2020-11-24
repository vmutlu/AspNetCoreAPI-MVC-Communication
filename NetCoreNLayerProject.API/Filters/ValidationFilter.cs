using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCoreNLayerProject.API.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreNLayerProject.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Status = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(x => x.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDTO.Errors.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorDTO);
            }
        }
    }
}
