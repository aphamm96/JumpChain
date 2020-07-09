using Jumpchain.Models;
using JumpChain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpChain.Services
{
    public class JumperService
    {
        private readonly Guid _userId;

        public JumperService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateJumper(JumperCreate model)
        {
            var entity =
                new Jumper()
                {
                    UserID = _userId,
                    JumperName = model.JumperName,
                    JumperNotes = model.JumperNotes
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jumpers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public List<Jump> GetJumpsForJumper(int JumperID)
        {
            List<Jump> jumps = new List<Jump>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jumpers
                    .Single(e => e.JumperID == JumperID && e.UserID == _userId);
                foreach (var jumpItem in entity.Jumps)
                {
                    jumps.Add(jumpItem);
                }
                return jumps;
            }
        }
        public IEnumerable<JumperListItem> GetJumpers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Jumpers
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                        new JumperListItem
                        {
                            JumperID = e.JumperID,
                            JumperName = e.JumperName,
                            JumperNotes = e.JumperNotes
                        }
                        );
                return query.ToArray();
            }
        }
        public JumperDetail GetJumperById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jumpers
                    .Single(e => e.JumperID == id && e.UserID == _userId);
                return
                    new JumperDetail
                    {
                        JumperID = entity.JumperID,
                        JumperName = entity.JumperName,
                        JumperNotes = entity.JumperNotes
            };
        }
    }
    public bool UpdateJumper(JumperEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Jumpers
                .Single(e => e.JumperID == model.JumperID && e.UserID == _userId);

            entity.JumperName = model.JumperName;
            entity.JumperNotes = model.JumperNotes;

            return ctx.SaveChanges() == 1;
        }
    }
    public bool DeleteJumper(int jumperId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Jumpers
                .Single(e => e.JumperID == jumperId && e.UserID == _userId);

            ctx.Jumpers.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
}
