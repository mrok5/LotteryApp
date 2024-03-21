using System.Collections.Generic;
using LotteryApp.Data.Entities;

namespace LotteryApp.Data.Repository
{
    public interface IDrawRepository
    {
        DrawHistory Get(int id);
        IList<DrawHistory> GetDrawHistory();
        bool SaveDraw(DrawHistory draw);
        int[] DrawMethod();
    }
}
