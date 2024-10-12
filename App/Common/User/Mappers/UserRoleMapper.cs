using SmartSql;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 권한 매퍼 클래스
/// </summary>
public class UserRoleMapper : IUserRoleMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public UserRoleMapper(ISqlMapper sqlMapper)
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
            Scope = nameof(UserRoleMapper),
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
            Scope = nameof(UserRoleMapper),
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
            Scope = nameof(UserRoleMapper),
            SqlId = "RemoveUserRole",
            Request = new { userId }
        });
    }
    #endregion

}
