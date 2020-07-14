using BoardGame.Features.Games.Index;
using BoardGame.Model;
using Model.Entities;
using System;
using System.Threading;
using Xunit;
using XUnitTest.Builders;

namespace XUnitTest
{
    public class GetAllGamesTests
    {
        [Fact]
        public async void ShouldGetGamesList()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();
            context.Add(new Game());
            context.Add(new Game());
            context.SaveChanges();

            //act
            var query = new GetAllGamesQuery();
            var handler = new GetAllGamesQuery.Handler(context);
            var result = await handler.Handle(query, default(CancellationToken));

            //assert
            int expectedAmount = 2;
            Assert.Equal(2, result.Count);
        }
    }
}
