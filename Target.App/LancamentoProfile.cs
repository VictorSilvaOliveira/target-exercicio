using AutoMapper;
using Target.App.Features.AlterarLancamento;
using Target.App.Features.CancelarLancamento;
using Target.App.Features.DetalheLancamento;
using Target.App.Features.IncluirLancamento;
using Target.App.Features.IncluirLancamentoAvulso;
using Target.App.Model;

namespace Target.App
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<IncluirLancamentoRequisicao, Lancamento>()
                .ForMember(d => d.Id, s => s.MapFrom(o => Guid.NewGuid()))
                .ForMember(d => d.Avulso, s => s.MapFrom(o => false));

            CreateMap<IncluirLancamentoAvulsoRequisicao, Lancamento>()
                .ForMember(d => d.Id, s => s.MapFrom(o => Guid.NewGuid()))
                .ForMember(d => d.Avulso, s => s.MapFrom(o => true));

            CreateMap<CancelarLancamentoRequisicao, Lancamento>()
                .ForMember(d => d.Status, s => s.MapFrom(o => Status.Cancelado));

            CreateMap<AlterarLancamentoRequisicao, Lancamento>();

            CreateMap<Lancamento, IncluirLancamentoResposta>();
            CreateMap<Lancamento, IncluirLancamentoAvulsoResposta>();
            CreateMap<Lancamento, AlterarLancamentoResposta>();
            CreateMap<Lancamento, CancelarLancamentoResposta>();
            CreateMap<Lancamento, DetalheLancamentoResposta>();
        }
    }
}
