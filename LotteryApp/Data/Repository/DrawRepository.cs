using System;
using System.Collections.Generic;
using System.Linq;
using LotteryApp.Data.Entities;

namespace LotteryApp.Data.Repository
{
    public class DrawRepository : IDrawRepository
    {
        private readonly LotteryDbContext _ctx;
        private const int Min = 1;
        private const int Max = 50;
        private const int DrawNumber = 5;

        public DrawRepository(LotteryDbContext ctx)
        {
            _ctx = ctx;
        }

        public int[] DrawMethod()
        {
            var drawArray = new HashSet<int>();
            var random = new Random();

            while (drawArray.Count < DrawNumber)
            {
                var draw = random.Next(Min, Max);
                drawArray.Add(draw);
            }

            return drawArray.ToArray();
        }


        public DrawHistory Get(int id)
        {
            return _ctx.DrawHistory.FirstOrDefault(x => x.Id == id);
        }

        public IList<DrawHistory> GetDrawHistory()
        {
            return _ctx.DrawHistory.OrderBy(x => x.DrawDateTime).ToList();
        }

        public bool SaveDraw(DrawHistory draw)
        {
            try
            {
                _ctx.DrawHistory.Add(draw);
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
