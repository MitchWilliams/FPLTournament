using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class GroupAssignment
    {
        public int GroupAssignmentId { get; set; }
        public int TeamId { get; set; }
        public int GroupId { get; set; }

        public virtual Group group { get; set; }
        public virtual Team team { get; set; }
    }
}