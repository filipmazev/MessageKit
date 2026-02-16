using MessageKit.Configuration.Interfaces;
using MessageKit.Utility.Builders;
using MessageKit.Enums;

namespace MessageKit.Data.Core;

/// <summary>
/// Represents a message with translation key, placeholders, sender, timestamps, and information type.
/// </summary>
public class Message
{
    /// <summary>
    /// The base translation key for the message.
    /// </summary>
    public string TranslationKey { get; private set; }
    
    /// <summary>
    /// The information type of the message (e.g., Info, Warning, Error).
    /// </summary>
    public MessageInformationTypeEnum InformationType { get; }

    /// <summary>
    /// Core placeholders that are always included in the message.
    /// </summary>
    protected readonly Dictionary<string, string> CorePlaceholders = new();
    /// <summary>
    /// Placeholders specific to this message instance.
    /// </summary>
    public Dictionary<string, string> MessagePlaceholders { get; }
    
    /// <summary>
    /// The translation key for this specific message instance.
    /// </summary>
    public string MessageTranslationKey { get; }
    
    /// <summary>
    /// The sender of the message.
    /// </summary>
    /// 
    public string Sender { get; }
    /// <summary>
    /// The timestamp when the message was sent.
    /// </summary>
    public DateTime SentAt { get; }
    
    /// <summary>
    /// The timestamp when the message was read, if applicable.
    /// </summary>
    public DateTime? ReadAt { get; }
    
    /// <summary>
    /// Constructs a new Message instance.
    /// </summary>
    /// <param name="messageBuilder"></param>
    /// <param name="messageConfig"></param>
    /// <param name="sender"></param>
    /// <param name="level"></param>
    /// <param name="sentAt"></param>
    /// <param name="readAt"></param>
    /// <param name="translationKey"></param>
    public Message(
        MessageBuilder messageBuilder,
        IMessageConfiguration messageConfig,
        string sender = "System",
        MessageInformationTypeEnum level = MessageInformationTypeEnum.Info,
        DateTime sentAt = default,
        DateTime? readAt = null,
        string? translationKey = null)
    {
        messageBuilder.Validate();
        
        TranslationKey = translationKey ?? messageConfig.ResolveTranslationKey(null);
        MessageTranslationKey = messageBuilder.Template.TranslationKey;
        MessagePlaceholders = messageBuilder.MessagePlaceholders;
        
        Sender = sender;
        InformationType = level;
        
        SentAt = sentAt == default ? DateTime.UtcNow : sentAt;
        ReadAt = readAt;
        
        PopulateCorePlaceholders();
    }
    
    private void PopulateCorePlaceholders()
    {
        CorePlaceholders[nameof(Sender)] = Sender;
        CorePlaceholders[nameof(SentAt)] = SentAt.ToString("o");
        CorePlaceholders[nameof(ReadAt)] = ReadAt?.ToString("o") ?? string.Empty;
    }
    
    /// <summary>
    /// Computes the hash code for the message instance.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(
            MessageTranslationKey,
            GetDictionaryHashCode(MessagePlaceholders),
            InformationType
        );
    }

    private static bool DictionariesEqual<TKey, TValue>(
        IDictionary<TKey, TValue> first,
        IDictionary<TKey, TValue> second)
        where TKey : notnull
    {
        if(ReferenceEquals(first, second))
            return true;

        if(first.Count != second.Count)
            return false;

        foreach((TKey key, TValue value) in first)
        {
            if(!second.TryGetValue(key, out TValue? otherValue))
                return false;

            if(!EqualityComparer<TValue>.Default.Equals(value, otherValue))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Computes a hash code for a dictionary by combining the hash codes of its key-value pairs.
    /// </summary>
    /// <param name="dict"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    protected static int GetDictionaryHashCode<TKey, TValue>(IDictionary<TKey, TValue> dict)
        where TKey : notnull
    {
        int hash = 17;
        foreach((TKey key, TValue value) in dict.OrderBy(kv => kv.Key)) 
            hash = HashCode.Combine(hash, key, value);
        return hash;
    }
}