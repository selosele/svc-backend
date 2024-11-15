using Newtonsoft.Json;

namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 금융위원회_기업기본정보 - 기업개요조회 API로 조회한 회사 조회 결과 DTO
/// </summary>
public class CompanyOpenAPIResultDTO
{
    #region Fields
    [JsonProperty("response")]
    public APIResponse? Response { get; set; }
    #endregion
}

public class APIResponse
{
    #region Fields
    [JsonProperty("body")]
    public ResponseBody? Body { get; set; }
    #endregion
}

public class ResponseBody
{
    #region Fields
    [JsonProperty("items")]
    public Items? Items { get; set; }

    [JsonProperty("numOfRows")]
    public int? NumOfRows { get; set; }

    [JsonProperty("pageNo")]
    public int? PageNo { get; set; }

    [JsonProperty("totalCount")]
    public int? TotalCount { get; set; }
    #endregion
}

public class Items
{
    #region Fields
    [JsonProperty("item")]
    public List<CompanyOpenAPIResponseDTO>? Item { get; set; }
    #endregion
}