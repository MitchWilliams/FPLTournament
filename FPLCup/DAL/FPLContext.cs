using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FPLTournament.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FPLCup.DAL
{
    public class FPLContext : DbContext
    {

        public FPLContext() : base ("FPLContext")
        {

        }


        public DbSet<Fixture>Fixtures { get; set; }
        public DbSet<Gameweek> Gameweeks { get; set; }
        public DbSet<FixtureAssignment> FixtureAssignments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupAssignment> GroupAssignments { get; set; }
        public DbSet<GroupStage> GroupStages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentAssignment> TournamentAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}