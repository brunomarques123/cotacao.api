using Cotacao.Domain.CotacaoItem;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Api.Controllers
{
    [ApiController, Route("api/v1/cotacaoitem"), EnableCors]
    public class CotacaoItemController : Controller
    {
        private readonly ILogger<CotacaoItemController> _logger;
        private readonly ICotacaoItemService _cotacaoItemService;

        public CotacaoItemController(ILogger<CotacaoItemController> logger, ICotacaoItemService cotacaoItemService)
        {
            _logger = logger;
            _cotacaoItemService = cotacaoItemService;
        }

        [HttpGet, Produces("application/json", Type = typeof(List<CotacaoItemModel>))]
        public async Task<IActionResult> ConsultarItemCotacao([FromQuery] CotacaoItemModel model)
        {
            try
            {
                var result = await _cotacaoItemService.ConsultarItemCotacao(model);
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET - api/v1/cotacaoitem erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [HttpPost, Produces("application/json")]
        public async Task<IActionResult> InserirItemCotacao([FromBody] CotacaoItemModel viewModel)
        {
            try
            {
                var result = await _cotacaoItemService.InserirItemCotacao(viewModel);
                return result > 0 ? Created("", result) : UnprocessableEntity();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "POST - api/v1/cotacaoitem erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [HttpPatch, Produces("application/json")]
        public async Task<IActionResult> AlterarItemCotacao([FromBody] CotacaoItemModel viewModel)
        {
            try
            {
                var result = await _cotacaoItemService.AlterarItemCotacao(viewModel);
                return result ? Ok(result) : UnprocessableEntity();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "PATCH - api/v1/cotacaoitem erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [HttpPost, Produces("application/json"), Route("excluir")]
        public async Task<IActionResult> ExcluirItemCotacao([FromBody] CotacaoItemModel viewModel)
        {
            try
            {
                var result = await _cotacaoItemService.ExcluirItemCotacao(viewModel);
                return result ? Ok(result) : UnprocessableEntity();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "POST - api/v1/cotacaoitem erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }
    }
}
