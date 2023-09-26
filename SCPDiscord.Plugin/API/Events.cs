using CommandSystem.Commands.RemoteAdmin.PermissionsManagement.Group;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SCPDiscord.Plugin.API
{
    /// <summary>
    /// Use only a single field of this class!
    /// </summary>
    public class ClientEvent {
        public CommandEvent? Command { get; private set; }
        public DropEvent? Drop { get; private set; }

        [JsonConstructor]
        public ClientEvent(DropEvent drop) {
            Drop = drop;
        }

        [JsonConstructor]
        public ClientEvent(CommandEvent command) {
            Command = command;
        }
    }

    public class CommandEvent {
        [JsonProperty("command_id")]
        public ulong CommandId { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }
    }

    public class DropEvent {
        [JsonProperty("reason")]
        public string? Reason { get; set; }
    }

    /// <summary>
    /// Use only a single field of this class!
    /// </summary>
    public class ServerEvent {
        public LogEvent? Log { get; private set; }
        public CommandReplyEvent? CommandReply { get; private set; }
        public StatusEvent? Status { get; private set; }

        [JsonConstructor]
        public ServerEvent(LogEvent log) {
            Log = log;
        }

        [JsonConstructor]
        public ServerEvent(CommandReplyEvent cmdReply) {
            CommandReply = cmdReply;
        }
        
        [JsonConstructor]
        public ServerEvent(StatusEvent status) {
            Status = status;
        }
    }

    public class CommandReplyEvent {
        [JsonProperty("command_id")]
        public ulong CommandId { get; set; }

        [JsonProperty("reply")]
        public Message Reply { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }
    }

    public class StatusEvent 
    {
        [JsonProperty("activity")]
        public string? Activity { get; set; }

        [JsonProperty("status")]
        public OnlineStatus Status { get; set; }
    }

    public class LogEvent
    {
        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("type")]
        public LogType Type { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogType
    {
        Command,
        GameEvent,
        GameEventSensitive,
        Ban,
        Report,
        Disconnect
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OnlineStatus {
        [EnumMember(Value = "dnd")]
        DoNotDisturb,
        [EnumMember(Value = "idle")]
        Idle,
        [EnumMember(Value = "invisible")]
        Invisible,
        [EnumMember(Value = "offline")]
        Offline,
        [EnumMember(Value = "online")]
        Online
    }


    /// <summary>
    /// Use only a single field of this class!
    /// </summary>
    public class Message {
        public string? Text { get; }
        public Embed? Embed { get; }

        [JsonConstructor]
        public Message(string text) 
        {
            Text = text;
        }

        [JsonConstructor]
        public Message(Embed embed) 
        {
            Embed = embed;
        }
    }

    public class Embed {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("colour")]
        public ulong? Colour { get; set; }

        [JsonProperty("fields")]
        public IList<EmbedField> Fields { get; set; }
    }

    public class EmbedField {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("inline")]
        public bool Inline { get; set; }
    }
}