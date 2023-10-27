export enum Status {
  Valido = 0,
  Cancelado = 1,
}

export class Lancamento {
  id: string = '';
  descricao: string = '';
  valor: number = 0;
  data: Date = new Date();
  status: Status = Status.Valido;
  avulso: boolean = false;
}

export class LancamentoList {
  lancamentos: Array<Lancamento> = [];
  total: number = 0;
}
