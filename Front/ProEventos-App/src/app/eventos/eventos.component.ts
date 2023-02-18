import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  larguraImagem: number = 150;
  margemImagem: number = 2;
  public exibirImagem = true;
  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    // Se filtroList tem valor? Se tem valor filtra. Se não tem não, não filtra!
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  // Filtro efetua a busca pelo tema e local
  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    // Pega todos os eventos e efeuta o filtro
    return this.eventos.filter(
      // Para cada evento dado, vai pegar o elemento evento o que você quer filtrar ex: tema ou local
      // Exemplo 2: (evento: { tema: string, local: string })
      (evento:  any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  // Injeta
  constructor(private http: HttpClient) { }

   /* Método que vai ser chamado antes de inicializar aplicação */
  ngOnInit(): void {
    this.getEventos();
  }

  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  /*
    Requisita do protocolo http do método get dentro da URL vai fazer o get e vai se inscrever no Observable,
    nesse Observable retorna dois item principais que são response e error.
  */
  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error),
    );
  }

}
