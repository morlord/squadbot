using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuicideWebBot.Entities
{
    public class Member:IEntityBase
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

        public int Id
        {
            get;

            set;
        }
    }
}
