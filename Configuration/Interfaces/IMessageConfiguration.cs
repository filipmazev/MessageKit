namespace MessageKit.Configuration.Interfaces;

internal interface IMessageConfiguration
{
    string ResolveTranslationKey(string? messageKey);
}