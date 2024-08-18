using SmartSql;
using Svc.App.Common.Auth.Models.DTO;

namespace Svc.App.Common.Auth.Repositories;

/// <summary>
/// 사용자 메뉴 권한 리포지토리 클래스
/// </summary>
public class UserMenuRoleRepository : IUserMenuRoleRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public UserMenuRoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 메뉴 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserMenuRole(List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMenuRoleRepository),
            SqlId = "AddUserMenuRole",
            Request = new { DTOList = addUserMenuRoleRequestDTOList }
        });
    }

    /// <summary>
    /// 사용자 메뉴 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveUserMenuRole(int? userId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMenuRoleRepository),
            SqlId = "RemoveUserMenuRole",
            Request = new { userId }
        });
    }
    #endregion

}
