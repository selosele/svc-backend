using SmartSql.AOP;
using Newtonsoft.Json;
using Svc.App.Human.Company.Mappers;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Shared.Exceptions;

namespace Svc.App.Human.Company.Services;

/// <summary>
/// 회사 서비스 클래스
/// </summary>
public class CompanyService
{
    #region Fields
    private readonly ILogger _logger;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly CompanyMapper _companyMapper;
    private readonly CompanyApplyMapper _companyApplyMapper;
    #endregion
    
    #region Constructor
    public CompanyService(
        ILogger<CompanyService> logger,
        IConfiguration configuration,
        HttpClient httpClient,
        CompanyMapper companyMapper,
        CompanyApplyMapper companyApplyMapper
    )
    {
        _logger = logger;
        _configuration = configuration;
        _httpClient = httpClient;
        _companyMapper = companyMapper;
        _companyApplyMapper = companyApplyMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? dto)
        => await _companyMapper.ListCompany(dto);

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
    public async Task<int> AddCompany(AddCompanyRequestDTO dto)
        => await _companyMapper.AddCompany(dto);

    /// <summary>
    /// 금융위원회_기업기본정보 - 기업개요조회 API로 회사 목록을 조회한다.
    /// </summary>
    public async Task<IList<CompanyOpenAPIResponseDTO>> ListCompanyOpenAPI(GetCompanyRequestDTO? dto)
    {
        var uri = "https://apis.data.go.kr/1160100/service/GetCorpBasicInfoService_V2/getCorpOutline_V2";
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
    public async Task<IList<CompanyApplyResponseDTO>> ListCompanyApply(GetCompanyApplyRequestDTO? dto)
        => await _companyApplyMapper.ListCompanyApply(dto);

    /// <summary>
    /// 회사등록신청을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<CompanyApplyResponseDTO> GetCompanyApply(int companyApplyId)
        => await _companyApplyMapper.GetCompanyApply(companyApplyId);

    /// <summary>
    /// 회사등록신청을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<int> AddCompanyApply(SaveCompanyApplyRequestDTO dto)
    {
        // 회사 정보가 존재하는지 확인해서
        var count = await _companyMapper.CountCompany(new GetCompanyRequestDTO { RegistrationNo = dto.RegistrationNo });
        if (count > 0) {
            throw new BizException("이미 존재하는 회사 정보에요. 사업자등록번호를 다시 확인해주세요.");
        }
        // 없으면 등록신청을 추가한다.
        return await _companyApplyMapper.AddCompanyApply(dto);
    }
    #endregion
    
}
