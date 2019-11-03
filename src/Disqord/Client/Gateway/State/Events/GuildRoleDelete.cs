﻿using System.Threading.Tasks;
using Disqord.Events;
using Disqord.Models;
using Disqord.Models.Dispatches;

namespace Disqord
{
    internal sealed partial class DiscordClientState
    {
        public Task HandleGuildRoleDeleteAsync(PayloadModel payload)
        {
            var model = Serializer.ToObject<GuildRoleCreateModel>(payload.D);
            var guild = GetGuild(model.GuildId);
            guild._roles.TryRemove(model.Role.Id, out var role);

            return _client._roleDeleted.InvokeAsync(new RoleDeletedEventArgs(role));
        }
    }
}