import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from 'rxjs/internal/Subject';
import {
  CalendarEvent,
  CalendarEventTimesChangedEvent,
  CalendarView
} from 'angular-calendar'
import { AgendamentoSimulacao } from 'src/app/agendamento-simulacao';
import { AddEditSimulacaoComponent } from '../add-edit-simulacao/add-edit-simulacao.component';
import { Servico } from 'src/app/servico';
import { ConversaoHora } from 'src/app/conversao-hora';
import { RetornoAddEditSimulacao } from '../retorno-add-edit-simulacao';

@Component({
  selector: 'app-show-simulacao',
  templateUrl: './show-simulacao.component.html',
  styleUrls: ['./show-simulacao.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ShowSimulacaoComponent implements OnInit {

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  refresh: Subject<any> = new Subject();
  viewDate: Date = new Date();
  dayStartHour: number = 6;
  dayEndHour: number = 22;
  hourSegments: number = 2;
  hourSegmentHeight: number = 30;

  agendamentos: AgendamentoSimulacao[] = [];
  events: CalendarEvent[] = []

  eventTimesChanged({ event, newStart, newEnd }: CalendarEventTimesChangedEvent): void {
    var agendamentoSelecionado = this.obterAgendamentoPorEvento(event);
    const newStartSTring = ConversaoHora.getStringHora(newStart);
    agendamentoSelecionado.hora = newStartSTring;
    event.start = newStart;
    event.end = newEnd;
    this.refresh.next(null);

    console.log(this.events);
    console.log(this.agendamentos);
  }

  eventClicked({ event }: { event: CalendarEvent }): void {
    var agendamentoSelecionado = this.obterAgendamentoPorEvento(event);
    console.log(agendamentoSelecionado);
  }

  hourSegmentClicked(date: Date, sourceEvent: MouseEvent): void {
    this.adicionarSimulacao(date);
  }

  obterAgendamentoPorEvento(event: CalendarEvent): AgendamentoSimulacao {
    // Busca um agendamento correspondente ao evento, buscando pela hora de início
    const eventStartString = ConversaoHora.getStringHora(event.start);
    return this.agendamentos.filter((value) => value.hora == eventStartString)[0];
  }

  async adicionarSimulacao(date: Date): Promise<void> {
    const modalRef = this.modalService.open(AddEditSimulacaoComponent);
    modalRef.componentInstance.nomeJanela = "Novo agendamento";
    modalRef.componentInstance.horaSelecionada = date;

    var servicoSelecionado = new Servico();
    await modalRef.result.then((result) => {
      const dadosResult = result as RetornoAddEditSimulacao;
      servicoSelecionado = dadosResult.servico;
      date = dadosResult.hora;
    }, () => { });

    /* Encerra o método se a janela de seleção foi fechada e o 
    servico selecionado não foi atribuído */
    if (servicoSelecionado.id == 0) return;

    var agendamento = new AgendamentoSimulacao();
    agendamento.idServico = servicoSelecionado.id
    agendamento.hora = AgendamentoSimulacao.horaAsString(date.getHours(), date.getMinutes());

    const horaTerminoString = agendamento.getHoraTermino(servicoSelecionado);
    var horaTermino = ConversaoHora.getDateFromString(horaTerminoString);

    var novoEvento: CalendarEvent = {
      title: servicoSelecionado.nome,
      start: date,
      end: horaTermino,
      draggable: true,
    };

    this.events.push(novoEvento);
    this.agendamentos.push(agendamento);
    this.refresh.next(null);
  }

}
