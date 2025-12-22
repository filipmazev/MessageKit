namespace MessageKit.Data.Core;

/// <summary>
/// Represents a message template with a translation key and required placeholders.
/// </summary>
/// <param name="translationKey"></param>
/// <param name="requiredPlaceholders"></param>
public class MessageTemplate(
    string translationKey,
    IEnumerable<string>? requiredPlaceholders = null)
{
    /// <summary>
    /// The translation key for the message template.
    /// </summary>
    public string TranslationKey { get; } = translationKey;
    
    /// <summary>
    /// List of placeholders that must be provided when using this template.
    /// </summary>
    public IReadOnlyList<string> RequiredPlaceholders { get; } = requiredPlaceholders?.ToList() ?? [];
}