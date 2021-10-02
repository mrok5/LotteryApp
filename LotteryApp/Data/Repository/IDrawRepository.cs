using LotteryApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Data
{
    public interface IDrawRepository
    {
        DrawHistory Get(int id);
        IEnumerable<DrawHistory> GetDrawHistory();
        bool SaveDraw(DrawHistory draw);
        int[] DrawMethod();
    }
}
