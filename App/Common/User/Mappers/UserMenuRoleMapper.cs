using SmartSql;
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
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMenuRoleMapper),
            SqlId = "AddUserMenuRole",
            Request = new { DTOList = dtoList }
        });
    }

    /// <summary>
    /// 사용자 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveUserMenuRole(RemoveUserMenuRoleRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMenuRoleMapper),
            SqlId = "RemoveUserMenuRole",
            Request = dto
        });
    }
    #endregion

}
