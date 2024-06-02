using svc.Models.Entities.Code;

namespace svc.Services.Code;

public interface ICodeService
{
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    Task<List<CodeEntity>> ListCode();
}

