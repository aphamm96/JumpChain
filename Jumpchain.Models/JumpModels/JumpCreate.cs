using JumpChain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpchain.Models.JumpModels
{
    public class JumpCreate
    {
        [Required]
        [Display(Name = "Jump Number")]
        public int JumpNumber { get; set; }
        [Required]
        [Display(Name = "Setting")]
        public string JumpLocation { get; set; }
        [Display(Name = "Companions Taken")]
        public string Companions { get; set; } //Can these be set to Lists? Will have to research. String will work for now
        [Display(Name = "Perks Taken")]
        public string JumpPerks { get; set; }
        [Display(Name = "Items Taken")]
        public string JumpItems { get; set; }
        [Display(Name = "Drawbacks Taken")]
        public string Drawbacks { get; set; }
        [ForeignKey("Jumper")]
        public int JumperID { get; set; }
        public virtual Jumper Jumper { get; set; }
    }
}
