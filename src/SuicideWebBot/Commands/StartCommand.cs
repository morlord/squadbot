using System;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Microsoft.Extensions.DependencyInjection;

namespace SuicideWebBot.Commands
{
    public class StartCommand:ICommand
    {
        public async void Execute(Update update, object services)
        {
            await Bot.Api.SendTextMessageAsync(update.Message.Chat.Id, "Кто с мечом к нам придет, того проще застрелить!"); //И никакие мы не сектанты. Мы просто группа ошалелых вооруженных фанатиков!
        }

        public async void Execute(MessageEventArgs e)
        {
            await Bot.Api.SendTextMessageAsync(e.Message.Chat.Id, "Кто с мечом к нам придет, того проще застрелить!"); //И никакие мы не сектанты. Мы просто группа ошалелых вооруженных фанатиков!
        }
    }
}