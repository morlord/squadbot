using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SuicideWebBot.Infrastructure;

namespace SuicideWebBot.Migrations
{
    [DbContext(typeof(SuicideSquadContext))]
    [Migration("20170216130851_BotManager")]
    partial class BotManager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("SuicideWebBot.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Atck");

                    b.Property<long>("ChatId");

                    b.Property<int>("Def");

                    b.Property<int>("Exp");

                    b.Property<int>("Level");

                    b.Property<int>("Money");

                    b.Property<string>("Name");

                    b.Property<int>("Stamina");

                    b.Property<long>("TgId");

                    b.Property<string>("TgName");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });
        }
    }
}
