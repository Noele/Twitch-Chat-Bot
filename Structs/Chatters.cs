using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Twitch_Bot.Structs
{
    public struct Chatters
    {
        private int count;

        public int Count => count;

        public string Broadcaster => broadcaster;

        public List<string> Vips => vips;

        public List<string> Moderators => moderators;

        public List<string> Staff => staff;

        public List<string> Admins => admins;

        public List<string> GlobalMods => global_mods;

        public List<string> Viewers => viewers;

        private string broadcaster;
        private List<string> vips;
        private List<string> moderators;
        private List<string> staff;
        private List<string> admins;
        private List<string> global_mods;
        private List<string> viewers;

        public Chatters(JObject response)
        {
            count = (int) response.SelectToken("chatter_count");
            var chatters = response["chatters"];
            try
            {
                broadcaster = (string) chatters.SelectToken("broadcaster")[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                broadcaster = null;
            }

            vips = chatters.SelectToken("vips").Values<string>().ToList();
            moderators = chatters.SelectToken("moderators").Values<string>().ToList();
            staff = chatters.SelectToken("staff").Values<string>().ToList();
            admins = chatters.SelectToken("admins").Values<string>().ToList();
            global_mods = chatters.SelectToken("global_mods").Values<string>().ToList();
            viewers = chatters.SelectToken("viewers").Values<string>().ToList();
        }
    }
}