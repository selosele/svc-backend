using System.Reflection;
using AutoMapper;

namespace svc.App.Shared.Utils;

/// <summary>
/// IServiceCollection의 확장 메서드를 제공하는 유틸 클래스
/// </summary>
public static class ServiceCollectionUtil
{
    /// <summary>
    /// 지정된 네임스페이스에 속한 모든 클래스를 서비스로 등록한다.
    /// </summary>
    public static void AddSingletonsFromNamespace(this IServiceCollection services, string prefixStart, string prefixEnd, ServiceLifetime lifetime = ServiceLifetime.Singleton)
    {
        var types = Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => t.IsClass && t.Namespace != null && t.Namespace.StartsWith(prefixStart) && t.Namespace.EndsWith(prefixEnd));

        foreach (var type in types)
        {
            services.Add(new ServiceDescriptor(type, type, lifetime));
        }
    }

    /// <summary>
    /// 지정된 네임스페이스에 속한 모든 AutoMapper 프로필을 추가한다.
    /// </summary>
    public static void AddAutoMapperProfilesFromNamespace(this IServiceCollection services, string prefixStart, string prefixEnd)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var profileTypes = assembly.GetTypes()
                                   .Where(t => t.IsClass && !t.IsAbstract && t.Namespace != null && t.Namespace.StartsWith(prefixStart) && t.Namespace.EndsWith(prefixEnd) && typeof(Profile).IsAssignableFrom(t))
                                   .ToList();

        services.AddAutoMapper(cfg =>
        {
            foreach (var profileType in profileTypes)
            {
                cfg.AddProfile(profileType);
            }
        }, assembly);
    }

}