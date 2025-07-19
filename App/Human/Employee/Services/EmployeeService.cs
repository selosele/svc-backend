using SmartSql.AOP;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Mappers;
using Svc.App.Human.Company.Mappers;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Employee.Services;

/// <summary>
/// 직원 서비스
/// </summary>
public class EmployeeService(
    EmployeeMapper employeeMapper,
    CompanyMapper companyMapper,
    WorkHistoryMapper workHistoryMapper
    )
{
    #region [필드]
    private readonly EmployeeMapper _employeeMapper = employeeMapper;
    private readonly CompanyMapper _companyMapper = companyMapper;
    private readonly WorkHistoryMapper _workHistoryMapper = workHistoryMapper;
    #endregion

    #region [메서드]
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    public async Task<EmployeeResultDTO?> GetEmployee(GetEmployeeRequestDTO dto)
    {
        var employee = await _employeeMapper.GetEmployee(dto);
        if (employee != null)
        {
            employee.WorkHistoryList = await _workHistoryMapper.ListWorkHistory(new GetWorkHistoryRequestDTO
            {
                UserId = employee.UserId,
                EmployeeId = employee.EmployeeId
            });
        }
        return employee;
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResultDTO?> UpdateEmployee(UpdateEmployeeRequestDTO dto)
    {
        await _employeeMapper.UpdateEmployee(dto);
        return await GetEmployee(new GetEmployeeRequestDTO { EmployeeId = dto.EmployeeId });
    }

    /// <summary>
    /// 근무이력 목록을 조회한다.
    /// </summary>
    public async Task<IList<WorkHistoryResultDTO>> ListWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryMapper.ListWorkHistory(dto);

    /// <summary>
    /// 근무이력을 조회한다.
    /// </summary>
    public async Task<WorkHistoryResultDTO> GetWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryMapper.GetWorkHistory(dto);

    /// <summary>
    /// 최신 근무이력을 조회한다.
    /// </summary>
    public async Task<WorkHistoryResultDTO> GetCurrentWorkHistory(GetWorkHistoryRequestDTO dto)
        => await _workHistoryMapper.GetCurrentWorkHistory(dto);

    /// <summary>
    /// 근무이력을 추가/수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> SaveWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(dto.QuitYmd))
        {
            await _employeeMapper.UpdateEmployee(new UpdateEmployeeRequestDTO
            {
                WorkHistory = new SaveWorkHistoryRequestDTO { CompanyId = dto.CompanyId },
                EmployeeId = dto.EmployeeId,
                UpdaterId = dto.UpdaterId
            });
        }

        // 근무이력 정보를 조회해서
        var workHistory = await _workHistoryMapper.GetWorkHistory(new GetWorkHistoryRequestDTO
        {
            EmployeeId = dto.EmployeeId,
            CompanyId = dto.CompanyId
        });
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
    public async Task<WorkHistoryResultDTO> AddWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        int? companyId = dto.CompanyId;

        // 회사 ID가 없으면(Open API로 회사 정보를 조회해서 선택한경우) 회사 정보가 존재하는지 확인해서
        var companyCount = await _companyMapper.CountCompany(new GetCompanyRequestDTO
        {
            CompanyId = companyId,
            RegistrationNo = dto.RegistrationNo
        });

        // 없으면 회사 정보를 추가한다.
        if (companyCount == 0)
        {
            companyId = await _companyMapper.AddCompany(new SaveCompanyRequestDTO
            {
                RegistrationNo = dto.RegistrationNo,
                CorporateName = dto.CorporateName,
                CompanyName = dto.CompanyName,
                CompanyAddr = dto.CompanyAddr,
                CeoName = dto.CeoName,
                CreaterId = dto.EmployeeId,
            });
        }

        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(dto.QuitYmd))
        {
            await _employeeMapper.UpdateEmployee(new UpdateEmployeeRequestDTO
            {
                WorkHistory = new SaveWorkHistoryRequestDTO { CompanyId = companyId },
                EmployeeId = dto.EmployeeId,
                UpdaterId = dto.UpdaterId
            });
        }
        
        // 근무이력을 추가하고
        var workHistoryId = await _workHistoryMapper.AddWorkHistory(dto);

        // 추가한 근무이력을 조회해서 반환한다.
        return await _workHistoryMapper.GetWorkHistory(new GetWorkHistoryRequestDTO { WorkHistoryId = workHistoryId });
    }

    /// <summary>
    /// 근무이력을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateWorkHistory(SaveWorkHistoryRequestDTO dto)
    {
        int? companyId = dto.CompanyId;

        // 회사 ID가 없으면(Open API로 회사 정보를 조회해서 선택한경우) 회사 정보가 존재하는지 확인해서
        var companyCount = await _companyMapper.CountCompany(new GetCompanyRequestDTO
        {
            CompanyId = companyId,
            RegistrationNo = dto.RegistrationNo
        });

        // 없으면 회사 정보를 추가한다.
        if (companyCount == 0)
        {
            companyId = await _companyMapper.AddCompany(new SaveCompanyRequestDTO
            {
                RegistrationNo = dto.RegistrationNo,
                CorporateName = dto.CorporateName,
                CompanyName = dto.CompanyName,
                CompanyAddr = dto.CompanyAddr,
                CeoName = dto.CeoName,
                CreaterId = dto.EmployeeId,
            });
        }

        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(dto.QuitYmd))
        {
            await _employeeMapper.UpdateEmployee(new UpdateEmployeeRequestDTO
            {
                WorkHistory = new SaveWorkHistoryRequestDTO { CompanyId = companyId },
                EmployeeId = dto.EmployeeId,
                UpdaterId = dto.UpdaterId
            });
        }
        return await _workHistoryMapper.UpdateWorkHistory(dto);
    }

    /// <summary>
    /// 근무이력을 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveWorkHistory(GetWorkHistoryRequestDTO dto)
    {
        // 1. 근무이력을 삭제한다.
        var removed = await _workHistoryMapper.RemoveWorkHistory(dto.UserId, dto.WorkHistoryId);

        // 2. 최신 근무이력을 조회한다.
        var currentWorkHistory = await _workHistoryMapper.GetCurrentWorkHistory(dto);

        // 2. 직원 정보를 수정한다.
        await _employeeMapper.UpdateEmployee(new UpdateEmployeeRequestDTO
        {
            WorkHistory = new SaveWorkHistoryRequestDTO { CompanyId = currentWorkHistory.CompanyId },
            EmployeeId = dto.EmployeeId,
            UpdaterId = dto.UserId
        });

        return removed;
    }
    #endregion
    
}

