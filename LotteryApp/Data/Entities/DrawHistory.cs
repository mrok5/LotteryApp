using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Data.Entities
{
    public class DrawHistory
    {
        public int Id { get; set; }
        public DateTime DrawDateTime { get; set; }
        public string Draw{ get; set; }
    }
}
