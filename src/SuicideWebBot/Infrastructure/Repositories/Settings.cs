using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuicideWebBot.Entities;
using SuicideWebBot.Infrastructure.Repositories.Abstract;

namespace SuicideWebBot.Infrastructure.Repositories
{
    public class MembersRepository : EntityBaseRepository<Member>, IMembersRepository
    {
        public MembersRepository(SuicideSquadContext context)
            : base(context)
        { }
    }
}
