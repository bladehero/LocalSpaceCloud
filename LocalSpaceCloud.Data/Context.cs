using LocalSpaceCloud.Extensions;
using LocalSpaceCloud.Infrastructure.Data;
using LocalSpaceCloud.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LocalSpaceCloud.Data
{
    public class Context : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SystemEntityTypeValue> SystemEntityTypes { get; set; }
        public DbSet<BinEntity> BinEntities { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Enums
            #region SystemEntityType
            builder.Entity<BinEntity>()
                   .Property(e => e.SystemEntityType)
                   .HasConversion<int>();

            builder.Entity<SystemEntityTypeValue>()
                   .Property(e => e.ID)
                   .HasConversion<int>();

            builder.Entity<SystemEntityTypeValue>().HasData(
                    Enum.GetValues<SystemEntityType>().Select(e => new SystemEntityTypeValue()
                    {
                        ID = e,
                        Name = e.ToString(),
                        Description = e.GetDescription()
                    })
                );
            #endregion
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
