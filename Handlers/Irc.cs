using System.IO;
using System.Net.Sockets;
using Twitch_Bot.Structs;

namespace Twitch_Bot
{
    public class Irc
    {
        private string _userName;
        private string _channel;

        private TcpClient _tcpClient;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;

        public Irc(string ip, int port, string userName, string password, string channel)
        {
            _userName = userName;
            _channel = channel;
            
            _tcpClient = new TcpClient(ip, port);
            _streamReader = new StreamReader(_tcpClient.GetStream());
            _streamWriter = new StreamWriter(_tcpClient.GetStream());
            
            _streamWriter.WriteLine($"PASS {password}");
            _streamWriter.WriteLine($"NICK {userName}");
            _streamWriter.WriteLine($"USER {userName} 8 * :{userName}");
            _streamWriter.WriteLine($"JOIN #{channel}");
            _streamWriter.Flush();
        }

        public void SendIrcMessage(string msg)
        {
            _streamWriter.WriteLine(msg);
            _streamWriter.Flush();
        }

        public Message ReadMessage()
        {
            return new Message(_streamReader.ReadLine());
        }

        public void SendChatMessage(string msg)
        {
            SendIrcMessage($":{_userName}!{_userName}@{_userName}.tmi.twitch.tv PRIVMSG #{_channel} :{msg}");
        }
    }
}