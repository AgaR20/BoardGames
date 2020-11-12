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
using BoardGame.Features.Games.EditView;

namespace BoardGame.Features.Games
{
    public class GamesController : Controller
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            List<GamesIndexViewModel> result = await _mediator.Send(new GetAllGamesQuery(), token);
            return View("Index/Index", result);
        }
        public async Task<IActionResult> EditView(EditView.EditGameViewQuery query, CancellationToken token)
        {
            EditGameViewModel result = await _mediator.Send(query, token);
            return View("EditView/EditView", result);
        }
        public async Task<IActionResult> DeleteView(DeleteView.DeleteGameViewQuery query, CancellationToken token)
        {
            GamesIndexViewModel result = await _mediator.Send(query, token);
            return View("DeleteView/Delete", result);
        }
        public async Task<IActionResult> Details(Details.GameDetailQuery query, CancellationToken token)
        {
            query.IsFromWeb = true;
            DetailsViewModel result = await _mediator.Send(query, token);
            return View("Details/Details", result);
        }
        public async Task<IActionResult> AddView()
        {
            return View("AddView/AddView");
        }
        public async Task<IActionResult> Create(Create.CreateGameCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Delete.DeleteGameCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(Edit.EditGameCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return RedirectToAction("Index");
        }

    }
}
