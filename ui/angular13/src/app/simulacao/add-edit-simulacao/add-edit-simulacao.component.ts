import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AgendamentoSimulacao } from 'src/app/agendamento-simulacao';
import { Servico } from 'src/app/servico';
import { ApicallService } from 'src/app/apicall.service';

@Component({
  selector: 'app-add-edit-simulacao',
  templateUrl: './add-edit-simulacao.component.html',
  styleUrls: ['./add-edit-simulacao.component.css']
})
export class AddEditSimulacaoComponent implements OnInit {
  @Input() name: any;
  @Input() agendamento: AgendamentoSimulacao = new AgendamentoSimulacao();

  nomeJanela: string = "";
  servicoSelecionado: Servico = new Servico();
  idSelecionado: number = 0;
  servicos: Servico[] = [];

  constructor(public activeModal: NgbActiveModal, public apiService: ApicallService) { }

  ngOnInit(): void {
    this.apiService.getListaServicos().subscribe((result) => {
      this.servicos = result;
    });
  }

  salvar(): void {
    console.log(this.idSelecionado);
    this.apiService.getServico(this.idSelecionado).subscribe(result => {
      console.log(result);
    });
    this.agendamento.idServico = this.idSelecionado;
  }

}