using System;
using Twitch_Bot.Enums;

namespace Twitch_Bot.Structs
{
    public struct Message
    {
        private string _raw;
        private string _content;
        private string _channel;
        private string _author;

        public string Author
        {
            get => _author;
        }

        private MessageType _messageType;

        public MessageType MessageType
        {
            get => _messageType;
        }

        public string Raw
        {
            get => _raw;
        }

        public string Content
        {
            get => _content;
        }

        public string Channel
        {
            get => _channel;
        }

        public Message(string rawMessage)
        {
            _raw = rawMessage;
            if (rawMessage.Contains("PRIVMSG"))
            {

                var output = rawMessage.Substring(rawMessage.IndexOf("PRIVMSG") + 7);
                output = output.Trim();
                var messageData = output.Split(null);

                _content = "";
                for (var i = 1; i < messageData.Length; i++)
                {
                    _content += $"{messageData[i]} ";
                }

                _content = _content.Remove(0, 1);
                _channel = messageData[0].Remove(0, 1);
                _messageType = MessageType.PRIVMSG;
                _author = rawMessage.Substring(1, rawMessage.IndexOf("!") - 1);
            }
            else
            {
                _messageType = MessageType.LOG;
                _content = null;
                _channel = null;
                _author = null;
            }
        }
    }
}