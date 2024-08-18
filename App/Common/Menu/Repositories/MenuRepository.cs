using SmartSql;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Repositories;

/// <summary>
/// 메뉴 리포지토리 클래스
/// </summary>
public class MenuRepository : IMenuRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public MenuRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 메뉴 목록을 조회한다.
    /// </summary>
    public Task<IList<MenuResponseDTO>> ListMenu(GetMenuRequestDTO getMenuRequestDTO)
    {
        return SqlMapper.QueryAsync<MenuResponseDTO>(new RequestContext
        {
            Scope = nameof(MenuRepository),
            SqlId = "ListMenu",
            Request = getMenuRequestDTO
        });
    }
    #endregion

}
