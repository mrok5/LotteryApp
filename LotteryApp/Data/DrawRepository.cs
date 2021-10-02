using LotteryApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Data
{
    public class DrawRepository : IDrawRepository
    {
        private readonly LotteryDbContext _ctx;
        public DrawRepository(LotteryDbContext ctx)
        {
            _ctx = ctx;
        }

        public DrawHistory Get(int id)
        {
            return _ctx.DrawHistory.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<DrawHistory> GetDrawHistory()
        {
            return _ctx.DrawHistory.OrderBy(x => x.DrawDateTime).ToList();
        }
    }
}
