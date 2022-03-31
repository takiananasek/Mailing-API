using ClientApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace ClientApi.Controllers.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            //jezeli zdarzyl sie jakis wyjatek to bedzie on przypisany pod context.Exception
            //w tym wypadku zwroc kod 500 z operationId opakowanym w Twoim ErrorResponseDTO
            if (context.Exception != null)
            {
                context.Result = new ObjectResult(new ErrorResponseDTO
                {
                    OperationId = Guid.NewGuid()
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
//poczytaj o unit testach i sprobuj zaimplementowac taki test dla swojego SHA256 encoder
//jak Ci to pojdzie dobrze stworz testy dla calego ClientControllera
//testy musza byc w osobnym projekcie ClientApi.Tests uzyj Xunit i Moq 