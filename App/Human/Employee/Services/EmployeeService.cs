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
    private readonly IEmployeeCompanyRepository _employeeCompanyRepository;
    #endregion
    
    #region Constructor
    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IEmployeeCompanyRepository employeeCompanyRepository
    )
    {
        _employeeRepository = employeeRepository;
        _employeeCompanyRepository = employeeCompanyRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> GetEmployee(GetEmployeeRequestDTO getEmployeeRequestDTO)
    {
        var employee = await _employeeRepository.GetEmployee(getEmployeeRequestDTO);
        if (employee != null)
        {
            employee.EmployeeCompanies = await _employeeCompanyRepository.ListEmployeeCompany(employee.EmployeeId);
        }
        return employee;
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> UpdateEmployee(UpdateEmployeeRequestDTO updateEmployeeRequestDTO)
    {
        await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        return await GetEmployee(new GetEmployeeRequestDTO { EmployeeId = updateEmployeeRequestDTO.EmployeeId });
    }

    /// <summary>
    /// 직원 회사를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeCompanyResponseDTO> GetEmployeeCompany(GetEmployeeCompanyRequestDTO getEmployeeCompanyRequestDTO)
        => await _employeeCompanyRepository.GetEmployeeCompany(getEmployeeCompanyRequestDTO);

    /// <summary>
    /// 직원 회사를 추가/수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> SaveEmployeeCompany(SaveEmployeeCompanyRequestDTO saveEmployeeCompanyRequestDTO)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(saveEmployeeCompanyRequestDTO.QuitYmd))
        {
            var updateEmployeeRequestDTO = new UpdateEmployeeRequestDTO
            {
                EmployeeCompany = new SaveEmployeeCompanyRequestDTO
                {
                    CompanyId = saveEmployeeCompanyRequestDTO.CompanyId
                },
                EmployeeId = saveEmployeeCompanyRequestDTO.EmployeeId,
                UpdaterId = saveEmployeeCompanyRequestDTO.UpdaterId
            };
            await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        }

        // 직원 회사 정보를 조회해서
        var employeeCompany = await _employeeCompanyRepository.GetEmployeeCompany(new GetEmployeeCompanyRequestDTO
            {
                EmployeeId = saveEmployeeCompanyRequestDTO.EmployeeId,
                CompanyId = saveEmployeeCompanyRequestDTO.CompanyId
            }
        );
        if (employeeCompany != null) {
            // 있으면 수정을 하고
            return await _employeeCompanyRepository.UpdateEmployeeCompany(saveEmployeeCompanyRequestDTO);
        }
        // 없으면 추가를 한다.
        return await _employeeCompanyRepository.AddEmployeeCompany(saveEmployeeCompanyRequestDTO);
    }

    /// <summary>
    /// 직원 회사를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<int> AddEmployeeCompany(SaveEmployeeCompanyRequestDTO saveEmployeeCompanyRequestDTO)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(saveEmployeeCompanyRequestDTO.QuitYmd))
        {
            var updateEmployeeRequestDTO = new UpdateEmployeeRequestDTO
            {
                EmployeeCompany = new SaveEmployeeCompanyRequestDTO
                {
                    CompanyId = saveEmployeeCompanyRequestDTO.CompanyId
                },
                EmployeeId = saveEmployeeCompanyRequestDTO.EmployeeId,
                UpdaterId = saveEmployeeCompanyRequestDTO.UpdaterId
            };
            await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        }
        return await _employeeCompanyRepository.AddEmployeeCompany(saveEmployeeCompanyRequestDTO);
    }

    /// <summary>
    /// 직원 회사를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateEmployeeCompany(SaveEmployeeCompanyRequestDTO saveEmployeeCompanyRequestDTO)
    {
        // 퇴사일자 값이 없으면 재직 중인 회사이므로 직원 정보도 수정해준다.
        if (string.IsNullOrWhiteSpace(saveEmployeeCompanyRequestDTO.QuitYmd))
        {
            var updateEmployeeRequestDTO = new UpdateEmployeeRequestDTO
            {
                EmployeeCompany = new SaveEmployeeCompanyRequestDTO
                {
                    CompanyId = saveEmployeeCompanyRequestDTO.CompanyId
                },
                EmployeeId = saveEmployeeCompanyRequestDTO.EmployeeId,
                UpdaterId = saveEmployeeCompanyRequestDTO.UpdaterId
            };
            await _employeeRepository.UpdateEmployee(updateEmployeeRequestDTO);
        }
        return await _employeeCompanyRepository.UpdateEmployeeCompany(saveEmployeeCompanyRequestDTO);
    }

    /// <summary>
    /// 직원 회사를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveEmployeeCompany(int userId, int employeeCompanyId)
        => await _employeeCompanyRepository.RemoveEmployeeCompany(userId, employeeCompanyId);
    #endregion
    
}

