using BoardGame.Features.Games.Details;
using BoardGame.Features.Games.Index;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGame.API.Games
{
    [Route("api/games")]
    public class GamesApiController: Controller
    {
        private readonly IMediator _mediator;

        public GamesApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("getAllGames")]
        public async Task<IActionResult> GetAllGames(GetAllGames.GetAllGamesQuery query, CancellationToken token)
        {
            List<GamesIndexViewModel> result = await _mediator.Send(query, token);
            return Json(result);
        }

        [Route("getGame")]
        public async Task<IActionResult> GetGame(GetGame.GetGameQuery query, CancellationToken token)
        {
            DetailsViewModel result = await _mediator.Send(query, token);
            return Json(result);
        }
    }
}
