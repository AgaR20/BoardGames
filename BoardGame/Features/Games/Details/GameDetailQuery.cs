using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                DetailsViewModel game = await _context.Games
                    .Where(x => x.Id == request.Id)
                    .Select(x => new DetailsViewModel(x))
                    .FirstOrDefaultAsync();

                CheckExistance(game);
                return game;
            }

            private void CheckExistance(DetailsViewModel game)
            {
                if (game == null)
                {
                    throw new DetailException("No game with given Id exists");
                }
            }
        }
    }
}
