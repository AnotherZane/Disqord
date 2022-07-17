﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Qommon;

namespace Disqord.Rest.Api.Default;

/// <summary>
///     Represents the known response headers for REST requests
///     that are used throughout the default components.
/// </summary>
public readonly struct DefaultRestResponseHeaders
{
    /// <summary>
    ///     Gets whether the request hit the global rate-limit.<br/>
    ///     Header: <c>X-RateLimit-Global</c>.
    /// </summary>
    public Optional<bool> IsGlobal => GetHeader("X-RateLimit-Global", bool.Parse);

    /// <summary>
    ///     Gets the time after which it is safe to retry the request.<br/>
    ///     Header: <c>Retry-After</c>.
    /// </summary>
    public Optional<TimeSpan> RetryAfter => GetHeader("Retry-After", value => TimeSpan.FromSeconds(int.Parse(value)));

    /// <summary>
    ///     Gets the amount of requests allowed in the bucket.<br/>
    ///     Header: <c>X-RateLimit-Limit</c>.
    /// </summary>
    public Optional<int> Limit => GetHeader("X-RateLimit-Limit", int.Parse);

    /// <summary>
    ///     Gets the amount of requests remaining in the bucket.<br/>
    ///     Header: <c>X-RateLimit-Remaining</c>.
    /// </summary>
    public Optional<int> Remaining => GetHeader("X-RateLimit-Remaining", int.Parse);

    /// <summary>
    ///     Gets the date at which the bucket will reset at.<br/>
    ///     Header: <c>X-RateLimit-Reset</c>.
    /// </summary>
    public Optional<DateTimeOffset> ResetsAt => GetHeader("X-RateLimit-Reset", value => DateTimeOffset.UnixEpoch + TimeSpan.FromSeconds(ParseDouble(value)));

    /// <summary>
    ///     Gets the time after which the bucket resets.<br/>
    ///     Header: <c>X-RateLimit-Reset-After</c>.
    /// </summary>
    public Optional<TimeSpan> ResetsAfter => GetHeader("X-RateLimit-Reset-After", value => TimeSpan.FromSeconds(ParseDouble(value)));

    /// <summary>
    ///     Gets the hash of the bucket.<br/>
    ///     Header: <c>X-RateLimit-Bucket</c>.
    /// </summary>
    public Optional<string> Bucket => GetHeader("X-RateLimit-Bucket");

    /// <summary>
    ///     Gets the scope of the bucket.<br/>
    ///     Header: <c>X-RateLimit-Scope</c>.
    /// </summary>
    public Optional<string> Scope => GetHeader("X-RateLimit-Scope");

    /// <summary>
    ///     Gets the server date of the bucket.<br/>
    ///     Header: <c>Date</c>.
    /// </summary>
    public Optional<DateTimeOffset> Date => GetHeader("Date", DateTimeOffset.Parse);

    private readonly IDictionary<string, string> _headers;

    public DefaultRestResponseHeaders(IDictionary<string, string> headers)
    {
        Guard.IsNotNull(headers);

        _headers = headers;
    }

    /// <summary>
    ///     Gets a header with the specified name.
    ///     If the header is not present the returned optional will not have a value.
    /// </summary>
    /// <param name="name"> The name of the header. </param>
    /// <returns>
    ///     An optional representing the header's presence and value.
    /// </returns>
    public Optional<string> GetHeader(string name)
    {
        if (_headers.TryGetValue(name, out var value))
            return value;

        return default;
    }

    /// <summary>
    ///     Gets a header with the specified name and converts its value via the given converter.
    ///     If the header is not present the returned optional will not have a value.
    /// </summary>
    /// <param name="name"> The name of the header. </param>
    /// <param name="converter"> The converter for the header value. </param>
    /// <returns>
    ///     An optional representing the header's presence and converted value.
    /// </returns>
    public Optional<T> GetHeader<T>(string name, Converter<string, T> converter)
    {
        return Optional.Convert(GetHeader(name), converter);
    }

    private static double ParseDouble(string value)
    {
        return double.Parse(value, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
    }
}
