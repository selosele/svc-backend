using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace svc.App.Shared.Controllers;

/// <summary>
/// API 컨트롤러의 기본 클래스
/// </summary>
public class MyApiControllerBase<T> : ControllerBase where T: MyApiControllerBase<T>
{
    /// <summary>
    /// logger 인스턴스
    /// </summary>
    protected readonly ILogger? _logger;

    /// <summary>
    /// 객체 매핑 패키지(AutoMapper) 인스턴스
    /// </summary>
    protected readonly IMapper? _mapper;

    protected MyApiControllerBase(){}

    protected MyApiControllerBase(
        ILogger<T> logger,
        IMapper mapper
    )
    {
        _logger = logger;
        _mapper = mapper;
    }
    
}
