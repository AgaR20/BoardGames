using BoardGame.Features.Games.Details;
using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

                game.CheckExistance();
                return game;
            }

        }
    
    }
}
