using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class Group
    {

        public int GroupId { get; set; }

        public virtual ICollection<GroupAssignment> groupAssignments { get; set; }
        public virtual GroupStage groupStage { get; set; }

    }
}