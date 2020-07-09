using JumpChain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpchain.Models
{
    public class JumperListItem
    {
        public int JumperID { get; set; }
        [Display(Name ="Jumper Name")]
        public string JumperName { get; set; }
        [Display(Name ="Notes about the jump (different rules, etc.")]
        public string JumperNotes { get; set; }
        public virtual ICollection<Jump> Jumps { get; } = new List<Jump>();
    }
}
