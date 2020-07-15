using BoardGame.Features.Games.Edit;
using BoardGame.Model;
using Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest.Games
{
    public class EditGameTests
    {
        [Fact]
        public async void ShouldEditGame()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();

            string expectedName = "Teraformacja marsa";
            int expectedMaxAmount = 6;
            int expectedAge = 5;
            int expectedMinAmount = 1;

            string givenName = "Szybki Talizman";
            int givenMaxAmount = 3;
            int givenAge = 4;
            int givenMinAmount = 2;

            Game game = new GameBuilder(context)
                .WithName(givenName)
                .WithMaxPlayersAmount(givenMaxAmount)
                .Build();

            var newGame = context.Add(game);
            context.SaveChanges();

            //act
            var query = new EditGameCommand();
            query.Id = newGame.Entity.Id;
            query.MaximalPlayersAmount = expectedMaxAmount;
            query.Name = expectedName;
            query.MinimalPlayersAge = expectedAge;
            query.MinimalPlayersAmount = expectedMinAmount;

            var handler = new EditGameCommand.Handler(context);
            var result = await handler.Handle(query, default);

            //assert
            var createdGame = context.Games
                      .Where(x => x.Id == newGame.Entity.Id)
                      .Include(x => x.Visits)
                      .FirstOrDefault();
            Assert.Equal(expectedMaxAmount, createdGame.MaximalPlayersAmount);
            Assert.Equal(expectedName, createdGame.Name);
        }
    }
}
