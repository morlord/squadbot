using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SuicideBotCore
{
    public class Squader
    {
        public long TgId { get; set; }
        public string Name { get; set; }
        public string TgName { get; set; }
        public long ChatId { get; set; }
        public int Atck { get; set; }
        public int Def { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Money { get; set; }
        public int Stamina { get; set; }

        public override string ToString()
        {
            return $"👤{Name} (@{TgName})\n🇬🇵{Name}, Отряд Самоубийц\n⚔{Atck} | 🛡{Def} | 🏅{Level}\n🔥{Exp} | 💰{Money} | 🔋{Stamina}";
        }

        public static Squader ParseSquadder(Message message)
        {
            var strings = message.Text.Split('\n');
            var sq = new Squader();
            sq.TgId = message.From.Id;
            sq.TgName = message.From.Username;
            sq.ChatId = message.Chat.Id;
            foreach(var str in strings)
            {
                if(str.StartsWith("🇬🇵"))
                {
                    sq.Name = str.Substring(4, str.IndexOf(",") - 4);
                }
                else if(str.StartsWith("🏅"))
                {
                    sq.Level = int.Parse(str.Substring(str.IndexOf(":") + 1));
                }
                else if(str.StartsWith("⚔"))
                {
                    var stats = str.Split("🛡".ToCharArray()).ToList<string>();
                    var tats = stats.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray<string>();

                    var atcks = tats[0].Substring(tats[0].IndexOf(":") + 1).Split('+');
                    var defs = tats[1].Substring(tats[1].IndexOf(":") + 1).Split('+');
                    foreach(var atck in atcks)
                    {
                        sq.Atck += int.Parse(atck);
                    }
                    foreach(var def in defs)
                    {
                        sq.Def += int.Parse(def);
                    }
                }
                else if(str.StartsWith("🔥"))
                {
                    var exp = str.Split(':')[1].Split('и')[0];
                    sq.Exp = int.Parse(exp);
                }
                else if(str.StartsWith("💰"))
                {
                    sq.Money = int.Parse(str.Split(':')[1]);
                }
                else if(str.StartsWith("🔋"))
                {
                    sq.Stamina = int.Parse(str.Split(':')[1].Split('з')[1]);
                }
            }
            return sq;
        }

    }
}
