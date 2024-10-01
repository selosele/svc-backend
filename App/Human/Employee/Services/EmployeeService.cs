using SmartSql.AOP;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Repositories;

namespace Svc.App.Human.Employee.Services;

/// <summary>
/// 직원 서비스 클래스
/// </summary>
public class EmployeeService
{
    #region Fields
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IWorkHistoryRepository _workHistoryRepository;
    #endregion
    
    #region Constructor
    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IWorkHistoryRepository workHistoryRepository
    )
    {
        _employeeRepository = employeeRepository;
        _workHistoryRepository = workHistoryRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> GetEmployee(GetEmployeeRequestDTO dto)
    {
        var employee = await _employeeRepository.GetEmployee(dto);
        if (employee != null)
        {
            employee.WorkHistories = await _workHistoryRepository.ListWorkHistory(new GetWorkHistoryRequestDTO { EmployeeId = employee.EmployeeId });
        }
        return employee;
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> UpdateEmployee(UpdateEmployeeRequestDTO dto)
    {
        await _employeeRepository.UpdateEmployee(dto);
        return await GetEmployee(new GetEmployeeRequestDTO { EmployeeId = dto.EmployeeId });
    }

    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<WorkHistoryResponseDTO>> ListWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryRepository.ListWorkHistory(dto);

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<WorkHistoryResponseDTO> GetWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryRepository.GetWorkHistory(dto);

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
            await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        }

        // 근무이력 정보를 조회해서
        var workHistory = await _workHistoryRepository.GetWorkHistory(new GetWorkHistoryRequestDTO
            {
                EmployeeId = dto.EmployeeId,
                CompanyId = dto.CompanyId
            }
        );
        if (workHistory != null)
        {
            // 있으면 수정을 하고
            return await _workHistoryRepository.UpdateWorkHistory(dto);
        }
        // 없으면 추가를 한다.
        return await _workHistoryRepository.AddWorkHistory(dto);
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
            await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        }
        return await _workHistoryRepository.AddWorkHistory(dto);
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
            await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        }
        return await _workHistoryRepository.UpdateWorkHistory(dto);
    }

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveWorkHistory(int userId, int workHistoryId)
        => await _workHistoryRepository.RemoveWorkHistory(userId, workHistoryId);
    #endregion
    
}

