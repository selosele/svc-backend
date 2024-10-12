using SmartSql;
using Svc.App.Common.Menu.Models.DTO;

namespace Svc.App.Common.Menu.Mappers;

/// <summary>
/// 메뉴 매퍼 클래스
/// </summary>
public class MenuMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public MenuMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
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
    #endregion

}
