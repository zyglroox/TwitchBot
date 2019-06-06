using System;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;
using TwitchLib.Api.V5;
using TwitchLib.Client;
using TwitchBot.Config;
using TwitchBot.Exceptions;
using TwitchLib.Client.Interfaces;

namespace TwitchBot.Models
{
    public class TwitchBot : ITwitchBot
    {
        private ConnectionCredentials _credentials;
        private ITwitchClient _client;
        private string _channelName;

        public TwitchBot(string channelName = null)
        {
            _channelName = channelName ?? BotConfig.DefaultChannelName;
            _credentials = new ConnectionCredentials(BotConfig.BotUserName, BotConfig.BotAccessToken);
            _client = new TwitchClient();

        }

        public void Connect()
        {
            _client.Initialize(_credentials, _channelName);
            InitializeEvents();
            _client.Connect();
        }

        private void InitializeEvents()
        {
            _client.OnMessageReceived += Client_OnMessageReceived;
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.StartsWith("hi", StringComparison.InvariantCultureIgnoreCase))
            {
                _client.SendMessage(_channelName, $"Hello there, {e.ChatMessage.DisplayName}!");
            }
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }
    }
}
