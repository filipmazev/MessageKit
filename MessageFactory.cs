using MessageKit.Configuration.Interfaces;
using MessageKit.Utility.Builders;
using MessageKit.Data.Core;
using MessageKit.Enums;

namespace MessageKit;

/// <summary>
/// Factory class for creating Message instances.
/// </summary>
public class MessageFactory : IMessageFactory
{
    private readonly IMessageConfiguration _messageConfig;

    /// <summary>
    /// Constructs a new MessageFactory with the specified message configuration.
    /// </summary>
    /// <param name="messageConfig"></param>
    public MessageFactory(IMessageConfiguration messageConfig)
    {
        _messageConfig = messageConfig;
    }

    /// <summary>
    /// Creates a new Message instance using the provided parameters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="sender"></param>
    /// <param name="level"></param>
    /// <param name="sentAt"></param>
    /// <param name="readAt"></param>
    /// <returns></returns>
    public Message CreateMessage(
        MessageBuilder builder,
        string sender,         
        MessageInformationTypeEnum level = MessageInformationTypeEnum.Info,
        DateTime sentAt = default,
        DateTime? readAt = null)
    {
        return new Message(builder, _messageConfig, sender, level, sentAt, readAt);
    }
}