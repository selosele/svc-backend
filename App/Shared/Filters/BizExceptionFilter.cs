using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace svc.App.Shared.Filters;

/// <summary>
/// 비즈니스 로직 예외 Exception Filter 클래스
/// </summary>
public class BizExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new
        {
            message = context.Exception.Message,
        })
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
    }
    
}
