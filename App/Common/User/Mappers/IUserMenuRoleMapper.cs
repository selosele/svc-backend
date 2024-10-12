using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 메뉴 권한 매퍼 인터페이스
/// </summary>
public interface IUserMenuRoleMapper
{
    #region Methods
    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    Task<int> AddUserMenuRole(List<AddUserMenuRoleRequestDTO> dtoList);

    /// <summary>
    /// 사용자 메뉴 권한을 삭제한다.
    /// </summary>
    Task<int> RemoveUserMenuRole(int? userId);
    #endregion

}
