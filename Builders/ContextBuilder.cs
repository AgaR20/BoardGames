using BoardGame.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders
{
    public class ContextBuilder
    {
        public BoardContext BuildClean()
        {
            DbContextOptionsBuilder<BoardContext> dbContextOptionsBuilder =
                new DbContextOptionsBuilder<BoardContext>();

            dbContextOptionsBuilder
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var databaseContext =
                new BoardContext(dbContextOptionsBuilder.Options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}
