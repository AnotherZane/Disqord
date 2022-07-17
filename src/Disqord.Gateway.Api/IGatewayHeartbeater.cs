﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Disqord.Logging;
using Qommon.Binding;

namespace Disqord.Gateway.Api;

public interface IGatewayHeartbeater : IBindable<IGatewayApiClient>, ILogging
{
    IGatewayApiClient ApiClient { get; }

    TimeSpan Interval { get; }

    TimeSpan? Latency { get; }

    ValueTask StartAsync(TimeSpan interval);

    ValueTask StopAsync();

    Task HeartbeatAsync(CancellationToken cancellationToken = default);

    ValueTask AcknowledgeAsync();
}