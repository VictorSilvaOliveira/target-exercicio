using AutoMapper;
using Target.App.Model;

namespace Target.App.Features.CancelarLancamento
{
    public class CancelarLancamento : IFeature<CancelarLancamentoRequisicao, CancelarLancamentoResposta>
    {
        private readonly LancamentoDbContext _dbContext;
        private readonly IMapper _mapper;
        public CancelarLancamento(LancamentoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CancelarLancamentoResposta Executa(CancelarLancamentoRequisicao request)
        {
            var rawLancamento = _dbContext.Lancamentos.FirstOrDefault(f =>
                f.Id == request.Id &&
                f.Avulso &&
                f.Status == Status.Valido
            );

            var resposta = new CancelarLancamentoResposta();

            if (rawLancamento != null)
            {
                var lancamento = _mapper.Map(request, rawLancamento);
                _dbContext.Lancamentos.Update(lancamento);
                _dbContext.SaveChanges();
                resposta = _mapper.Map<CancelarLancamentoResposta>(lancamento);
            }

            return resposta;
        }
    }
}