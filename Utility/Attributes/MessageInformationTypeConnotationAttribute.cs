namespace MessageKit.Utility.Attributes;

/// <summary>
/// Attribute to indicate the connotation of a message information type.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class MessageInformationTypeConnotationAttribute : Attribute
{
    /// <summary>
    /// Indicates whether the message type has a negative connotation.
    /// </summary>
    public bool IsNegative { get; set; } = true;
}