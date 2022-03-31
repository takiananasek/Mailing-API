using ClientApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace ClientApi.Controllers.Filters
{
    public class ApiResultFilterAttribute : Attribute, IAlwaysRunResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = (IStatusCodeActionResult)context.Result;
            if(result.StatusCode == (int)( HttpStatusCode.BadRequest))
            {
                context.Result = new BadRequestObjectResult(new ErrorResponseDTO
                {
                    OperationId = Guid.NewGuid()
                });
            }
        }
    }
}
