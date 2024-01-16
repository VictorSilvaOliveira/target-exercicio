using Microsoft.AspNetCore.Mvc;
using Target.App.Features;
using Target.App.Features.AlterarLancamento;
using Target.App.Features.CancelarLancamento;
using Target.App.Features.DetalheLancamento;
using Target.App.Features.IncluirLancamento;
using Target.App.Features.IncluirLancamentoAvulso;
using Target.App.Features.RecuperaLancamento;

namespace Target.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {

        private readonly ILogger<LancamentoController> _logger;

        public LancamentoController(ILogger<LancamentoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<RecuperaLancamentoResposta> Get(
            [FromQuery] DateTime? dataInicio,
            [FromQuery] DateTime? dataFim,
            [FromServices] IFeature<RecuperaLancamentoRequisicao, RecuperaLancamentoResposta> recuperaLancamentos)
        {
            return Ok(recuperaLancamentos.Executa(new RecuperaLancamentoRequisicao() { DataInicio = dataInicio, DataFim = dataFim }));
        }

        [HttpGet("{id}")]
        public ActionResult<DetalheLancamentoResposta> Get(
            [FromRoute] Guid id,
            [FromServices] IFeature<DetalheLancamentoRequisicao, DetalheLancamentoResposta> recuperaLancamento)
        {
            return Ok(recuperaLancamento.Executa(new DetalheLancamentoRequisicao() { Id = id }));
        }

        [HttpPost()]
        public ActionResult<IncluirLancamentoAvulsoResposta> Criar(
            [FromBody] IncluirLancamentoAvulsoRequisicao requesicao,
            [FromServices] IFeature<IncluirLancamentoAvulsoRequisicao, IncluirLancamentoAvulsoResposta> criarLancamento)
        {
            var resposta = criarLancamento.Executa(requesicao);
            return Created($"/{resposta.Id}", resposta);
        }

        [HttpPost("nao-avulso")]
        public ActionResult<IncluirLancamentoResposta> CriarNaoAvulso(
            [FromBody] IncluirLancamentoRequisicao requesicao,
            [FromServices] IFeature<IncluirLancamentoRequisicao, IncluirLancamentoResposta> criarLancamento)
        {
            var resposta = criarLancamento.Executa(requesicao);
            return Created($"/{resposta.Id}", resposta);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(
            [FromRoute] Guid id,
            [FromServices] IFeature<CancelarLancamentoRequisicao, CancelarLancamentoResposta> cancelarLancamento)
        {
            cancelarLancamento.Executa(new CancelarLancamentoRequisicao() { Id = id });
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult<AlterarLancamentoResposta> Update(
            [FromRoute] Guid id,
            [FromBody] AlterarLancamentoRequisicao requisicao,
            [FromServices] IFeature<AlterarLancamentoRequisicao, AlterarLancamentoResposta> alterarLancamento)
        {
            requisicao.Id = id;
            return Ok(alterarLancamento.Executa(requisicao));
        }
    }
}