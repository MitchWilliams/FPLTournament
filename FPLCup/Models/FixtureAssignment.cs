using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class FixtureAssignment
    {
        public int FixtureAssignmentId { get; set; }
        public int FixtureId { get; set; }
        public int TeamId { get; set; }

        public virtual Team team { get; set; }
        public virtual Fixture fixture { get; set; }
    }
}