﻿using BoardGame.Model;
using MediatR;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.Features.Games.Create
{
    public class CreateGameCommand : IAddEditGame, IRequest<int>
    {
        public string Name { get; set; }
        public int MinimalPlayersAmount { get ; set ; }
        public int MaximalPlayersAmount { get; set; }
        public int MinimalPlayersAge { get; set ; }

        public class Handler : IRequestHandler<CreateGameCommand, int>
        {
            private readonly BoardContext _context;
            public Handler(BoardContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                var game = await _context.Games
                    .AddAsync(new Game(request));
                await _context.SaveChangesAsync();
                return game.Entity.Id;
            }
        }
    
    }
}
