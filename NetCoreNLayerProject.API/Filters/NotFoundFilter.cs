using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreNLayerProject.API.DTOs;
using NetCoreNLayerProject.Core.Service;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
                await next();
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Status = 404;
                errorDTO.Errors.Add($"Id'si {id} olan ürün veri tabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDTO);
            }
        }
    }
}
