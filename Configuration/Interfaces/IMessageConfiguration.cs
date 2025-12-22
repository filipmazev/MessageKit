namespace MessageKit.Configuration.Interfaces;

/// <summary>
/// Interface for message configuration settings.
/// </summary>
public interface IMessageConfiguration
{
    /// <summary>
    /// Resolves the full translation key based on the provided message key and configuration settings.
    /// </summary>
    /// <param name="messageKey"></param>
    /// <returns></returns>
    string ResolveTranslationKey(string? messageKey);
}