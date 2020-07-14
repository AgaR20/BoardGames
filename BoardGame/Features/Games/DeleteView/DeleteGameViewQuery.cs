using BoardGame.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.DeleteView
{
    public class DeleteGameViewQuery: IRequest<int>
    {
        public class Handler : IRequestHandler<DeleteGameViewQuery, int>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteGameViewQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
