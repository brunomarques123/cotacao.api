using Cotacao.Domain.Cotacao;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Api.Controllers
{
    [ApiController, Route("api/v1/cotacao"), EnableCors]
    public class CotacaoController : Controller
    {
        private readonly ILogger<CotacaoController> _logger;
        private readonly ICotacaoService _cotacaoService;

        public CotacaoController(ILogger<CotacaoController> logger, ICotacaoService cotacaoService)
        {
            _logger = logger;
            _cotacaoService = cotacaoService;
        }

        [HttpGet, Produces("application/json", Type = typeof(List<CotacaoModel>))]
        public async Task<IActionResult> ConsultarCotacao()
        {
            try
            {
                var result = await _cotacaoService.ConsultarCotacao();
                return result != null ? Ok(result) : NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GET - api/v1/cotacao erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [HttpPost, Produces("application/json")]
        public async Task<IActionResult> InserirCotacao([FromBody] CotacaoModel viewModel)
        {
            try
            {
                var result = await _cotacaoService.InserirCotacao(viewModel);
                return result > 0 ? Created("", result) : UnprocessableEntity();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "POST - api/v1/cotacao erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [HttpPatch, Produces("application/json")]
        public async Task<IActionResult> AlterarCotacao([FromBody] CotacaoModel viewModel)
        {
            try
            {
                var result = await _cotacaoService.AlterarCotacao(viewModel);
                return result ? Ok(result) : UnprocessableEntity();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "PATCH - api/v1/cotacao erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [HttpPost, Produces("application/json"), Route("excluir")]
        public async Task<IActionResult> ExcluirCotacao([FromBody] CotacaoModel viewModel)
        {
            try
            {
                var result = await _cotacaoService.ExcluirCotacao(viewModel);
                return result ? Ok(result) : UnprocessableEntity();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "POST - api/v1/cotacao erro.");
                return Problem(statusCode: 500, detail: e.Message);
            }
        }
    }
}
