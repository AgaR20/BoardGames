using BoardGame.Features.Games.Index;
using BoardGame.Model;
using Builders;
using Model.Entities;
using System;
using System.Threading;
using Xunit;

namespace XUnitTest.Games
{
    public class GetAllGamesTests
    {
        [Fact]
        public async void ShouldGetGamesList()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();

            context.Add(new GameBuilder(context).Build());
            context.Add(new GameBuilder(context).Build());
            context.SaveChanges();

            //act
            var query = new GetAllGamesQuery();
            var handler = new GetAllGamesQuery.Handler(context);
            var result = await handler.Handle(query, default);

            //assert
            int expectedAmount = 2;
            Assert.Equal(2, result.Count);
        }

    }
}
