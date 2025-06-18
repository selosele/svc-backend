using SmartSql.AOP;
using Newtonsoft.Json;
using Svc.App.Human.Company.Mappers;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Shared.Exceptions;
using Svc.App.Common.Notification.Mappers;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Human.Company.Services;

/// <summary>
/// 회사 서비스 클래스
/// </summary>
public class CompanyService
{
    #region [필드]
    private readonly ILogger _logger;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly CompanyMapper _companyMapper;
    private readonly CompanyApplyMapper _companyApplyMapper;
    private readonly NotificationMapper _notificationMapper;
    #endregion
    
    #region [생성자]
    public CompanyService(
        ILogger<CompanyService> logger,
        IConfiguration configuration,
        HttpClient httpClient,
        CompanyMapper companyMapper,
        CompanyApplyMapper companyApplyMapper,
        NotificationMapper notificationMapper
    )
    {
        _logger = logger;
        _configuration = configuration;
        _httpClient = httpClient;
        _companyMapper = companyMapper;
        _companyApplyMapper = companyApplyMapper;
        _notificationMapper = notificationMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CompanyResultDTO>> ListCompany(GetCompanyRequestDTO? dto)
        => await _companyMapper.ListCompany(dto);

    /// <summary>
    /// 회사를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<CompanyResultDTO> GetCompany(int companyId)
        => await _companyMapper.GetCompany(companyId);

    /// <summary>
    /// 회사 정보가 존재하는지 확인한다.
    /// </summary>
    [Transaction]
    public async Task<int> CountCompany(GetCompanyRequestDTO dto)
        => await _companyMapper.CountCompany(dto);

    /// <summary>
    /// 회사를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<CompanyResultDTO> AddCompany(SaveCompanyRequestDTO dto)
    {
        var companyId = await _companyMapper.AddCompany(dto);
        return await _companyMapper.GetCompany(companyId);
    }

    /// <summary>
    /// 회사를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateCompany(SaveCompanyRequestDTO dto)
        => await _companyMapper.UpdateCompany(dto);

    /// <summary>
    /// 회사를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveCompany(int companyId, int? updaterId)
        => await _companyMapper.RemoveCompany(companyId, updaterId);

    /// <summary>
    /// 금융위원회_기업기본정보 - 기업개요조회 API로 회사 목록을 조회한다.
    /// </summary>
    public async Task<IList<CompanyOpenAPIResponseDTO>> ListCompanyOpenAPI(GetCompanyRequestDTO? dto)
    {
        var uri = "http://apis.data.go.kr/1160100/service/GetCorpBasicInfoService_V2/getCorpOutline_V2";
        uri += $"?serviceKey={_configuration["ApplicationSettings:CompanyOpenAPIKey"]}";
        uri += $"&pageNo={dto?.PageNo}";
        uri += $"&numOfRows={dto?.NumOfRows}";
        uri += $"&corpNm={dto?.CorporateName ?? dto?.CompanyName}";
        uri += $"&resultType=json";

        var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);
        
        // 오류가 발생했을 경우
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("{}", response.StatusCode);
            return [];
        }

        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var jsonDeserialized = JsonConvert.DeserializeObject<CompanyOpenAPIResultDTO>(json);

        return jsonDeserialized?.Response?.Body?.Items?.Item ?? [];
    }

    /// <summary>
    /// 회사등록신청 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CompanyApplyResultDTO>> ListCompanyApply(GetCompanyApplyRequestDTO? dto)
        => await _companyApplyMapper.ListCompanyApply(dto);

    /// <summary>
    /// 회사등록신청을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<CompanyApplyResultDTO> GetCompanyApply(int companyApplyId)
        => await _companyApplyMapper.GetCompanyApply(companyApplyId);

    /// <summary>
    /// 회사등록신청을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<CompanyApplyResultDTO> AddCompanyApply(SaveCompanyApplyRequestDTO dto)
    {
        // 회사 정보가 존재하는지 확인해서
        var count = await _companyMapper.CountCompany(new GetCompanyRequestDTO { RegistrationNo = dto.RegistrationNo });
        if (count > 0)
            throw new BizException("이미 존재하는 회사 정보에요. 사업자등록번호를 다시 확인해주세요.");
        
        // 없으면 등록신청을 추가하고
        var companyApplyId = await _companyApplyMapper.AddCompanyApply(dto);

        // 추가한 등록신청을 조회해서 반환한다.
        return await _companyApplyMapper.GetCompanyApply(companyApplyId);
    }

    /// <summary>
    /// 회사등록신청을 수정한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateCompanyApply(SaveCompanyApplyRequestDTO dto)
    {
        // [승인]
        if (dto.ApplyStateCode == "APPROVAL")
        {

            // 회사 정보가 존재하는지 확인해서
            var count = await _companyMapper.CountCompany(new GetCompanyRequestDTO { RegistrationNo = dto.RegistrationNo });
            if (count > 0)
                throw new BizException("이미 존재하는 회사 정보에요. 사업자등록번호를 다시 확인해주세요.");
            
            // 없으면 회사 정보를 추가한다.
            await _companyMapper.AddCompany(new SaveCompanyRequestDTO
            {
                RegistrationNo = dto.RegistrationNo,
                CorporateName = dto.CorporateName,
                CompanyName = dto.CompanyName,
            });
        }
        // [반려]
        else if (dto.ApplyStateCode == "REJECT")
        {

            // 신청자에게 반려 알림을 발송한다.
            await _notificationMapper.AddNotification(new AddNotificationRequestDTO
            {
                UserId = dto.ApplicantId,
                NotificationTitle = "신청하신 회사등록신청 건이 반려되었어요.",
                NotiticationContent = $@"
                    {dto.CompanyName}(사업자등록번호: {dto.RegistrationNo}) 회사에 대한 등록신청이 반려되었어요.
                ",
                NotificationTypeCode = "NORMAL",
                NotificationKindCode = "COMPANY_APPLY",
                CreaterId = dto.ApplicantId
            });
        }
        // 회사등록신청정보의 신청상태 값을 UPDATE 해준다.
        return await _companyApplyMapper.UpdateCompanyApply(dto);
    }
    #endregion
    
}
