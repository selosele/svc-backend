using AutoMapper;

namespace App.Shared.Profiles;

/// <summary>
/// 객체 매핑을 설정하는 클래스 (T: Target, D: Data)
/// </summary>
public class MyProfile<T, D> : Profile
{
    public MyProfile()
    {
        CreateMap(typeof(T), typeof(D));
    }
    
}
