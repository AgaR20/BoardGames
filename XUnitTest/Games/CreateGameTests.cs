using BoardGame.Features.Games.Create;
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
    public class CreateGameTests
    {
        [Fact]
        public async void ShouldCreateGame()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();

            string expectedName = "Sabotaz";
            int expectedAge = 5;
            int expectedMaxAmount = 6;
            int expectedMinAmount = 1;


            //act
            var command = new CreateGameCommand();
            command.Name = expectedName;
            command.MinimalPlayersAmount = expectedMinAmount;
            command.MinimalPlayersAge = expectedAge;
            command.MaximalPlayersAmount = expectedMaxAmount;

            var handler = new CreateGameCommand.Handler(context);
            var result = await handler.Handle(command, default);

            //assert
            var createdGame = context.Games
                      .Where(x => x.Id == result)
                      .FirstOrDefault();
            Assert.Equal(expectedAge, createdGame.MinimalPlayersAge);
            Assert.Equal(expectedMaxAmount, createdGame.MaximalPlayersAmount);
            Assert.Equal(expectedMinAmount, createdGame.MinimalPlayersAmount);
            Assert.Equal(expectedName, createdGame.Name);
        }
    }
}
