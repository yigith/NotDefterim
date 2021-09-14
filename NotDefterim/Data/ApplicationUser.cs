using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotDefterim.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegisterationTime { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string Photo { get; set; }


        public List<Note> Notes { get; set; }
    }
}
