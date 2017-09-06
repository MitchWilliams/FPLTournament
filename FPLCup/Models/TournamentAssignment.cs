using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class TournamentAssignment
    {
        public int TournamentAssignmentId { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }

        public virtual Team team { get; set; }
        public virtual Tournament tournament { get; set; }
    }
}