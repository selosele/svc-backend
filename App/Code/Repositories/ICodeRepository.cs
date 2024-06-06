
using svc.App.Code.Models.Entities;

namespace svc.App.Code.Repositories;

public interface ICodeRepository
{
    /// <summary>
    /// 코드 목록을 조회한다.
    /// </summary>
    Task<List<CodeEntity>> ListCode();
}
