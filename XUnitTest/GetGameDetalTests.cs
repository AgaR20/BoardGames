using BoardGame.Features.Games.Details;
using BoardGame.Model;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;
using XUnitTest.Builders;

namespace XUnitTest
{
    public class GetGameDetalTests
    {
        [Fact]
        public async void ShouldCreateVisit()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();
            var newGame = context.Add(new Game());
            context.SaveChanges();

            //act
            var query = new GameDetailQuery();
            var handler = new GameDetailQuery.Handler(context);
            var result = await handler.Handle(query, default(CancellationToken));

            //assert
            var game = context.Games
                .Where(x => x.Id == newGame.Entity.Id)
                .Include(x=>x.Visits)
                .FirstOrDefault();
            int expectedAmount = 1;
            Assert.Equal(expectedAmount, game.Visits.Count);
        }
    }
}
