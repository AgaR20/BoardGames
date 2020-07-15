using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Details
{
    public class DetailsViewModel
    {
        public DetailsViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimalPlayersAmount { get; set; }
        public int MaximalPlayersAmount { get; set; }
        public int MinimalPlayersAge { get; set; }


        public void CheckExistance()
        {
            if (this == null)
            {
                throw new DetailException("No game with given Id exists");
            }
        }
    }
}
