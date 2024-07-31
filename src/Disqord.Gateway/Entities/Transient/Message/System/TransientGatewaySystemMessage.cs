using Disqord.Gateway;
using Disqord.Models;
using Qommon;

namespace Disqord;

public class TransientGatewaySystemMessage : TransientGatewayMessage, IGatewaySystemMessage
{
    /// <inheritdoc/>
    public SystemMessageType Type { get; }

    /// <inheritdoc/>
    public string RawContent => base.Content;

    /// <inheritdoc/>
    public IMessageCall? Call => Optional.ConvertOrDefault(Model.Call, model => new TransientMessageCall(model));

    /// <inheritdoc/>
    public override string Content => Discord.Internal.GetSystemMessageContent(this, null);

    public TransientGatewaySystemMessage(IClient client, MessageJsonModel model)
        : base(client, model)
    {
        Type = (SystemMessageType) (model.Type - 1);
    }
}
