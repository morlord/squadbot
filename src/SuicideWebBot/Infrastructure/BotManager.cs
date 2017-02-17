using System.Collections.Generic;
using SuicideWebBot.Commands;
using Telegram.Bot;

namespace SuicideWebBot
{    
    public static class Bot
    {
        public static readonly TelegramBotClient Api = new TelegramBotClient(ID);
    }
    public static class BotManager
    {
        public static Dictionary<string,ICommand> Commands{get;set;}

        public static void Init(){
            Commands = new Dictionary<string,ICommand>();
            Commands.Add("/start",new StartCommand());
            Commands.Add("/top",new TopCommand());
        }
    }
}