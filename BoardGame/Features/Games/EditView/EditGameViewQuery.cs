using BoardGame.Features.Games.Details;
using BoardGame.Infrastructure;
using BoardGame.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.EditView
{
    public class EditGameViewQuery : IRequest<EditGameViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<EditGameViewQuery, EditGameViewModel>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<EditGameViewModel> Handle(EditGameViewQuery request, CancellationToken cancellationToken)
            {
                EditGameViewModel game = await _context.Games
                  .Where(x => x.Id == request.Id)
                  .Select(x => new EditGameViewModel(x))
                  .FirstOrDefaultAsync(cancellationToken);
                CheckExistance(game);
                return game;
            }

            private void CheckExistance(EditGameViewModel game)
            {
                if (game == null)
                {
                    throw new EditViewException(ExceptionTexts.NoGameWithGivenId);
                }
            }
        }
    }
}
