using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Index
{
    public class GetAllGamesQuery : IRequest<List<GamesIndexViewModel>>
    {
        public class Handler : IRequestHandler<GetAllGamesQuery, List<GamesIndexViewModel>>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }
            public async Task<List<GamesIndexViewModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Games
                    .Select(x => new GamesIndexViewModel(x))
                    .ToListAsync(cancellationToken);
            }
        }
    }

}
