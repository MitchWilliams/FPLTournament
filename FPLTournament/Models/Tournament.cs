using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Tournament
    {
        private string name;
        private List<Team> teams = new List<Team>();
        private GroupStage groupStage;
        private KnockoutStage knockoutStage;
        private Boolean isGroupTournament;


    }
}