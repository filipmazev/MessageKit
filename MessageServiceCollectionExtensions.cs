using Microsoft.Extensions.DependencyInjection;
using MessageKit.Configuration.Interfaces;
using MessageKit.Configuration;

namespace MessageKit;

/// <summary>
/// Extension methods for registering message services in the IServiceCollection.
/// </summary>
public static class MessageServiceCollectionExtensions
{
    /// <summary>
    /// Registers message services and configuration in the IServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddMessages(
        this IServiceCollection services,
        Action<MessageOptions> configure)
    {
        services.Configure(configure);

        services.AddSingleton<IMessageConfiguration, MessageConfiguration>();
        services.AddSingleton<IMessageFactory, MessageFactory>();

        return services;
    }
}