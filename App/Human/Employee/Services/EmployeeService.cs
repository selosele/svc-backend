using SmartSql.AOP;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Mappers;

namespace Svc.App.Human.Employee.Services;

/// <summary>
/// 직원 서비스 클래스
/// </summary>
public class EmployeeService
{
    #region Fields
    private readonly EmployeeMapper _employeeMapper;
    private readonly WorkHistoryMapper _workHistoryMapper;
    #endregion
    
    #region Constructor
    public EmployeeService(
        EmployeeMapper employeeMapper,
        WorkHistoryMapper workHistoryMapper
    )
    {
        _employeeMapper = employeeMapper;
        _workHistoryMapper = workHistoryMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> GetEmployee(GetEmployeeRequestDTO dto)
    {
        var employee = await _employeeMapper.GetEmployee(dto);
        if (employee != null)
        {
            employee.WorkHistories = await _workHistoryMapper.ListWorkHistory(new GetWorkHistoryRequestDTO { EmployeeId = employee.EmployeeId });
        }
        return employee;
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> UpdateEmployee(UpdateEmployeeRequestDTO dto)
    {
        await _employeeMapper.UpdateEmployee(dto);
        return await GetEmployee(new GetEmployeeRequestDTO { EmployeeId = dto.EmployeeId });
    }

    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<WorkHistoryResponseDTO>> ListWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryMapper.ListWorkHistory(dto);

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<WorkHistoryResponseDTO> GetWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryMapper.GetWorkHistory(dto);

    /// <summary>
    /// 근무이력을 추가/수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> SaveWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(dto.QuitYmd))
        {
            var updateEmployeeRequestDTO = new UpdateEmployeeRequestDTO
            {
                WorkHistory = new SaveWorkHistoryRequestDTO
                {
                    CompanyId = dto.CompanyId
                },
                EmployeeId = dto.EmployeeId,
                UpdaterId = dto.UpdaterId
            };
            await _employeeMapper.UpdateEmployee(updateEmployeeRequestDTO);
        }

        // 근무이력 정보를 조회해서
        var workHistory = await _workHistoryMapper.GetWorkHistory(new GetWorkHistoryRequestDTO
            {
                EmployeeId = dto.EmployeeId,
                CompanyId = dto.CompanyId
            }
        );
        if (workHistory != null)
        {
            // 있으면 수정을 하고
            return await _workHistoryMapper.UpdateWorkHistory(dto);
        }
        // 없으면 추가를 한다.
        return await _workHistoryMapper.AddWorkHistory(dto);
    }

    /// <summary>
    /// 근무이력을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<int> AddWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(dto.QuitYmd))
        {
            var updateEmployeeRequestDTO = new UpdateEmployeeRequestDTO
            {
                WorkHistory = new SaveWorkHistoryRequestDTO
                {
                    CompanyId = dto.CompanyId
                },
                EmployeeId = dto.EmployeeId,
                UpdaterId = dto.UpdaterId
            };
            await _employeeMapper.UpdateEmployee(updateEmployeeRequestDTO);
        }
        return await _workHistoryMapper.AddWorkHistory(dto);
    }

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(dto.QuitYmd))
        {
            var updateEmployeeRequestDTO = new UpdateEmployeeRequestDTO
            {
                WorkHistory = new SaveWorkHistoryRequestDTO
                {
                    CompanyId = dto.CompanyId
                },
                EmployeeId = dto.EmployeeId,
                UpdaterId = dto.UpdaterId
            };
            await _employeeMapper.UpdateEmployee(updateEmployeeRequestDTO);
        }
        return await _workHistoryMapper.UpdateWorkHistory(dto);
    }

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveWorkHistory(int? userId, int workHistoryId)
        => await _workHistoryMapper.RemoveWorkHistory(userId, workHistoryId);
    #endregion
    
}

