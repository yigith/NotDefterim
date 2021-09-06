using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotDefterim.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegisterationTime { get; set; } = DateTime.Now;


        public List<Note> Notes { get; set; }
    }
}
