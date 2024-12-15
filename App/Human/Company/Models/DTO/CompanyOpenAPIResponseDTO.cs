using Newtonsoft.Json;

namespace Svc.App.Human.Company.Models.DTO;

/// <summary>
/// 금융위원회_기업기본정보 - 기업개요조회 API로 조회한 회사 응답 DTO
/// </summary>
public record CompanyOpenAPIResponseDTO
{
    #region [필드]
    /// <summary>
    /// 법인등록번호
    /// </summary>
    [JsonProperty("crno")]
    public string? Crno { get; set; }

    /// <summary>
    /// 법인의 명칭
    /// </summary>
    [JsonProperty("corpNm")]
    public string? CorpNm { get; set; }

    /// <summary>
    /// 법인의 영문 표기 명
    /// </summary>
    [JsonProperty("corpEnsnNm")]
    public string? CorpEnsnNm { get; set; }

    /// <summary>
    /// 기업 공시 회사의 이름
    /// </summary>
    [JsonProperty("enpPbanCmpyNm")]
    public string? EnpPbanCmpyNm { get; set; }

    /// <summary>
    /// 기업 대표자의 이름
    /// </summary>
    [JsonProperty("enpRprFnm")]
    public string? EnpRprFnm { get; set; }

    /// <summary>
    /// 법인이 어느 시장에 등록되었는지를 관리하는 코드
    /// </summary>
    [JsonProperty("corpRegMrktDcd")]
    public string? CorpRegMrktDcd { get; set; }

    /// <summary>
    /// 법인이 어느 시장에 등록되었는지를 관리하는 코드의 명칭
    /// </summary>
    [JsonProperty("corpRegMrktDcdNm")]
    public string? CorpRegMrktDcdNm { get; set; }

    /// <summary>
    /// 법인등록번호(5,6 자리)내 법인종류별분류번호(5,6 자리)
    /// </summary>
    [JsonProperty("corpDcd")]
    public string? CorpDcd { get; set; }

    /// <summary>
    /// 법인구분코드명
    /// </summary>
    [JsonProperty("corpDcdNm")]
    public string? CorpDcdNm { get; set; }

    /// <summary>
    /// 세무에서, 신규로 개업하는 사업자에게 부여하는 사업체의 고유번호
    /// </summary>
    [JsonProperty("bzno")]
    public string? Bzno { get; set; }

    /// <summary>
    /// 기업의 소재지 구우편번호 (6자리)
    /// </summary>
    [JsonProperty("enpOzpno")]
    public string? EnpOzpno { get; set; }

    /// <summary>
    /// 기업의 소재지로 우편번호에 대응되는 기본주소
    /// </summary>
    [JsonProperty("enpBsadr")]
    public string? EnpBsadr { get; set; }

    /// <summary>
    /// 기업의 소재지로 우편번호에 대응되는 기본주소외의 상세주소
    /// </summary>
    [JsonProperty("enpDtadr")]
    public string? EnpDtadr { get; set; }

    /// <summary>
    /// 기업의 홈페이지 주소
    /// </summary>
    [JsonProperty("enpHmpgUrl")]
    public string? EnpHmpgUrl { get; set; }

    /// <summary>
    /// 기업의 전화번호
    /// </summary>
    [JsonProperty("enpTlno")]
    public string? EnpTlno { get; set; }

    /// <summary>
    /// 기업의 팩스 번호
    /// </summary>
    [JsonProperty("enpFxno")]
    public string? EnpFxno { get; set; }

    /// <summary>
    /// 산업 주체들이 모든 산업활동을 그 성질에 따라 유형화한 분류 이름
    /// </summary>
    [JsonProperty("sicNm")]
    public string? SicNm { get; set; }

    /// <summary>
    /// 기업의 설립일자
    /// </summary>
    [JsonProperty("enpEstbDt")]
    public string? EnpEstbDt { get; set; }

    /// <summary>
    /// 기업의 결산 월
    /// </summary>
    [JsonProperty("enpStacMm")]
    public string? EnpStacMm { get; set; }

    /// <summary>
    /// 기업의 거래소 상장 일자
    /// </summary>
    [JsonProperty("enpXchgLstgDt")]
    public string? EnpXchgLstgDt { get; set; }

    /// <summary>
    /// 기업의 거래소 상장 폐지 일자
    /// </summary>
    [JsonProperty("enpXchgLstgAbolDt")]
    public string? EnpXchgLstgAbolDt { get; set; }

    /// <summary>
    /// 기업의 주식이 코스닥 시장에 상장 등록된 일자
    /// </summary>
    [JsonProperty("enpKosdaqLstgDt")]
    public string? EnpKosdaqLstgDt { get; set; }

    /// <summary>
    /// 기업의 주식이 코스닥 시장에 상장 페지된 일자
    /// </summary>
    [JsonProperty("enpKosdaqLstgAbolDt")]
    public string? EnpKosdaqLstgAbolDt { get; set; }

    /// <summary>
    /// 기업의 KONEX(자본시장을 통한 초기 중소기업 지원을 강화하여 창조경제 생태계 기반을 조성하기 위해 개설된 중소기업전용 주식시장) 상장 일자
    /// </summary>
    [JsonProperty("enpKrxLstgDt")]
    public string? EnpKrxLstgDt { get; set; }

    /// <summary>
    /// 기업의 KONEX(자본시장을 통한 초기 중소기업 지원을 강화하여 창조경제 생태계 기반을 조성하기 위해 개설된 중소기업전용 주식시장) 상장 폐지 일자
    /// </summary>
    [JsonProperty("enpKrxLstgAbolDt")]
    public string? EnpKrxLstgAbolDt { get; set; }

    /// <summary>
    /// 해당 기업이 중소기업인지를 관리하는 여부
    /// </summary>
    [JsonProperty("smenpYn")]
    public string? SmenpYn { get; set; }

    /// <summary>
    /// 기업의 주거래 은행 명칭
    /// </summary>
    [JsonProperty("enpMntrBnkNm")]
    public string? EnpMntrBnkNm { get; set; }

    /// <summary>
    /// 기업의 종업원 인원수
    /// </summary>
    [JsonProperty("enpEmpeCnt")]
    public string? EnpEmpeCnt { get; set; }

    /// <summary>
    /// 기업의 종업원의 평균 근속 년수
    /// </summary>
    [JsonProperty("empeAvgCnwkTermCtt")]
    public string? EmpeAvgCnwkTermCtt { get; set; }

    /// <summary>
    /// 기업의 1인 평균 급여 금액
    /// </summary>
    [JsonProperty("enpPn1AvgSlryAmt")]
    public string? EnpPn1AvgSlryAmt { get; set; }

    /// <summary>
    /// 회계 감사를 실시한 감사인의 명칭
    /// </summary>
    [JsonProperty("actnAudpnNm")]
    public string? ActnAudpnNm { get; set; }

    /// <summary>
    /// 회계감사에 대한 감사인의 의견
    /// </summary>
    [JsonProperty("audtRptOpnnCtt")]
    public string? AudtRptOpnnCtt { get; set; }

    /// <summary>
    /// 기업이 영위하고 있는 주요 사업의 명칭
    /// </summary>
    [JsonProperty("enpMainBizNm")]
    public string? EnpMainBizNm { get; set; }

    /// <summary>
    /// 금융감독원에서 관리하는 법인의 고유번호
    /// </summary>
    [JsonProperty("fssCorpUnqNo")]
    public string? FssCorpUnqNo { get; set; }

    /// <summary>
    /// 금융감독원에서 관리하는 법인 정보의 변경일시
    /// </summary>
    [JsonProperty("fssCorpChgDtm")]
    public string? FssCorpChgDtm { get; set; }

    /// <summary>
    /// 최초개방일자
    /// </summary>
    [JsonProperty("fstOpegDt")]
    public string? FstOpegDt { get; set; }

    /// <summary>
    /// 최종개방일자
    /// </summary>
    [JsonProperty("lastOpegDt")]
    public string? LastOpegDt { get; set; }
    #endregion
    
}
