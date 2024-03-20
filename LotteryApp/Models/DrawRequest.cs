using System;

namespace LotteryApp.Models
{
    public class DrawRequest
    {
        public DateTime DrawDateTime { get; set; }
        public int[] Draw { get; set; }
    }
}
