using System;
using System.Threading;
using System.Threading.Tasks;
using Twitch_Bot.Enums;
using Twitch_Bot.Structs;

namespace Twitch_Bot.Events
{
    public class OnMessageEvent
    {
        public event EventHandler<OnMessageEventArgs> Register;

        public OnMessageEvent()
        {
            var task = new Thread(Update);
            task.Start();
        }
        
        public class OnMessageEventArgs : EventArgs
        {
            public Message message;
        }

        public void Update()
        {
            while (true)
            {
                var message = TwitchClient.Irc.ReadMessage();
  
                Register?.Invoke(this, new OnMessageEventArgs{message = message});
            }
        }
    }
}