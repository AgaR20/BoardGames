using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BoardGame.Model;
using MediatR;
using BoardGame.Features.Games.Index;
using System.Threading;

namespace BoardGame.Features.Games
{
    public class GamesController : Controller
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllGamesQuery query, CancellationToken token)
        {
            List<GamesIndexViewModel> result = await _mediator.Send(query, token);
            return View("Index/Index", result);
        }

    }
}
