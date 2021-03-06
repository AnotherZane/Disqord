﻿namespace Disqord.Gateway.Api.Default
{
    public class DefaultGatewayConfiguration
    {
        /// <summary>
        ///     Gets or sets the Discord gateway API version the <see cref="DefaultGateway"/> will use.
        ///     Defaults to <c>8</c>.
        /// </summary>
        public virtual int Version { get; set; } = 8;

        /// <summary>
        ///     Gets or sets whether the Discord gateway should send ZLib compressed payloads.
        ///     Defaults to <see langword="true"/>.
        /// </summary>
        public virtual bool UsesZLib { get; set; } = true;

        /// <summary>
        ///     Gets or sets whether the <see cref="DefaultGateway"/> should log received and sent payloads.
        ///     Defaults to <see langword="false"/>.
        /// </summary>
        public virtual bool LogsPayloads { get; set; }
    }
}