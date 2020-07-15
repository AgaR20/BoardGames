using BoardGame.Features.Games.EditView;
using BoardGame.Model;
using Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest.Games
{
    public class EditViewQueryTests
    {
        [Fact]
        public async void ShouldReturnEditGameViewModel()
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
            var query = new EditGameViewQuery();
            query.Id = newGame.Entity.Id;
            var handler = new EditGameViewQuery.Handler(context);
            var result = await handler.Handle(query, default);

            //assert
            
            Assert.Equal(expectedAge, result.MinimalPlayersAge);
            Assert.Equal(expectedMaxAmount, result.MaximalPlayersAmount);
            Assert.Equal(expectedMinAmount, result.MinimalPlayersAmount);
            Assert.Equal(expectedName, result.Name);
        }
    }
}
