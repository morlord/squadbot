using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Telegram.Bot;

namespace SuicideWebBot
{
    // static class Bot
    // {
    //     public static readonly TelegramBotClient Api = new TelegramBotClient("275192330:AAFQOHu9W0Xd9d9Rwg2cHUK2E3sMywr9dqo");
    // }
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
