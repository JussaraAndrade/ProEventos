import { Component, OnInit, TemplateRef } from '@angular/core';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  message?: string;

  eventos: Evento[] = [];
  eventosFiltrados: Evento[] = [];

  larguraImagem: number = 150;
  margemImagem: number = 2;
  exibirImagem = true;
  private filtroListado = '';

  // Injeta
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

   /* Método que vai ser chamado antes de inicializar aplicação */
  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  public get filtroLista(): string{
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
    // Se filtroList tem valor? Se tem valor filtra. Se não tem não, não filtra!
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  // Filtro efetua a busca pelo tema e local
  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    // Pega todos os eventos e efeuta o filtro
    return this.eventos.filter(
      // Para cada evento dado, vai pegar o elemento evento o que você quer filtrar ex: tema ou local
      // Exemplo 2: (evento: { tema: string, local: string })
      (evento:  any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  /*
    Requisita do protocolo http do método get dentro da URL vai fazer o get e vai se inscrever no Observable,
    nesse Observable retorna dois item principais que são response e error.
  */
  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => { // Informando a tipagem Evento[] - recebe os valores da chamada da api
        this.eventos = eventos; // recebe o valores para atribuir em uma outra propriedes para refletir na tabela
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Eventos.', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com Sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
