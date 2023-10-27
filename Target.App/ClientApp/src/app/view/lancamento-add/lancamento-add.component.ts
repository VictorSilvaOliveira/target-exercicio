import { Component } from '@angular/core';
import { LancamentoService } from 'src/app/service/lancamento.service';
import { Lancamento, Status } from '../../model/lancamento';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';

@Component({
    selector: 'app-lancamento-add',
    templateUrl: './lancamento-add.component.html',
    styleUrls: ['./lancamento-add.component.css'],
})
export class LancamentoAddComponent {

    lancamentoForm: FormGroup;
    id: any;

    constructor(
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _lancamentoServices: LancamentoService
    ) {
        this.lancamentoForm = new FormGroup({
            "descricao": new FormControl('', [
                Validators.required,
            ]),
            "data": new FormControl(new Date(), Validators.required),
            "valor": new FormControl(0, [
                Validators.required,
                this.valorValidators()
            ])
        });
    }
    get descricao() { return this.lancamentoForm.get('descricao'); }
    get data() { return this.lancamentoForm.get('data'); }
    get valor() { return this.lancamentoForm.get('valor'); }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe(params => {
            if (params['id']) {
                this.id = params['id'];
                this._lancamentoServices.lancamentoDetalhe(params['id']).subscribe((lancamento) => {
                    this.lancamentoForm.patchValue(lancamento);
                });
            }
        });
    }

    salvarLancamento() {
        const returnList = () => { this._router.navigate(['/'], { relativeTo: this._activatedRoute }); };
        if (this.lancamentoForm.valid) {
            if (this.id) {
                this._lancamentoServices.atualizarLancamento({ id: this.id, ...this.lancamentoForm.value }).subscribe(returnList);
            }
            else {
                this._lancamentoServices.adicionarLancamento(this.lancamentoForm.value).subscribe(returnList);
            }
        }

    }
    valorValidators() {
        return (control: AbstractControl): ValidationErrors | null => {
            return (/0/.test(control.value)) ? { notValid: control.value } : null;
        }
    }
}
