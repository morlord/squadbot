using SuicideBotCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Newtonsoft.Json;

namespace SuicideBot
{
    public class Program
    {
        private static TelegramBotClient Bot = new TelegramBotClient(ID);
        public static void Main(string[] args)
        {
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.OnInlineQuery += BotOnInlineQueryReceived;
            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            Bot.OnReceiveError += BotOnReceiveError;

            var me = Bot.GetMeAsync().Result;

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = me.Username;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            Console.WriteLine(JsonConvert.SerializeObject(e));
            
            if(message.Text.StartsWith("/"))
            {
                Console.WriteLine("command");
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Кто с мечом к нам придет, того проще застрелить!"); //И никакие мы не сектанты. Мы просто группа ошалелых вооруженных фанатиков!
            }
            else if(message.ForwardFrom.Username.Equals("ChatWarsBot"))
            {
                Console.WriteLine("parse");
                var sq = Squader.ParseSquadder(e.Message);
                Bot.SendTextMessageAsync(e.Message.Chat.Id, sq.ToString());
            }
            Console.WriteLine("exit");
        }

        private static void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
