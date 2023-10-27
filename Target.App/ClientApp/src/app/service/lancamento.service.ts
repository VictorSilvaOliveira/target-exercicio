import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Lancamento, LancamentoList } from '../model/lancamento';
import { Observable, first } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LancamentoService {
  private readonly API = '/lancamento';

  constructor(private http: HttpClient) { }

  getAll(dataInicio?: Date, dataFim?: Date): Observable<LancamentoList> {

    let params = new HttpParams();
    if (dataInicio) {
      params = params.append("dataInicio", dataInicio.toISOString());
    }
    if (dataFim) {
      params = params.append("dataFim", dataFim.toISOString());
    }
    console.log('victor', params)
    return this.http.get<LancamentoList>(this.API, { params: params }).pipe(first());
  }

  cancelLancamento(id: string): Observable<void> {
    return this.http.delete<void>(`${this.API}/${id}`, { params: {} })
       .pipe(first());
  }

  adicionarLancamento(lancamento: Lancamento): Observable<Lancamento> {
    return this.http.post<Lancamento>(this.API, lancamento).pipe(first());
  }


  atualizarLancamento(lancamento: Lancamento): Observable<Lancamento> {
    return this.http.patch<Lancamento>(`${this.API}/${lancamento.id}`, lancamento).pipe(first());
  }

  lancamentoDetalhe(id: string): Observable<Lancamento> {
    return this.http.get<Lancamento>(`${this.API}/${id}`).pipe(first());
  }
}
