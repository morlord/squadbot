using System;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Microsoft.Extensions.DependencyInjection;
using SuicideWebBot.Infrastructure.Repositories;
using System.Linq;
using System.Text;
using SuicideWebBot.Infrastructure.Repositories.Abstract;

namespace SuicideWebBot.Commands
{
    public class TopCommand:ICommand
    {
        public async void Execute(Update update, object repository)
        {
            var repo = repository as IMembersRepository;
            var members = repo.GetAll();
            var defMembers = members.OrderByDescending(m=>m.Def).Take(5);
            var atckMembers = members.OrderByDescending(m=>m.Atck).Take(5);
            var expMembers = members.OrderByDescending(m=>m.Exp).Take(5);
            
            var sb = new StringBuilder();
            sb.Append("Топ по дефу:\n");
            foreach(var dm in defMembers)
            {
                sb.Append(dm.Name).Append("\n");
            }
            
            sb.Append("\n").Append("Топ по атаке:\n");
            foreach(var am in atckMembers)
            {
                sb.Append(am.Name).Append("\n");
            }
            
            sb.Append("\n").Append("Топ по опыту:\n");
            foreach(var em in expMembers)
            {
                sb.Append(em.Name).Append("\n");
            }
            
            await Bot.Api.SendTextMessageAsync(update.Message.Chat.Id, sb.ToString());
        }

        public async void Execute(MessageEventArgs e)
        {
            new NotImplementedException();
        }
    }
}