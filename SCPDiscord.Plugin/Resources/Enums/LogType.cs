using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPDiscord.Plugin.Resources.Enums
{
    /// <summary>
    /// Type of log to send to the bot.
    /// </summary>
    public enum LogType
    {
        Command,
        GameEvent,
        GameEventSensitive,
        Ban,
        Report,
        Disconnect
    }
}
