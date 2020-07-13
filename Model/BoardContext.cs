using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Model
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options)
        {
            if (!Database.IsInMemory())
            {
                this.Database.Migrate();
            }
        }
        public DbSet<Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BoardDb;Trusted_Connection=True;");
        }
    }
}
