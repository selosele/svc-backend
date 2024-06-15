using AutoMapper;

namespace App.Shared.Profiles;

/// <summary>
/// 객체 매핑을 설정하는 클래스 (S: SourceType, D: DestinationType)
/// </summary>
public class MyProfile<S, D> : Profile
{
    public MyProfile()
    {
        CreateMap(typeof(S), typeof(D));
    }
    
}
