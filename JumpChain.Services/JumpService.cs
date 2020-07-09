using Jumpchain.Models.JumpModels;
using JumpChain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpChain.Services
{
    public class JumpService
    {
        private readonly int _jumperId;

        public JumpService(int jumperId)
        {
            _jumperId = jumperId;
        }
        public bool CreateJump(JumpCreate model)
        {
            var entity =
                new Jump()
                {
                    JumpNumber = model.JumpNumber,
                    JumpLocation = model.JumpLocation,
                    Companions = model.Companions,
                    JumpPerks = model.JumpPerks,
                    JumpItems = model.JumpItems,
                    Drawbacks = model.Drawbacks,
                    JumperID = model.JumperID,
                    Jumper = model.Jumper
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jumps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JumpListItem> GetJumps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Jumps
                    .Where(e => e.JumperID == _jumperId)
                    .Select(
                        e =>
                        new JumpListItem
                        {
                            JumpNumber = e.JumpNumber,
                            JumpLocation = e.JumpLocation,
                            Companions = e.Companions,
                            JumpPerks = e.JumpPerks,
                            JumpItems = e.JumpItems,
                            Drawbacks = e.Drawbacks
                        }
                        );
                return query.ToArray();
            }
        }
        public JumpDetail GetJumpById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jumps
                    .Single(e => e.JumpID == id && e.JumperID == _jumperId);
                return
                    new JumpDetail
                    {
                        //This is part of the stretch goal, but the process can be applied to the Jump Service
                    };
            }
        }
        public bool UpdateJump(JumpEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jumps
                    .Single(e => e.JumpID == model.JumpID && e.JumperID == _jumperId);

                entity.JumpNumber = model.JumpNumber;
                entity.JumpLocation = model.JumpLocation;
                entity.Companions = model.Companions;
                entity.JumpPerks = model.JumpPerks;
                entity.JumpItems = model.JumpItems;
                entity.Drawbacks = model.Drawbacks;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteJump(int jumpId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jumps
                    .Single(e => e.JumpID == jumpId && e.JumperID == _jumperId);

                ctx.Jumps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
