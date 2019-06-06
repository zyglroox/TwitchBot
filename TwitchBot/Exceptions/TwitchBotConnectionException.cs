using System;
using System.Runtime.Serialization;

namespace TwitchBot.Exceptions
{
    [Serializable]
    internal class TwitchBotConnectionException : Exception
    {
        public TwitchBotConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}