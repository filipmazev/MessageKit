using MessageKit.Configuration.Interfaces;
using Microsoft.Extensions.Options;

namespace MessageKit.Configuration;

internal sealed class MessageConfiguration(IOptions<MessageOptions> options) : IMessageConfiguration
{
    private readonly MessageOptions _options = options.Value;

    public string ResolveTranslationKey(string? messageKey)
    {
        if (string.IsNullOrWhiteSpace(messageKey))
            messageKey = _options.BaseTranslationKey;

        return string.IsNullOrWhiteSpace(_options.TranslationKeyPrefix)
            ? messageKey
            : $"{_options.TranslationKeyPrefix}.{messageKey}";
    }
}