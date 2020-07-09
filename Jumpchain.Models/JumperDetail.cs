using JumpChain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpchain.Models
{
    public class JumperDetail
    {
        public int JumperID { get; set; }
        public string JumperName { get; set; }
        public string JumperNotes { get; set; }
        public virtual ICollection<Jump> Jumps { get; } = new List<Jump>();
    }
}
