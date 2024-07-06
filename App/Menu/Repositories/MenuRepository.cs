using SmartSql;
using svc.App.Menu.Models.DTO;

namespace svc.App.Menu.Repositories;

/// <summary>
/// 메뉴 리포지토리 클래스
/// </summary>
public class MenuRepository : IMenuRepository
{
    public ISqlMapper SqlMapper { get; }

    public MenuRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }

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

}
