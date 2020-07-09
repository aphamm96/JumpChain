using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpChain.Data
{
    public class Jumper
    {
        [Key]
        public int JumperID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        [Display(Name ="Jumper Name")]
        public string JumperName { get; set; }
        [Display(Name ="Notes about the jump (different rules, etc.)")]
        public string JumperNotes { get; set; }
        public virtual ICollection<Jump> Jumps { get; } = new List<Jump>();
    }
}
