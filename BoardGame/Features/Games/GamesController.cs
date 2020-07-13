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

namespace BoardGame.Controllers
{
    public class GamesController : Controller
    {
        private readonly IMediator _mediator;

        public GamesController( IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            //var list = _context.Games.ToList();
            //_context.Games.Add(new Game());
            //_context.SaveChanges();
            List<GamesIndexViewModel> result = await _mediator.Send(new Query());
            return View("Index/Index", result);
        }

    }
}
