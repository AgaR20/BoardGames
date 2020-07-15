using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Index
{
    public class GamesIndexViewModel
    {
        public GamesIndexViewModel(Game game)
        {
            Name = game.Name;
            Id = game.Id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
