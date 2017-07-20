using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class GroupAssignment
    {
        public int groupAssignmentId { get; set; }
        public int teamId { get; set; }
        public int groupId { get; set; }

        public virtual Group group { get; set; }
        public virtual Team team { get; set; }
    }
}