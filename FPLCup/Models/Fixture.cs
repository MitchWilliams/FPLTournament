using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    enum Result { teamOneWin, teamTwoWin, draw};

    public class Fixture
    {

        public int fixtureId { get; set; }
        public string fixtureStage;
        public virtual ICollection<FixtureAssignment> fixtureAssignments { get; set; }
        public virtual Gameweek gameweek { get; set; }


    }
}