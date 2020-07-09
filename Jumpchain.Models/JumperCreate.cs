using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpchain.Models
{
    public class JumperCreate
    {
        [Required]
        [Display(Name = "Jumper Name")]
        public string JumperName { get; set; }
        [Display(Name = "Notes about the jump (different rules, etc.)")]
        public string JumperNotes { get; set; }
    }
}
