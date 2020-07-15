using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpchain.Models.JumpModels
{
    public class JumpListItem
    {
        public int JumpID { get; set; }
        [Display(Name = "Jump Number")]
        public int JumpNumber { get; set; }
        [Display(Name = "Setting")]
        public int JumpLocation { get; set; }
    }
}
