using SmartSql;
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
    public Task<IList<MenuBookmarkResponseDTO>> ListMenuBookmark(int? userId)
    {
        return SqlMapper.QueryAsync<MenuBookmarkResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuBookmarkMapper),
            SqlId = "ListMenuBookmark",
            Request = new { userId }
        });
    }

    /// <summary>
    /// 메뉴 즐겨찾기를 조회한다.
    /// </summary>
    public Task<MenuBookmarkResponseDTO> GetMenuBookmark(int MenuBookmarkId)
    {
        return SqlMapper.QuerySingleAsync<MenuBookmarkResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuBookmarkMapper),
            SqlId = "GetMenuBookmark",
            Request = new { MenuBookmarkId }
        });
    }

    /// <summary>
    /// 메뉴 즐겨찾기를 추가한다.
    /// </summary>
    public Task<int> AddMenuBookmark(SaveMenuBookmarkRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(MenuBookmarkMapper),
            SqlId = "AddMenuBookmark",
            Request = dto
        });
    }

    /// <summary>
    /// 모든 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuBookmarkAll(int? userId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(MenuBookmarkMapper),
            SqlId = "RemoveMenuBookmarkAll",
            Request = new { userId }
        });
    }

    /// <summary>
    /// 메뉴 즐겨찾기를 삭제한다.
    /// </summary>
    public Task<int> RemoveMenuBookmark(int menuBookmarkId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(MenuBookmarkMapper),
            SqlId = "RemoveMenuBookmark",
            Request = new { menuBookmarkId }
        });
    }
    #endregion

}
