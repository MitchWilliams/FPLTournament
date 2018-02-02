using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Tournament
    {
        
     
        public int TournamentId { get; set; }
        public string name { get; set; }
        public virtual ICollection<TournamentAssignment> tournamentAssignments { get; set; }
        public virtual GroupStage groupStage { get; set; }
        public Boolean isGroupTournament { get; set; }




    }
}