using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Common.User.Models.DTO;

namespace Svc.App.Common.User.Mappers;

/// <summary>
/// 사용자 권한 매퍼 클래스
/// </summary>
public class UserRoleMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public UserRoleMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    public Task<IList<UserRoleResultDTO>> ListUserRole(GetUserRoleRequestDTO dto)
        => SqlMapper.QueryForList<UserRoleResultDTO>(nameof(UserRoleMapper), "ListUserRole", dto);

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    public Task<int> AddUserRole(List<AddUserRoleRequestDTO> dtoList)
        => SqlMapper.Execute(nameof(UserRoleMapper), "AddUserRole", new { DTOList = dtoList });

    /// <summary>
    /// 사용자 권한을 삭제한다.
    /// </summary>
    public Task<int> RemoveUserRole(int? userId)
        => SqlMapper.Execute(nameof(UserRoleMapper), "RemoveUserRole", new { userId });
    #endregion

}
