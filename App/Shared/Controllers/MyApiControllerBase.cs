using Microsoft.AspNetCore.Mvc;

namespace svc.App.Shared.Controllers;

/// <summary>
/// API 컨트롤러의 기본 클래스
/// </summary>
public class MyApiControllerBase<T> : ControllerBase where T: MyApiControllerBase<T>
{
    /// <summary>
    /// logger
    /// </summary>
    public readonly ILogger? _logger;

    public MyApiControllerBase(){}

    public MyApiControllerBase(ILogger<T> logger)
    {
        _logger = logger;
    }
    
}
