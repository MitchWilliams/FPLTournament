using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Gameweek
    {
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }

        private int gameweekId;
        public virtual ICollection<Fixture> fixtures { get; set; }

    }
}