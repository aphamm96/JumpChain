using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpchain.Models.JumpModels
{
     public class JumpEdit
    {
        public int JumpID { get; set; }
        [Display(Name = "Jump Number")]
        public int JumpNumber { get; set; }
        [Display(Name = "Setting")]
        public int JumpLocation { get; set; }
        [Display(Name = "Companions Taken")]
        public string Companions { get; set; } //Can these be set to Lists? Will have to research. String will work for now
        [Display(Name = "Perks Taken")]
        public string JumpPerks { get; set; }
        [Display(Name = "Items Taken")]
        public string JumpItems { get; set; }
        [Display(Name = "Drawbacks Taken")]
        public string Drawbacks { get; set; }
    }
}
