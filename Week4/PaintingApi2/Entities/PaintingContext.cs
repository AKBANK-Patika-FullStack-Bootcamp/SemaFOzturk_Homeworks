using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class PaintingContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public PaintingContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
            options.UseSqlServer("Data Source=DESKTOP-B5K4J84\\SEM;Initial Catalog=Paintings;Integrated Security=True", option => {
                option.EnableRetryOnFailure();
            });
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Painting>().ToTable("Painting");
            modelBuilder.Entity<Painter>().ToTable("Painter");
            modelBuilder.Entity<PaintingDetail>().ToTable("PaintingDetail");
        }

        public DbSet<Painting> Painting { get; set; }
        public DbSet<Painter> Painter { get; set; }
        public DbSet<PaintingDetail> PaintingDetail { get; set; }


    }
}
