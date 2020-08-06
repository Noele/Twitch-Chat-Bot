using System.Threading;
using Twitch_Bot.Handlers;

namespace Twitch_Bot
{
    public class TwitchClient
    {
        public static Irc Irc;
    
        private KeepAlive _keepAlive;
        public TwitchClient(string userName, string prefix, string oAuth, string channel)
        {
            Irc = new Irc("irc.twitch.tv", 6667, userName, oAuth, channel);
            Options.prefix = prefix;
            _keepAlive = new KeepAlive(Irc);
            _keepAlive.Start();
        }
    }
}