namespace svc.App.Shared.Exceptions;

/// <summary>
/// 비즈니스 로직 예외 Exception 클래스
/// </summary>
public class BizException : Exception
{
    #region Constructor
    public BizException(string message) : base(message) {}
    #endregion
}
