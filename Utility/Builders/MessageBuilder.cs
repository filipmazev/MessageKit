using MessageKit.Data.Core;

namespace MessageKit.Utility.Builders;

/// <summary>
/// Builder class for constructing messages based on a message template.
/// </summary>
/// <param name="template"></param>
public class MessageBuilder(MessageTemplate template)
{
    /// <summary>
    /// The message template associated with this builder.
    /// </summary>
    public MessageTemplate Template { get; } = template;
    
    /// <summary>
    /// Dictionary of placeholders and their corresponding values for the message.
    /// </summary>
    public Dictionary<string, string> MessagePlaceholders { get; } = new();

    /// <summary>
    /// Adds a placeholder and its value to the message.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public MessageBuilder With(string key, string value)
    {
        if(!Template.RequiredPlaceholders.Contains(key))
            throw new ArgumentException($"Placeholder '{key}' is not defined in this message template.");

        MessagePlaceholders[key] = value;
        return this;
    }
    
    /// <summary>
    /// Adds multiple placeholders and their values to the message.
    /// </summary>
    /// <param name="placeholders"></param>
    /// <returns></returns>
    public MessageBuilder From(Dictionary<string, string> placeholders)
    {
        foreach((string key, string value) in placeholders)
            With(key, value);

        return this;
    }

    /// <summary>
    /// Validates that all required placeholders are present in the message.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void Validate()
    {
        foreach(string requiredKey in Template.RequiredPlaceholders)
        {
            if(!MessagePlaceholders.ContainsKey(requiredKey))
                throw new InvalidOperationException($"Missing required placeholder '{requiredKey}' for this message.");
        }
    }
}