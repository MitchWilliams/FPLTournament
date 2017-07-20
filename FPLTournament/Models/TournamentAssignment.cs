using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class TournamentAssignment
    {
        public int tournamentAssignmentId { get; set; }
        public int tournamentId { get; set; }
        public int teamId { get; set; }

        public virtual Team team { get; set; }
        public virtual Tournament tournament { get; set; }
    }
}