using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Team
    {
        private int teamId;
        private int weeklyScore;
        private int totalScore;
        private int groupPoints;
        private int groupWins;
        private int groupLosses;
        private int groupDraws;
        private string manager;
        private string name;
        private string URL;
        
        public virtual ICollection<FixtureAssignment> fixtureAssignments { get; set; }
        public virtual ICollection<GroupAssignment> groupAssignments { get; set; }
        public virtual ICollection<TournamentAssignment> tournamentAssignments { get; set; }

    }
}