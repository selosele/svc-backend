using svc.App.Human.Department.Models.DTO;

namespace svc.App.Human.Department.Repositories;

/// <summary>
/// 부서 리포지토리 인터페이스
/// </summary>
public interface IDepartmentRepository
{
    #region Methods
    /// <summary>
    /// 부서 목록을 조회한다.
    /// </summary>
    Task<IList<DepartmentResponseDTO>> ListDepartment(GetDepartmentRequestDTO getDepartmentRequestDTO);

    /// <summary>
    /// 회사별 부서 목록을 조회한다.
    /// </summary>
    Task<IList<DepartmentResponseDTO>> ListDepartmentByCompany(GetDepartmentRequestDTO? getDepartmentRequestDTO);
    #endregion

}
