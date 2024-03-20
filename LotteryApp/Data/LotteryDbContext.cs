using LotteryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LotteryApp.Data
{
    public class LotteryDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public LotteryDbContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<DrawHistory> DrawHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:LotteryAppDbContext"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
