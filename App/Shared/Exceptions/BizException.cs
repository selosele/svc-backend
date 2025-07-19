namespace Svc.App.Shared.Exceptions;

/// <summary>
/// 비즈니스 로직 예외 Exception
/// </summary>
public class BizException(string message) : Exception(message)
{
    
}
