using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Twitch_Bot.Structs;

namespace Twitch_Bot.Handlers
{
    public static class ApiHandler
    {
        public static Chatters GetChattersInChannel(string channelName)
        {
            string output;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://tmi.twitch.tv/group/user/{channelName}/chatters");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using(Stream stream = response.GetResponseStream())
            using(StreamReader reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }
            
            return new Chatters(JObject.Parse(output));
        }
    }
}