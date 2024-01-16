using Target.App.Model;

namespace Target.App.Features.RecuperaLancamento;

public class RecuperaLancamento : IFeature<RecuperaLancamentoRequisicao, RecuperaLancamentoResposta>
{
    private readonly LancamentoDbContext _dbContext;

    public RecuperaLancamento(LancamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public RecuperaLancamentoResposta Executa(RecuperaLancamentoRequisicao request)
    {
        var dataInicio = request.DataInicio ?? DateTime.UtcNow.AddDays(-2);
        var dataFim = request.DataFim ?? DateTime.UtcNow;
        var lancamentos = _dbContext
            .Lancamentos
            .Where(l => l.Data >= dataInicio && l.Data <= dataFim)
            .ToList();

        return new RecuperaLancamentoResposta() { Lancamentos = lancamentos, Total = lancamentos.Sum(l=> l.Valor) };
    }
}
