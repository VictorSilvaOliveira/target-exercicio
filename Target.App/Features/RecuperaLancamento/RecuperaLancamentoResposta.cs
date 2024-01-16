using Target.App.Model;

namespace Target.App.Features.RecuperaLancamento;

public class RecuperaLancamentoResposta
{
    public IEnumerable<Lancamento> Lancamentos {  get; set; }

    public double Total { get; set; }
}
