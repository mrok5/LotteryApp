using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Data
{
    public class DrawSeeder
    {
        private readonly LotteryDbContext _ctx;

        public DrawSeeder(LotteryDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.DrawHistory.Any())
            {

            }
        }
    }
}
