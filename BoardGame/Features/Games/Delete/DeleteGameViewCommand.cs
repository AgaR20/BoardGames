using BoardGame.Features.Games.DeleteView;
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
    public class DeleteGameViewCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteGameViewCommand, int>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteGameViewCommand request, CancellationToken cancellationToken)
            {
                Game game = await _context.Games.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                if (game == null)
                {
                    throw new DeteleException("No game with given Id.");
                }
                _context.Games.Remove(game);
                await _context.SaveChangesAsync(cancellationToken);
                return game.Id;
            }
        }
    }
}
