using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    enum Result { teamOneWin, teamTwoWin, draw};

    public class Fixture
    {
        public int fixtureID;
        public Team teamOne;
        public Team teamTwo;
        public int gameweek;


    }
}