using MessageKit.Utility.Builders;
using MessageKit.Data.Core;
using MessageKit.Enums;

namespace MessageKit;

/// <summary>
/// Factory interface for creating message instances.
/// </summary>
public interface IMessageFactory
{
    /// <summary>
    /// Creates a new Message instance using the provided parameters.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="sender"></param>
    /// <param name="level"></param>
    /// <param name="sentAt"></param>
    /// <param name="readAt"></param>
    /// <returns></returns>
    Message CreateMessage(
        MessageBuilder builder,
        string sender,
        MessageInformationTypeEnum level = MessageInformationTypeEnum.Info,
        DateTime sentAt = default,
        DateTime? readAt = null);
}