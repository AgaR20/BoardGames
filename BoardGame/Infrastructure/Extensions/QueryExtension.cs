using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Infrastructure.Extensions
{
    public static class QueryExtension
    {
        public static async Task<Game> GetById(this DbSet<Game> games, int id, CancellationToken token)
        {
            return await games.Where(x => x.Id == id)
                  .FirstOrDefaultAsync(token);
        }

        public static async Task<Game> GetByIdWithVisits(this DbSet<Game> games, int id, CancellationToken token)
        {
            return await games.Where(x => x.Id == id)
                  .Include(x => x.Visits)
                  .FirstOrDefaultAsync(token);
        }
    }
}
