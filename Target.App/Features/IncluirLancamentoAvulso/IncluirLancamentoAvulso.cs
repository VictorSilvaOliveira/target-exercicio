using AutoMapper;
using Target.App.Model;

namespace Target.App.Features.IncluirLancamentoAvulso
{
    public class IncluirLancamentoAvulso: IFeature<IncluirLancamentoAvulsoRequisicao, IncluirLancamentoAvulsoResposta>
    {
        private readonly LancamentoDbContext _dbContext;
        private readonly IMapper _mapper;

        public IncluirLancamentoAvulso(LancamentoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IncluirLancamentoAvulsoResposta Executa(IncluirLancamentoAvulsoRequisicao request)
        {
            var lancamento = _mapper.Map<Lancamento>(request);

            _dbContext.Lancamentos.Add(lancamento);

            _dbContext.SaveChanges();

            return _mapper.Map<IncluirLancamentoAvulsoResposta>(lancamento);
        }
    }
}
