using SmartSql.AOP;
using Svc.App.Human.Department.Models.DTO;
using Svc.App.Human.Department.Repositories;

namespace Svc.App.Human.Department.Services;

/// <summary>
/// 부서 서비스 클래스
/// </summary>
public class DepartmentService
{
    #region Fields
    private readonly IDepartmentRepository _departmentRepository;
    #endregion
    
    #region Constructor
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 부서 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<DepartmentResponseDTO>> ListDepartment(GetDepartmentRequestDTO? getDepartmentRequestDTO)
    {
        // 회사별 조회 여부가 Y이면 회사별 부서 목록을 조회하고
        if (getDepartmentRequestDTO?.GetByCompanyYn == "Y")
        {
            return await _departmentRepository.ListDepartmentByCompany(getDepartmentRequestDTO);
        }
        // N이거나 없으면 전체 부서 목록을 조회한다.
        return await _departmentRepository.ListDepartment(getDepartmentRequestDTO!);
    }
    #endregion
    
}

