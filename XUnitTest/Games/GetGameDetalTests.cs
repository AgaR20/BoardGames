using BoardGame.Features.Games.Details;
using BoardGame.Model;
using Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace XUnitTest.Games
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
            query.Id = newGame.Entity.Id;
            var handler = new GameDetailQuery.Handler(context);
            var result = await handler.Handle(query, default);

            //assert
            var game = context.Games
                .Where(x => x.Id == newGame.Entity.Id)
                .Include(x => x.Visits)
                .FirstOrDefault();
            int expectedAmount = 1;
            Assert.Equal(expectedAmount, game.Visits.Count);
        }

        [Fact]
        public async void ShouldReturnDetailViewModel()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();

            string expectedName = "Posiadlosc szalenstwa";
            int expectedAge = 5;
            int expectedMaxAmount = 6;
            int expectedMinAmount = 1;

            Game game = new GameBuilder(context)
                .WithName(expectedName)
                .WithMaxPlayersAmount(expectedMaxAmount)
                .WithMinPlayersAmount(expectedMinAmount)
                .WithMinPlayersAge(expectedAge)
                .Build();

            var newGame = context.Add(game);
            context.SaveChanges();

            //act
            var query = new GameDetailQuery();
            query.Id = newGame.Entity.Id;
            var handler = new GameDetailQuery.Handler(context);
            var result = await handler.Handle(query, default);

            //assert
            
            Assert.Equal(expectedAge, result.MinimalPlayersAge);
            Assert.Equal(expectedMaxAmount, result.MaximalPlayersAmount);
            Assert.Equal(expectedMinAmount, result.MinimalPlayersAmount);
            Assert.Equal(expectedName, result.Name);
        }
    }
}
