﻿using System.Threading.Tasks;
using Disqord.Gateway;
using Qmmands;
using Qommon;

namespace Disqord.Bot
{
    /// <summary>
    ///     Specifies that the module or command can only be executed by authors with the given channel permissions.
    /// </summary>
    public class RequireAuthorChannelPermissionsAttribute : DiscordGuildCheckAttribute
    {
        public ChannelPermissions Permissions { get; }

        public RequireAuthorChannelPermissionsAttribute(Permission permissions)
        {
            Permissions = ChannelPermissions.Mask(permissions, out var remainingPermissions);
            if (remainingPermissions != Permission.None)
                Throw.ArgumentOutOfRangeException(nameof(permissions), $"The permissions specified for {GetType()} contain non-channel permissions: {remainingPermissions}.");
        }

        public override ValueTask<CheckResult> CheckAsync(DiscordGuildCommandContext context)
        {
            var permissions = context.Author.GetPermissions(context.Channel);
            if (permissions.Has(Permissions))
                return Success();

            return Failure($"You lack the necessary channel permissions ({Permissions & ~permissions}) to execute this.");
        }
    }
}
