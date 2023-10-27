using AutoMapper;
using Target.App.Model;

namespace Target.App.Features.IncluirLancamento
{
    public class IncluirLancamento : IFeature<IncluirLancamentoRequisicao, IncluirLancamentoResposta>
    {
        private readonly LancamentoDbContext _dbContext;
        private readonly IMapper _mapper;

        public IncluirLancamento(LancamentoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IncluirLancamentoResposta Executa(IncluirLancamentoRequisicao request)
        {
            var lancamento = _mapper.Map<Lancamento>(request);

            _dbContext.Lancamentos.Add(lancamento);

            _dbContext.SaveChanges();

            return _mapper.Map<IncluirLancamentoResposta>(lancamento);
        }
    }
}
