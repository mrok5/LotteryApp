using LotteryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Data
{
    public class LotteryDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public LotteryDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<DrawHistory> DrawHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:LotteryAppDbContext"]);
        }
    }
}
