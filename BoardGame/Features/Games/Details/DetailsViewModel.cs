using BoardGame.Features.Games.EditView;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Details
{
    public class DetailsViewModel: EditGameViewModel
    {
        public DetailsViewModel(Game game):base(game)
        {
            Id = game.Id;
            Name = game.Name;
            MaximalPlayersAmount = game.MaximalPlayersAmount;
            MinimalPlayersAge = game.MinimalPlayersAge;
            MinimalPlayersAmount = game.MinimalPlayersAmount;
            VisitViewModels = GetVisitsViewModels(game.Visits);
        }

        private List<VisitViewModel> GetVisitsViewModels(List<Visit> visits)
        {
            return visits
                .OrderByDescending(x => x.VisitTime)
                .Take(10)
                .Select(x => new VisitViewModel(x))
                .ToList();
        }

        public List<VisitViewModel> VisitViewModels { get; set; }

        
    }
}
