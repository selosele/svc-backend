

using AutoMapper;
using svc.App.Code.Models.DTO;
using svc.App.Code.Models.Entities;

namespace svc.App.Code.Models.Profiles;

/// <summary>
/// 코드 객체 매핑을 설정하는 클래스
/// </summary>
public class CodeProfile : Profile
{
    public CodeProfile()
    {
        CreateMap<CodeEntity, CodeResponseDTO>();
    }
    
}
