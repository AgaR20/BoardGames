using BoardGame.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Index
{
    public class Query:IRequest<List<GamesIndexViewModel>>
    {
    }
    public class Handler : IRequestHandler<Query, List<GamesIndexViewModel>>
    {
        private readonly BoardContext _context;
        public Handler(BoardContext context)
        {
            _context = context;
        }
        public async Task<List<GamesIndexViewModel>> Handle(Query request, CancellationToken cancellationToken)
        {

            return _context.Games.Select(x=> new GamesIndexViewModel { Name = x.Name, Id = x.Id}).ToList();
        }
    }
}
