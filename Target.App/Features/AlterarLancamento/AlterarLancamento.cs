using AutoMapper;
using Target.App.Model;

namespace Target.App.Features.AlterarLancamento;

public class AlterarLancamento: IFeature<AlterarLancamentoRequisicao, AlterarLancamentoResposta>
{
    private readonly LancamentoDbContext _dbContext;
    private readonly IMapper _mapper;

    public AlterarLancamento(LancamentoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public AlterarLancamentoResposta Executa(AlterarLancamentoRequisicao request)
    {
        var rawLancamento = _dbContext.Lancamentos.First(f => 
            f.Id == request.Id && 
            f.Avulso && 
            f.Status == Status.Valido
        );
        
        var lancamento = _mapper.Map(request, rawLancamento);

        _dbContext.Lancamentos.Update(lancamento);

        _dbContext.SaveChanges();

        return _mapper.Map<AlterarLancamentoResposta>(lancamento);
    }
}
