using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 즐겨찾기 매퍼 클래스
/// </summary>
public class MenuBookmarkMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public MenuBookmarkMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 즐겨찾기 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuBookmarkResultDTO>> ListMenuBookmark(int? userId)
        => SqlMapper.QueryForList<MenuBookmarkResultDTO>(nameof(MenuBookmarkMapper), "ListMenuBookmark", new { userId });

    /// <summary>
    /// 메뉴 즐겨찾기를 조회한다.
    /// </summary>
    public Task<MenuBookmarkResultDTO> GetMenuBookmark(int menuBookmarkId)
        => SqlMapper.QueryForObject<MenuBookmarkResultDTO>(nameof(MenuBookmarkMapper), "GetMenuBookmark", new { menuBookmarkId });

    /// <summary>
    /// 메뉴 즐겨찾기를 추가한다.
    /// </summary>
    public Task<int> AddMenuBookmark(SaveMenuBookmarkRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>(nameof(MenuBookmarkMapper), "AddMenuBookmark", dto);

    /// <summary>
    /// 모든 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuBookmarkAll(int? userId)
        => SqlMapper.Execute(nameof(MenuBookmarkMapper), "RemoveMenuBookmarkAll", new { userId });

    /// <summary>
    /// 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuBookmark(int menuBookmarkId)
        => SqlMapper.Execute(nameof(MenuBookmarkMapper), "RemoveMenuBookmark", new { menuBookmarkId });
    #endregion

}
