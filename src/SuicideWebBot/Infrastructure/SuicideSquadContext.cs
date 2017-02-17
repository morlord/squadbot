using Microsoft.EntityFrameworkCore;
using SuicideWebBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuicideWebBot.Infrastructure
{
    public class SuicideSquadContext:DbContext
    {
        public SuicideSquadContext(DbContextOptions<SuicideSquadContext> options):base(options)
        { }

        public DbSet<Member> Members { get; set; }
    }
}
