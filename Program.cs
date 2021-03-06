﻿using System;
using System.Threading.Tasks;
using Twitch_Bot.Commands;
using Twitch_Bot.Commands.impl;
using Twitch_Bot.Enums;
using Twitch_Bot.Events;
using Twitch_Bot.Handlers;

namespace Twitch_Bot
{
    internal class Program
    {
        public static void Main(string[] args) => new Program().Start().GetAwaiter().GetResult();

        private TwitchClient client;
        private async Task Start()
        {
            client = new TwitchClient("StylistGraphs", "!", @"oauth:wrkr336oq1airh47j9bpjaggyreuyk", "asmongold");

            var onMessageEvent = new OnMessageEvent();
            onMessageEvent.Register += onMessage;

            var commandHandler = new CommandHandler(onMessageEvent);
            
            commandHandler.RegisterCommand(new Ping("Ping", "Ping a user"));
            await Task.Delay(-1);
        }
        
        private void onMessage(object sender, OnMessageEvent.OnMessageEventArgs args)
        {
            switch (args.message.MessageType)
            {
                case MessageType.PRIVMSG:
                    Console.WriteLine($"[{args.message.Channel}] {args.message.Author}: {args.message.Content}");
                    break;
                    
                case MessageType.LOG:
                    //Console.WriteLine(args.message.Raw);
                    break;
            }
        }
    }
}