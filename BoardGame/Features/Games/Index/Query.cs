using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Index
{
    public class Query:IRequest<int>
    {
    }
    public class Handler : IRequestHandler<Query, int>
    {
        public Task<int> Handle(Query request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
