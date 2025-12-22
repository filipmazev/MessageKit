namespace MessageKit;

/// <summary>
/// Configuration options for message handling and translation.
/// </summary>
public sealed class MessageOptions
{
    /// <summary>
    /// Base translation key used when no explicit key is provided.
    /// Example: "messages.base"
    /// </summary>
    public string BaseTranslationKey { get; set; } = "messages.base";

    /// <summary>
    /// Optional prefix automatically applied to all message translation keys.
    /// Example: "app.notifications"
    /// </summary>
    public string? TranslationKeyPrefix { get; set; }
}