using svc.Models.Entities.Code;

namespace svc.Repositories.Code;

public interface ICodeRepository
{
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    Task<List<CodeEntity>> ListCode();
}
