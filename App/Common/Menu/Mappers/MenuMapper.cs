using SmartSql;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 매퍼 클래스
/// </summary>
public class MenuMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public MenuMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO dto)
    {
        return SqlMapper.QueryAsync<MenuResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuMapper),
            SqlId = "ListMenu",
            Request = dto
        });
    }

    /// <summary>
    /// 메뉴를 조회한다.
    /// </summary>
    public Task<MenuResponseDTO> GetMenu(int menuId)
    {
        return SqlMapper.QuerySingleAsync<MenuResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuMapper),
            SqlId = "GetMenu",
            Request = new { menuId }
        });
    }

    /// <summary>
    /// 메뉴를 삭제한다.
    /// </summary>
    public Task<int> RemoveMenu(int menuId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(MenuMapper),
            SqlId = "RemoveMenu",
            Request = new { menuId, updaterId }
        });
    }
    #endregion

}
