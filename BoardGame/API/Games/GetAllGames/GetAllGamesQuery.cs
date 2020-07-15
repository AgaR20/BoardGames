using BoardGame.Features.Games.Index;
using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.API.Games.GetAllGames
{
    public class GetAllGamesQuery : IRequest<List<GamesIndexViewModel>>
    {
        public int? LimitNumber { get; set; }
        public class Handler : IRequestHandler<GetAllGamesQuery, List<GamesIndexViewModel>>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }
            public async Task<List<GamesIndexViewModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
            {
                List<GamesIndexViewModel> games = new List<GamesIndexViewModel>();
                IQueryable<GamesIndexViewModel> gamesQuery =  _context.Games
                    .Select(x => new GamesIndexViewModel(x));
                if (request.LimitNumber != null)
                {
                    games = await gamesQuery
                        .Take(request.LimitNumber?? default(int))
                        .ToListAsync(cancellationToken);
                }
                else
                {
                    games = await gamesQuery
                        .ToListAsync(cancellationToken);
                }

                return games;
            }
        }
    }
    
    
}
