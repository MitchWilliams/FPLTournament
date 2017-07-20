﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPLTournament.Models
{
    public class GroupStage
    {
        [ForeignKey("Tournament")]
        public int groupStageId { get; set; }
        public virtual ICollection<Group> groups { get; set; }
        public virtual Tournament tournament { get; set; }

        /* public void drawGroups()
         {

         }

         public void generateFixtures()
         {

         }
         */
    }
}