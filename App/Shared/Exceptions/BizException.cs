namespace Svc.App.Shared.Exceptions;

/// <summary>
/// 비즈니스 로직 예외 Exception 클래스
/// </summary>
public class BizException : Exception
{
    #region [생성자]
    public BizException(string message) : base(message) {}
    #endregion
}
