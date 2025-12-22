using MessageKit.Utility.Attributes;
using System.Reflection;
using MessageKit.Enums;

namespace MessageKit.Utility.Extensions;

/// <summary>
/// Extension methods for MessageInformationTypeEnum.
/// </summary>
public static class MessageInformationTypeExtensions
{
    /// <summary>
    /// Determines if the message information type has a negative connotation.
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public static bool IsNegative(this MessageInformationTypeEnum status)
    {
        MessageInformationTypeConnotationAttribute? attribute = status.GetAttribute<MessageInformationTypeConnotationAttribute>();
        return attribute?.IsNegative ?? true;
    }

    private static T? GetAttribute<T>(this Enum value) where T : Attribute
    {
        MemberInfo? member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
        return member?.GetCustomAttribute<T>();
    }
}