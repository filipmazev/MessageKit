using MessageKit.Utility.Attributes;

namespace MessageKit.Enums;

/// <summary>
/// Enum representing different types of message information.
/// </summary>
public enum MessageInformationTypeEnum
{
    /// <summary>
    /// Informational message type.
    /// </summary>
    [MessageInformationTypeConnotation(IsNegative = false)]
    Info = 0,
    
    /// <summary>
    /// Warning message type.
    /// </summary>
    [MessageInformationTypeConnotation(IsNegative = false)]
    Warning = 1,
    
    /// <summary>
    /// Error message type.
    /// </summary>
    [MessageInformationTypeConnotation(IsNegative = true)]
    Error = 2
}