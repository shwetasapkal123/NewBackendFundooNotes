﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository_Layer.Entity
{
    public class Collaborator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int collaboratorId { get; set; }
        public string CollabEmail { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Note")]
        public int? NoteId { get; set; }

        public virtual Note Note { get; set; }

        public object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
