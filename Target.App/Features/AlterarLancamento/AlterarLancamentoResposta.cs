﻿namespace Target.App.Features.AlterarLancamento;
public class AlterarLancamentoResposta
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public double Valor { get; set; }
    public Status Status { get; set; }
    public bool Avulso { get; set; }
}
