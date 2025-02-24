using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 매퍼 클래스
/// </summary>
public class MenuMapper : MyMapperBase
{
    #region [생성자]
    public MenuMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuResultDTO>> ListMenu(GetMenuRequestDTO dto)
        => QueryForList<MenuResultDTO>($"{nameof(MenuMapper)}.ListMenu", dto);

    /// <summary>
    /// 메뉴를 조회한다.
    /// </summary>
    public Task<MenuResultDTO> GetMenu(int? menuId)
        => QueryForObject<MenuResultDTO>($"{nameof(MenuMapper)}.GetMenu", new { menuId });

    /// <summary>
    /// 가장 최신의 메뉴 ID를 조회한다.
    /// </summary>
    public Task<int> GetMaxMenuId()
        => QueryForObject<int>($"{nameof(MenuMapper)}.GetMaxMenuId");

    /// <summary>
    /// 메뉴를 추가한다.
    /// </summary>
    public Task<int> AddMenu(SaveMenuRequestDTO dto)
        => Execute($"{nameof(MenuMapper)}.AddMenu", dto);

    /// <summary>
    /// 메뉴를 수정한다.
    /// </summary>
    public Task<int> UpdateMenu(SaveMenuRequestDTO dto)
        => Execute($"{nameof(MenuMapper)}.UpdateMenu", dto);

    /// <summary>
    /// 메뉴를 삭제한다.
    /// </summary>
    public Task<int> RemoveMenu(int menuId, int? updaterId)
        => Execute($"{nameof(MenuMapper)}.RemoveMenu", new { menuId, updaterId });
    #endregion

}
