using BoardGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Details
{
    public class DetailsViewModel: Game
    {
        public DetailsViewModel(Game game, bool isEditMode)
        {
            IsEditMode = isEditMode;
            Id = game.Id;
            Name = game.Name;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
        }
        public bool IsEditMode { get; set; }
    }
}
