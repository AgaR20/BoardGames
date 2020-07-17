using BoardGame.Features.Games.Details;
using BoardGame.Infrastructure;
using BoardGame.Infrastructure.Exceptions;
using BoardGame.Infrastructure.Extensions;
using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.API.Games.GetGame
{
    public class GetGameQuery : IRequest<DetailsViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetGameQuery, DetailsViewModel>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<DetailsViewModel> Handle(GetGameQuery request, CancellationToken cancellationToken)
            {
                Game game = await _context.Games.GetByIdWithVisits(request.Id, cancellationToken);
                Throw.IsNull(game, ExceptionTexts.NoGameWithGivenId);

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
                Visit visit = new Visit(VisitSource.Api);
                _context.Visits.Add(visit);
                return visit;
            }

        }

    }
}
