using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Tournament
    {
        
     
        private int TournamentId;
        private string name;
        public virtual ICollection<TournamentAssignment> tournamentAssignments { get; set; }
        public virtual GroupStage groupStage { get; set; }
        private Boolean isGroupTournament;
        


    }
}