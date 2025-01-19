namespace Svc.App.Common.Article.Models.DTO;

/// <summary>
/// 게시글 조회 결과 DTO
/// </summary>
public record ArticleResultDTO
{
    #region [필드]
    /// <summary>
    /// 게시글 ID
    /// </summary>
    public int? ArticleId { get; set; }

    /// <summary>
    /// 게시판 ID
    /// </summary>
    public int? BoardId { get; set; }
    
    /// <summary>
    /// 게시글 제목
    /// </summary>
    public string? ArticleTitle { get; set; }
    
    /// <summary>
    /// 게시글 내용
    /// </summary>
    public string? ArticleContent { get; set; }
    
    /// <summary>
    /// 게시글 작성자 ID
    /// </summary>
    public int? ArticleWriterId { get; set; }
    
    /// <summary>
    /// 게시글 작성자 닉네임
    /// </summary>
    public string? ArticleWriterNickname { get; set; }
    
    /// <summary>
    /// 게시글 작성자 직원명
    /// </summary>
    public string? EmployeeName { get; set; }
    
    /// <summary>
    /// 등록일시
    /// </summary>
    public string? CreateDt { get; set; }

    /// <summary>
    /// 게시글 작성자의 시스템관리자 권한 보유 여부
    /// </summary>
    public int? IsSystemAdmin { get; set; }
    
    /// <summary>
    /// 이전/다음글 flag
    /// </summary>
    public string? PrevNextFlag { get; set; }
    #endregion
    
}
