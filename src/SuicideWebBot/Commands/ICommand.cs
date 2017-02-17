using Telegram.Bot.Types;
using Telegram.Bot.Args;
using System;
using SuicideWebBot.Infrastructure.Repositories.Abstract;

namespace SuicideWebBot.Commands
{
    public interface ICommand
    {
        void Execute(Update update, object repository);
        void Execute(MessageEventArgs e);
    }
}