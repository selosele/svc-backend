using SmartSql.AOP;
using Newtonsoft.Json;
using Svc.App.Human.Company.Mappers;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Services;

/// <summary>
/// 회사 서비스 클래스
/// </summary>
public class CompanyService
{
    #region Fields
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly CompanyMapper _companyMapper;
    #endregion
    
    #region Constructor
    public CompanyService(
        IConfiguration configuration,
        HttpClient httpClient,
        CompanyMapper companyMapper
    )
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _companyMapper = companyMapper;
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
            return [];
        }

        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var jsonDeserialized = JsonConvert.DeserializeObject<CompanyOpenAPIResultDTO>(json);

        return jsonDeserialized?.Response?.Body?.Items?.Item ?? [];
    }
    #endregion
    
}

