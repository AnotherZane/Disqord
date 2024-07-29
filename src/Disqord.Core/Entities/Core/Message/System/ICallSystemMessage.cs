namespace Disqord;

/// <summary>
///     Represents a system message sent by Discord for a call in a private channel.
/// </summary>
public interface ICallSystemMessage : ISystemMessage
{
    /// <summary>
    ///     Gets the call information for this message.
    /// </summary>
    IMessageCall Call { get; }
}
