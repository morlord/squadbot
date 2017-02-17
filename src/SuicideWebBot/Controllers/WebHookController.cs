using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using SuicideBotCore;
using SuicideWebBot.Infrastructure;
using SuicideWebBot.Entities;
using SuicideWebBot.Infrastructure.Repositories;
using SuicideWebBot.Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SuicideWebBot.Controllers
{
    [Route("api/[controller]")]
    public class WebHookController : Controller
    {
        IMembersRepository _members;
        IServiceCollection _app;
        
        public WebHookController(IMembersRepository members)
        {
            _members = members;
            //_app = app;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if(update == null)
                return Ok();
            var message = update?.Message;
            if(message==null)
                return Ok();
            if(string.IsNullOrWhiteSpace(message?.Text))
                return Ok();
            if(message.Text.StartsWith("/"))
            {
                if(BotManager.Commands.ContainsKey(message.Text))
                    BotManager.Commands[message.Text].Execute(update, _members);
                //await Bot.Api.SendTextMessageAsync(update.Message.Chat.Id, "Кто с мечом к нам придет, того проще застрелить!"); //И никакие мы не сектанты. Мы просто группа ошалелых вооруженных фанатиков!
            }
            else if(message.ForwardFrom.Username.Equals("ChatWarsBot") && message.Text.Contains("🇬🇵"))
            {
                var sq = Squader.ParseSquadder(update.Message);
                var member = _members.GetSingle(m => m.TgId == sq.TgId);
                if(member == null || member?.TgId==0)
                {
                    _members.Add(new Member()
                    {
                        TgId = sq.TgId,
                        Atck = sq.Atck,
                        ChatId = sq.ChatId,
                        Def = sq.Def,
                        Exp = sq.Exp,
                        Level = sq.Level,
                        Money = sq.Money,
                        Name = sq.Name,
                        Stamina = sq.Stamina,
                        TgName = sq.TgName
                    });
                }
                else
                {
                    member.Atck = sq.Atck;
                    member.Def = sq.Def;
                    member.Exp = sq.Exp;
                    member.Level = sq.Level;
                    member.Money = sq.Money;
                    member.Stamina = sq.Stamina;
                    member.Name = sq.Name;
                    _members.Edit(member);
                }
                _members.Commit();
                await Bot.Api.SendTextMessageAsync(update.Message.Chat.Id, sq.ToString());
            }

            return Ok();
        }
        
        [HttpGet]
        public async Task<string> Get()
        {
            var com = BotManager.Commands.ContainsKey("/");
            BotManager.Commands["/"].Execute(new Update(), new object());
            return com.ToString();
        }
    }
}