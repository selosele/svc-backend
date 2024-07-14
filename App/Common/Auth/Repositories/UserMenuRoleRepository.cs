using SmartSql;
using svc.App.Common.Auth.Models.DTO;

namespace svc.App.Common.Auth.Repositories;

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
    public Task<int> AddUserMenuRole(AddUserMenuRoleRequestDTO addUserMenuRoleRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserMenuRoleRepository),
            SqlId = "AddUserMenuRole",
            Request = addUserMenuRoleRequestDTO
        });
    }
    #endregion

}
