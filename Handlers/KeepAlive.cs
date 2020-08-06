using System;
using System.Threading;

namespace Twitch_Bot
{
    public class KeepAlive
    {
        private Irc _client;
        private Thread _thread;
        
        public KeepAlive(Irc client)
        {
            _client = client;
            _thread = new Thread(Run);
        }

        public void Start()
        {
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void Run()
        {
            while (true)
            {
                Console.WriteLine("Sending KeepAlive ping");
                _client.SendIrcMessage("PING irc.twitch.tv");
                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
        }
    }
}