using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 메뉴 권한 매퍼 클래스
/// </summary>
public class UserMenuRoleMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public UserMenuRoleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserMenuRole(List<AddUserMenuRoleRequestDTO> dtoList)
        => SqlMapper.Execute($"{nameof(UserMenuRoleMapper)}.AddUserMenuRole", new { DTOList = dtoList });

    /// <summary>
    /// 사용자 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveUserMenuRole(RemoveUserMenuRoleRequestDTO dto)
        => SqlMapper.Execute($"{nameof(UserMenuRoleMapper)}.RemoveUserMenuRole", dto);
    #endregion

}
