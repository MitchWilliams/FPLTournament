using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Team
    {
        public int TeamId {get; set; }
        public int weeklyScore{ get; set; }
        public int totalScore{ get; set; }
        public int groupPoints{ get; set; }
        public int groupWins{ get; set; }
        public int groupLosses{ get; set; }
        public int groupDraws{ get; set; }
        public string manager{ get; set; }
        public string name{ get; set; }
        public string URL{ get; set; }
        
        public virtual ICollection<FixtureAssignment> fixtureAssignments { get; set; }
        public virtual ICollection<GroupAssignment> groupAssignments { get; set; }
        public virtual ICollection<TournamentAssignment> tournamentAssignments { get; set; }

    }
}