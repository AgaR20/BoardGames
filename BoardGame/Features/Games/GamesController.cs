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
using BoardGame.Features.Games.Details;

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
        public async Task<IActionResult> EditView([FromBody] EditView.EditGameViewQuery query, CancellationToken token)
        {
            //List<GamesIndexViewModel> result = await _mediator.Send(query, token);
            return View("Index/Index");
        }
        public async Task<IActionResult> DeleteView(GetAllGamesQuery query, CancellationToken token)
        {
            List<GamesIndexViewModel> result = await _mediator.Send(query, token);
            return View("Index/Index", result);
        }
        public async Task<IActionResult> Detail([FromBody] Details.GameDetailQuery query, CancellationToken token)
        {
            DetailsViewModel result = await _mediator.Send(query, token);
            return View("Details/Details", result);
        }
        public async Task<IActionResult> AddView(GetAllGamesQuery query, CancellationToken token)
        {
            List<GamesIndexViewModel> result = await _mediator.Send(query, token);
            return View("Index/Index", result);
        }

    }
}
