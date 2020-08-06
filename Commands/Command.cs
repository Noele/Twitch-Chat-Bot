namespace Twitch_Bot.Commands
{
    public abstract class Command
    {
        public string name;
        public string description;
        public abstract void Execute();
    }
}