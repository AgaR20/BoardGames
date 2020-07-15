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

namespace BoardGame.Features.Games.Delete
{
    public class DeleteGameCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteGameCommand, int>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
            {
                Game game = await _context.Games.GetByIdWithVisits(request.Id, cancellationToken);
                if (game == null)
                {
                    throw new DeteleException("No game with given Id.");
                }
                _context.Visits.RemoveRange(game.Visits);
                _context.Games.Remove(game);
                await _context.SaveChangesAsync(cancellationToken);
                return game.Id;
            }
        }
    }
}
