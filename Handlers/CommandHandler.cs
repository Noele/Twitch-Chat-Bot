using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Twitch_Bot.Commands.impl;
using Twitch_Bot.Enums;
using Twitch_Bot.Events;
using Twitch_Bot.Handlers;

namespace Twitch_Bot.Commands
{
    public class CommandHandler
    {
        private List<Command> array = new List<Command>();
        public CommandHandler(OnMessageEvent onMessageEvent)
        {
            onMessageEvent.Register += onMessage;
        }

        private void onMessage(object sender, OnMessageEvent.OnMessageEventArgs args)
        {
            if (args.message.MessageType == MessageType.PRIVMSG && args.message.Content.Trim().StartsWith(Options.prefix))
            {
                foreach (var command in array)
                {
                    if (command.name == args.message.Content.Remove(0, 1).Trim())
                    {
                        command.Execute();
                    }
                }
            }
        }

        public void RegisterCommand(Command command)
        {
            array.Add(command);
        }
    }
}