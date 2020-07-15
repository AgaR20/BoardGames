using BoardGame.Features.Games.Delete;
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
    public class DeleteGameTests
    {
        [Fact]
        public async void ShouldDeleteGame()
        {
            //arrange
            BoardContext context = new ContextBuilder().BuildClean();
            Game game = new GameBuilder(context)
                .Build();

            var newGame = context.Add(game);
            context.SaveChanges();

            //act
            var command = new DeleteGameCommand();
            command.Id = newGame.Entity.Id;
            var handler = new DeleteGameCommand.Handler(context);
            var result = await handler.Handle(command, default);

            //assert
            var deletedGame = context.Games
                     .Where(x => x.Id == newGame.Entity.Id)
                     .FirstOrDefault();
            Assert.Null(deletedGame);
        }
    }
}
