using System;
using Disqord.Serialization.Json;
using Qommon;

namespace Disqord.Models;

public class MessageCallJsonModel : JsonModel
{
    [JsonProperty("participants")]
    public Snowflake[] Participants = null!;

    [JsonProperty("ended_timestamp")]
    public Optional<DateTimeOffset?> EndedTimestamp;
}
