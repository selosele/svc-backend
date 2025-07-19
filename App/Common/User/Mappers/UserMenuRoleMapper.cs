using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 메뉴 권한 매퍼
/// </summary>
public class UserMenuRoleMapper(ISqlMapper sqlMapper) : MyMapperBase(sqlMapper)
{
    #region [메서드]
    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserMenuRole(List<AddUserMenuRoleRequestDTO> dtoList)
        => Execute($"{nameof(UserMenuRoleMapper)}.AddUserMenuRole", new { DTOList = dtoList });

    /// <summary>
    /// 사용자 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveUserMenuRole(RemoveUserMenuRoleRequestDTO dto)
        => Execute($"{nameof(UserMenuRoleMapper)}.RemoveUserMenuRole", dto);
    #endregion

}
