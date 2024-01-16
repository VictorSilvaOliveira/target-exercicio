using AutoMapper;
using Target.App.Model;

namespace Target.App.Features.DetalheLancamento;
public class DetalheLancamento : IFeature<DetalheLancamentoRequisicao, DetalheLancamentoResposta>
{
    private readonly LancamentoDbContext _dbContext;
    private readonly IMapper _mapper;

    public DetalheLancamento(LancamentoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public DetalheLancamentoResposta Executa(DetalheLancamentoRequisicao request)
    {
        var lancamentos = _dbContext
            .Lancamentos
            .FirstOrDefault(l => l.Id == request.Id);

        return _mapper.Map<DetalheLancamentoResposta>(lancamentos);
    }
}

