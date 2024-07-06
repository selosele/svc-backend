using AutoMapper;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;

namespace svc.App.Auth.Models.Profiles;

/// <summary>
/// 인증·인가 객체 매핑을 설정하는 클래스
/// </summary>
public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<UserEntity, UserResponseDTO>();
    }
    
}
