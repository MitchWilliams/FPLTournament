using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class FixtureAssignment
    {
        public int fixtureAssignmentId { get; set; }
        public int fixtureId { get; set; }
        public int teamId { get; set; }

        public virtual Team team { get; set; }
        public virtual Fixture fixture { get; set; }
    }
}