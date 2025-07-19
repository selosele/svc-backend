using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Svc.App.Shared.Filters;

/// <summary>
/// 비즈니스 로직 예외 Exception Filter
/// </summary>
public class BizExceptionFilter : IExceptionFilter
{
    #region [메서드]
    /// <inheritdoc/>
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
    #endregion
    
}
