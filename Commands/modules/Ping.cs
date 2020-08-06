namespace Twitch_Bot.Commands.impl
{
    public class Ping : Command
    {
        public Ping(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public override void Execute()
        {
            TwitchClient.Irc.SendChatMessage("Pong :D");
        }
    }
}