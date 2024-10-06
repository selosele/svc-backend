using SmartSql;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Repositories;

/// <summary>
/// 사용자 권한 리포지토리 클래스
/// </summary>
public class UserRoleRepository : IUserRoleRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public UserRoleRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<UserRoleResponseDTO>> ListUserRole(GetUserRoleRequestDTO dto)
    {
        return SqlMapper.QueryAsync<UserRoleResponseDTO>(new RequestContext
        {
            Scope = nameof(UserRoleRepository),
            SqlId = "ListUserRole",
            Request = dto
        });
    }

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserRole(List<AddUserRoleRequestDTO> dtoList)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRoleRepository),
            SqlId = "AddUserRole",
            Request = new { DTOList = dtoList }
        });
    }

    /// <summary>
    /// 사용자 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveUserRole(int? userId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(UserRoleRepository),
            SqlId = "RemoveUserRole",
            Request = new { userId }
        });
    }
    #endregion

}
