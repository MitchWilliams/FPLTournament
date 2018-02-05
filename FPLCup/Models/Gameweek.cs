using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Gameweek
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int GameweekId { get; set; }
        public virtual ICollection<Fixture> fixtures { get; set; }

    }
}