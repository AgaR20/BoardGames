using BoardGame.Features.Games.Delete;
using BoardGame.Features.Games.Index;
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

namespace BoardGame.Features.Games.DeleteView
{
    public class DeleteGameViewQuery : IRequest<GamesIndexViewModel>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteGameViewQuery, GamesIndexViewModel>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<GamesIndexViewModel> Handle(DeleteGameViewQuery request, CancellationToken cancellationToken)
            {
                Game game = await _context.Games.GetById(request.Id, cancellationToken);
                Throw.IsNull(game, ExceptionTexts.NoGameWithGivenId);

                return new GamesIndexViewModel(game);
            }
        }
    }
}
