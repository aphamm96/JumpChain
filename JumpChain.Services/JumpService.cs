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
        public IEnumerable<JumpListItem> GetJumps(int JumpID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Jumps
                    .Select(
                        e =>
                        new JumpListItem
                        {
                            JumpNumber = e.JumpNumber,
                            JumpLocation = e.JumpLocation,
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
                    .Single(e => e.JumpID == id);
                return
                    new JumpDetail
                    {
                        JumpID = entity.JumpID,
                        JumpNumber = entity.JumpNumber,
                        JumpLocation = entity.JumpLocation,
                        Companions = entity.Companions,
                        JumpPerks = entity.JumpPerks,
                        JumpItems = entity.JumpItems,
                        Drawbacks = entity.Drawbacks,
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
                    .Single(e => e.JumpID == model.JumpID);

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
                    .Single(e => e.JumpID == jumpId);

                ctx.Jumps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
