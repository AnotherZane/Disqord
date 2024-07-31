using System;
using System.Collections.Generic;
using Disqord.Models;
using Qommon;

namespace Disqord;

public class TransientMessageCall : TransientEntity<MessageCallJsonModel>, IMessageCall
{
    /// <inheritdoc/>
    public IReadOnlyList<Snowflake> Participants => Model.Participants;

    /// <inheritdoc/>
    public DateTimeOffset? EndedAt => Model.EndedTimestamp.GetValueOrDefault();

    public TransientMessageCall(MessageCallJsonModel model)
        : base(model)
    { }
}
