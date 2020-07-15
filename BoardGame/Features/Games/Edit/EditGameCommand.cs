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

namespace BoardGame.Features.Games.Edit
{
    public class EditGameCommand : IEditGame, IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimalPlayersAmount { get; set; }
        public int MaximalPlayersAmount { get; set; }
        public int MinimalPlayersAge { get; set; }

        public class Handler : IRequestHandler<EditGameCommand, int>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(EditGameCommand request, CancellationToken cancellationToken)
            {
                Game game = await _context.Games.GetById(request.Id, cancellationToken);
                if (game == null)
                {
                    throw new EditException("No game with given Id exists.");
                }

                game.Update(request);
                _context.Games.Update(game);
                await _context.SaveChangesAsync(cancellationToken);

                return game.Id;
            }
        }
    }
}
