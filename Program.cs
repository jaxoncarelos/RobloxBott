using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Discord;
using Discord.Webhook;

namespace RobloxBott
{
    internal class Program
    {
        static HttpClient client = new HttpClient();
        static string[] data = File.ReadAllLines("users.txt");
        static Discord.Webhook.DiscordWebhook hook = new Discord.Webhook.DiscordWebhook();
        static receivedData player2 = new receivedData();
        public static async Task Main(string[] args)
        {
            player2.LastOnline = "never";
            Console.WriteLine("Enter webhook url");
            var url = Console.ReadLine();
            hook.Url = url;

            receivedData[] data2 = new receivedData[data.Length];
            TimerCallback tm = isonline;
            Timer timer1 = new Timer(tm, "run", 0, 5000);
            
            Console.ReadKey();
        }
        

        private static async void isonline(Object state)
        {
            Console.WriteLine("1 second has passed");
            foreach (var user in data)
            {
                var content = await client.GetStringAsync("https://api.roblox.com/users/" + user + "/onlinestatus/");
                var player = JsonConvert.DeserializeObject<receivedData>(content);
                Console.WriteLine(player2.LastOnline);
                Console.WriteLine(player.LastOnline);
                if (player2 != null && player.LastOnline == player2.LastOnline) return;
                player2 = player;
                if (player.IsOnline == false) return;
                Console.WriteLine(player.PlaceId);            
                player2.lastSeenOnline = player.LastOnline;
                DiscordMessage message = new DiscordMessage();
                message.Content = $"{player.VisitorId} is {player.LastLocation}";
                message.TTS = false; //read message to everyone on the channel
                message.Username = "**" + player.VisitorId + "** is online!"; message.AvatarUrl = "https://imgr.search.brave.com/Uasayiql3MyC7vJ5NWOddYY4bzE9asE7ysfvcOJPvCU/fit/840/717/ce/1/aHR0cHM6Ly93ZWJz/dG9ja3Jldmlldy5u/ZXQvaW1hZ2VzL2No/ZWNrbWFyay1jbGlw/YXJ0LWJpZy03Lmpw/Zw";
                hook.Send(message);
                    
                
            }
        }
    }
}