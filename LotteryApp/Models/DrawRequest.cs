using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Models
{
    public class DrawRequest
    {
        public DateTime DrawDateTime { get; set; }
        public string Draw { get; set; }
    }
}
