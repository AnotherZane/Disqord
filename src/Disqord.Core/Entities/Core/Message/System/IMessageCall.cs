using System;
using System.Collections.Generic;

namespace Disqord;

/// <summary>
///     Represents call information embedded in a message.
/// </summary>
public interface IMessageCall : IEntity
{
    /// <summary>
    ///     Gets the participants of this call.
    /// </summary>
    IReadOnlyList<Snowflake> Participants { get; }

    /// <summary>
    ///     Gets the time when this call ended.
    /// </summary>
    /// <returns>
    ///     The time this call ended or <see langword="null"/> if the call is ongoing.
    /// </returns>
    DateTimeOffset? EndedAt { get; }
}
