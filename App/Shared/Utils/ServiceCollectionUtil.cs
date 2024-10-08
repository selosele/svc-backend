using System.Reflection;
using AutoMapper;

namespace Svc.App.Shared.Utils;

/// <summary>
/// IServiceCollection의 확장 메서드를 제공하는 유틸 클래스
/// </summary>
public static class ServiceCollectionUtil
{
    #region Methods
    /// <summary>
    /// 지정된 네임스페이스에 속한 모든 클래스를 서비스로 등록한다.
    /// </summary>
    public static void SingletonScan(this IServiceCollection services, string prefixStart, string prefixEnd, ServiceLifetime lifetime = ServiceLifetime.Singleton)
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
    /// 지정된 네임스페이스에 속한 모든 인터페이스와 클래스를 서비스로 등록한다.
    /// </summary>
    public static void InterfaceScan(this IServiceCollection services, string prefixStart, string prefixEnd)
    {
        var types = Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => t.IsClass || t.IsInterface)
                            .Where(t => t.Namespace != null && t.Namespace.StartsWith(prefixStart) && t.Namespace.EndsWith(prefixEnd));

        // 인터페이스와 해당 구현체 찾기 및 등록
        foreach (var type in types.Where(t => t.IsInterface))
        {
            var implementation = types.FirstOrDefault(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(type));
            if (implementation != null)
            {
                // 구현체가 인터페이스를 구현하는 경우 등록
                services.AddSingleton(type, implementation);
            }
        }
    }

    /// <summary>
    /// 지정된 네임스페이스에 속한 모든 AutoMapper 프로필을 추가한다.
    /// </summary>
    public static void AutoMapperProfileScan(this IServiceCollection services, string prefixStart, string prefixEnd)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var profileTypes = assembly.GetTypes()
                                   .Where(t => t.IsClass && !t.IsAbstract && t.Namespace != null && t.Namespace.StartsWith(prefixStart) && t.Namespace.EndsWith(prefixEnd) && typeof(Profile).IsAssignableFrom(t))
                                   .ToList();

        services.AddAutoMapper(x =>
        {
            foreach (var profileType in profileTypes)
            {
                x.AddProfile(profileType);
            }
        }, assembly);
    }
    #endregion

}