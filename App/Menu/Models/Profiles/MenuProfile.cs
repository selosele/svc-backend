

using AutoMapper;
using svc.App.Menu.Models.DTO;
using svc.App.Menu.Models.Entities;

namespace svc.App.Menu.Models.Profiles;

/// <summary>
/// 메뉴 객체 매핑을 설정하는 클래스
/// </summary>
public class MenuProfile : Profile
{
    public MenuProfile()
    {
        CreateMap<MenuEntity, MenuResponseDTO>();
        CreateMap<MenuRoleEntity, MenuRoleResponseDTO>();
    }
    
}
