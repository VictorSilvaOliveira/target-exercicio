import { Component, OnInit } from '@angular/core';
import { Observable, Subject, map, tap } from 'rxjs';
import { Lancamento, Status } from 'src/app/model/lancamento';
import { LancamentoService } from 'src/app/service/lancamento.service';

const DOIS_DIAS = 172800000;
@Component({
  selector: 'app-lancamento-list',
  templateUrl: './lancamento-list.component.html',
  styleUrls: ['./lancamento-list.component.css']
})
export class LancamentoListComponent implements OnInit  {
  
  lancamentos$: Observable<Array<Lancamento>>;
  loading: boolean = true;
  Status = Status;
  dataInicio: Date;
  dataFim: Date;
  total = 0;
  constructor(private _lancamentoServices: LancamentoService)  {
    this.lancamentos$ = this.loadLancamentoList();
    this.dataFim = new Date();
    this.dataInicio = new Date(this.dataFim.getTime() - DOIS_DIAS);
  }

  ngOnInit(): void {
    this.loadLancamentoList();
  }

  private loadLancamentoList() {
    return this._lancamentoServices.getAll(this.dataInicio, this.dataFim).pipe(
      tap(resposta => this.total= resposta.total),
      map(resposta => resposta.lancamentos)
    );
  }

  dataFilter() {
    this.lancamentos$ = this.loadLancamentoList();
  }

  cancelarLancamento(lancamento: Lancamento){
    if (lancamento.avulso && lancamento.status === Status.Valido) {
      this._lancamentoServices.cancelLancamento(lancamento.id).subscribe(() => this.lancamentos$ = this.loadLancamentoList());
    }
  }
}
