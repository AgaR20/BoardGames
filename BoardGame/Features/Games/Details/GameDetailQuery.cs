using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Details
{
    public class GameDetailQuery : IRequest<DetailsViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GameDetailQuery, DetailsViewModel>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<DetailsViewModel> Handle(GameDetailQuery request, CancellationToken cancellationToken)
            {
                Game game = await _context.Games
                    .Where(x => x.Id == request.Id)
                    .FirstOrDefaultAsync();
                CheckExistance(game);
                AddVisitToGame(game);
                await _context.SaveChangesAsync(cancellationToken);
                var model = new DetailsViewModel(game);
                return model;
            }

            private void AddVisitToGame(Game game)
            {
                var visit = GenerateVisit(game);
                game.Visits.Add(visit);
            }

            private Visit GenerateVisit(Game game)
            {
                Visit visit = new Visit( VisitSource.Web);
                _context.Visits.Add(visit);
                return visit;
            }

            private void CheckExistance(Game game)
            {
                if (game == null)
                {
                    throw new DetailException("No game with given Id exists");
                }
            }
        }
    }
}
