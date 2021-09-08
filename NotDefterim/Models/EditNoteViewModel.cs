using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotDefterim.Models
{
    public class EditNoteViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
